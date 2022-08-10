using Microsoft.AspNetCore.Identity;
using MockProject.API.DTO;
using MockProject.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Google.Apis.Auth;
using MockProject.API.Reponsitory.Interface;
using Microsoft.EntityFrameworkCore;

namespace MockProject.API.Reponsitory.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly iHomeContext _context;
        private UserManager<User> _userManager;
        private IConfiguration _configuration;
        private IMailRepository _mail;
        public AccountRepository(UserManager<User> userManager, IConfiguration configuration, IMailRepository mail, DbContextOptions<iHomeContext> context)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mail = mail;
            _context = new iHomeContext(context);
        }

        #region Generate token
        private Tuple<string, DateTime> GenerateToken(User user)
        {
            // Create claim for user
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("Email", user.Email)
            };
            // Generate token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return new Tuple<string, DateTime>(new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo);
        }
        #endregion

        #region Generate random password for Google login
        public string GeneratePassword()
        {
            var opts = new PasswordOptions()
            {
                RequiredLength = 12,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
        #endregion

        #region Send confirm email
        private async void SendConfirmMail(User user)
        {
            // Encode token
            var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
            var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);
            // Create URL for user to click and send to user email
            string url = $"{_configuration["ClientUrl"]}/User/ConfirmAccountSuccessfully?userid={user.Id}&token={validEmailToken}";
            //await _mail.SendMail(user.Email, "Confirm your email", $"<h1>Confirm your email</h1><p>Please click this <a href={url}>link</a> to confirm your email</p>");
            await _mail.SendMail(user.Email, "Confirm your email", $"<h1>Confirm your email</h1><p><span style='font-size:15.6px'>You must confirm your email before login and using ours services.</span></p><p><span style='font-size:15.6px'>Please click on <a href='{url}'>this link</a>&nbsp;to confirm your email</span></p>");
        }
        #endregion

        #region Login
        public async Task<ResponseModel> LoginUser(LoginViewModel model)
        {
            // Check if user is exist
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "Email address does not exists!"
                };
            }
            // Check if user email confirm yet
            var isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            if (!isEmailConfirmed)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "Email address hasn't been comfirmed yet!"
                };
            }
            // Check if user deactivated
            if (user.Status == 0)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "This account has been deactivated. Please contact administrator for support!"
                };
            }
            // Check if password is correct
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "Email address and password combination incorrect!"
                };
            }
            // Create token if everything correct
            var token = GenerateToken(user);
            return new ResponseModel()
            {
                Success = true,
                Message = "Login success",
                Data = new
                {
                    token = token.Item1,
                    expire = token.Item2
                }
            };
        }
        #endregion

        #region Login with Google
        public async Task<ResponseModel> LoginGoogle(string googleToken)
        {
            try
            {
                // Verify Google access token
                GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(googleToken);
                // Check if user exists
                var user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    // Create new user if not exist
                    var newUser = new User()
                    {
                        UserName = payload.Email,
                        Email = payload.Email,
                        Name = payload.Name,
                        EmailConfirmed = true
                    };
                    var userPassword = GeneratePassword();
                    var result = await _userManager.CreateAsync(newUser, userPassword);
                    if (result.Succeeded)
                    {
                        // Set user to generate token to new user
                        user = newUser;
                        // Send email with password to that user
                        await _mail.SendMail(user.Email, "Login using Google account", $"<h1>You have create your account using your Google account</h1><p><span style='font-size:15.6px'>Your password to login to our service is: <b>{userPassword}</b></span></p>");
                    }
                    else
                    {
                        // If create failed, show error
                        return new ResponseModel()
                        {
                            Success = false,
                            Message = string.Join(" ", result.Errors.Select(x => x.Description))
                        };
                    }
                }
                // Create token for that user
                var token = GenerateToken(user);
                return new ResponseModel()
                {
                    Success = true,
                    Message = "Login success",
                    Data = new
                    {
                        token = token.Item1,
                        expire = token.Item2
                    }
                };
            }
            catch (InvalidJwtException)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "Invalid token"
                };
            }
        }
        #endregion

        #region Register
        public async Task<ResponseModel> RegisterUser(RegisterViewModel model)
        {
            // Check if 2 password is match
            if (!model.Password.Equals(model.ConfirmPassword))
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "Password doesn't match"
                };
            }
            // Create new user
            var user = new User()
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            // If success then return success code
            if (result.Succeeded)
            {
                // Generate confirm mail token and send to user
                SendConfirmMail(user);

                return new ResponseModel()
                {
                    Success = true,
                    Message = "Register success. Please confirm your email using link send to your email"
                };
            }
            return new ResponseModel()
            {
                Success = false,
                Message = string.Join(" ", result.Errors.Select(x => x.Description))
            };
        }
        #endregion

        #region Confirm email
        public async Task<ResponseModel> ConfirmEmail(string userId, string token)
        {
            // Check if user exist
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "User not found"
                };
            }
            // Check confirm email token
            var decodedToken = WebEncoders.Base64UrlDecode(token);
            var normalToken = Encoding.UTF8.GetString(decodedToken);
            var result = await _userManager.ConfirmEmailAsync(user, normalToken);
            if (result.Succeeded)
            {
                return new ResponseModel()
                {
                    Success = true,
                    Message = "Confirm email success"
                };
            }
            // If not success then return error message
            return new ResponseModel()
            {
                Success = false,
                Message = "Confirm email failed. " + string.Join(" ", result.Errors.Select(x => x.Description))
            };
        }
        #endregion

        #region Resend confirm email
        public async Task<ResponseModel> ResendConfirmEmail(string email)
        {
            // Find user by email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "No user exist with this email"
                };
            }
            // Resend confirm email
            SendConfirmMail(user);

            return new ResponseModel()
            {
                Success = true,
                Message = "Confirm email sent. Please check your email again"
            };
        }
        #endregion

        #region Forgot password
        public async Task<ResponseModel> ForgetPassword(string email)
        {
            // Check if user with this email exist
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "No user exist with this email"
                };
            }
            // Generate user reset password token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["ClientUrl"]}/User/ResetPassword?email={email}&token={validToken}";
            //await _mail.SendMail(user.Email, "Reset your password", $"<h1>Reset your password</h1><p>Please click this <a href={url}>link</a> to reset your password</p>");
            await _mail.SendMail(user.Email, "Reset your password", $"<h1>Reset your password</h1><p><span style='font-size:15.6px'>You have requested to reset your password.</span></p><p><span style='font-size:15.6px'>Please click on <a href='{url}'>this link</a>&nbsp;to reset your password</span></p><p><span style='font-size:15.6px'>If you didn't request that, you could ignore this email</span></p>");

            return new ResponseModel()
            {
                Success = true,
                Message = "Reset password link has been sent to email. Please check your email to continue"
            };
        }
        #endregion

        #region Reset password
        public async Task<ResponseModel> ResetPassword(ResetPasswordModel model)
        {
            // Find user by email
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "No user exist with this email"
                };
            }
            // Check if 2 password match
            if (!model.NewPassword.Equals(model.ConfirmPassword))
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "Password doesn't match"
                };
            }
            // Decode token and verify it
            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            var normalToken = Encoding.UTF8.GetString(decodedToken);
            var result = await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);
            if (result.Succeeded)
            {
                return new ResponseModel()
                {
                    Success = true,
                    Message = "Reset password success"
                };
            }
            // If not success then show error message
            return new ResponseModel()
            {
                Success = false,
                Message = string.Join(" ", result.Errors.Select(x => x.Description))
            };
        }
        #endregion

        #region Change password
        public async Task<ResponseModel> ChangePassword(string userId, ChangePasswordModel model)
        {
            // Find user by id
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "User not found"
                };
            }
            // Check if 2 new password match
            if (!model.NewPassword.Equals(model.ConfirmPassword))
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "Password doesn't match"
                };
            }
            // If everything correct then change user password
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                return new ResponseModel()
                {
                    Success = true,
                    Message = "Change password success"
                };
            }
            return new ResponseModel()
            {
                Success = false,
                Message = string.Join(" ", result.Errors.Select(x => x.Description))
            };
        }
        #endregion

        #region Get user info
        public async Task<ResponseModel> GetInfo(string userId)
        {
            // Check if user exist
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "User invalid"
                };
            }
            // Return user information
            return new ResponseModel()
            {
                Success = true,
                Message = "Get user info success",
                Data = new UserInfoModel()
                {
                    UserId = user.Id,
                    Name = user.Name,
                    Address = user.Address,
                    Phone = user.PhoneNumber,
                    Email = user.Email,
                    Avatar = user.Avatar,
                    Status = user.Status ?? 0
                }
            };
        }
        #endregion

        #region Get user list
        public async Task<ResponseModel> GetListUser()
        {
            try
            {
                return new ResponseModel()
                {
                    Success = true,
                    Message = "Get list user success",
                    Data = await _context.Users.ToListAsync()
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = ex.Message,
                    Data = await _context.Users.ToListAsync()
                };
            }
        }
        #endregion

        #region Update user information
        public async Task<ResponseModel> UpdateInfo(string userId, UpdateInfoModel model)
        {
            // Find user by id
            var user = await _userManager.FindByIdAsync(userId);
            // Change user properties
            user.Name = model.Name;
            user.Address = model.Address;
            user.PhoneNumber = model.Phone;
            user.WardId = model.WardId;
            user.DistrictId = model.DistrictId;
            user.CityId = model.CityId;
            // Update user to DB
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ResponseModel()
                {
                    Success = true,
                    Message = "Update user info success"
                };
            }
            return new ResponseModel()
            {
                Success = false,
                Message = "Update user info failed"
            };
        }
        #endregion

        #region Change avatar
        public async Task<ResponseModel> ChangeAvatar(string userId, string fileName)
        {
            // Find user by id
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "User not found"
                };
            }
            // Update user avatar to new value
            user.Avatar = fileName;
            // Save change
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ResponseModel()
                {
                    Success = true,
                    Message = "Update avatar success"
                };
            }
            // If error then show error message
            return new ResponseModel()
            {
                Success = false,
                Message = "Update avatar failed"
            };
        }
        #endregion

        #region Change status
        public async Task<ResponseModel> ChangeStatus(string userId, bool isActive)
        {
            // Find user by id
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "User not found"
                };
            }
            // Change status
            user.Status = isActive ? 1 : 0;
            // Update user
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ResponseModel()
                {
                    Success = true,
                    Message = "Change status success"
                };
            }
            return new ResponseModel()
            {
                Success = false,
                Message = "Change status failed"
            };
        }
        #endregion
    }
}

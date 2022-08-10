using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;
using System.Security.Claims;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Init Repository
        private readonly IAccountRepository _repos;
        public AccountController(IAccountRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region Login
        /// <summary>
        /// Login to account
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repos.LoginUser(model);
                if (result.Success)
                    return Ok(result);
                return BadRequest(result);
            }
            return BadRequest(new ResponseModel()
            {
                Success = false,
                Message = "Invalid data send to server"
            });
        }
        #endregion

        #region Login with Google
        /// <summary>
        /// Login using Google Account
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost("logingoogle")]
        public async Task<IActionResult> LoginGoogle(string token)
        {
            var result = await _repos.LoginGoogle(token);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region Register
        /// <summary>
        /// Register new account
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repos.RegisterUser(model);
                if (result.Success)
                    return Ok(result);
                return BadRequest(result);
            }
            return BadRequest(new ResponseModel()
            {
                Success = false,
                Message = "Invalid data send to server"
            });
        }
        #endregion

        #region Confirm email
        /// <summary>
        /// Confirm email
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
            {
                return BadRequest(new ResponseModel()
                {
                    Success = false,
                    Message = "Invalid data send to server"
                });
            }
            var result = await _repos.ConfirmEmail(userId, token);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region Resend confirm email
        /// <summary>
        /// Resend confirm email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("resendconfirm")]
        public async Task<IActionResult> ResendConfirmEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest(new ResponseModel()
                {
                    Success = false,
                    Message = "Email is empty"
                });
            }
            var result = await _repos.ResendConfirmEmail(email);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region Forget password
        /// <summary>
        /// Forget password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("forgetpassword")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest(new ResponseModel()
                {
                    Success = false,
                    Message = "Invalid data send to server"
                });
            }
            var result = await _repos.ForgetPassword(email);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region Reset password
        /// <summary>
        /// Reset user password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repos.ResetPassword(model);
                if (result.Success)
                    return Ok(result);                  
                return BadRequest(result);
            }
            return BadRequest(new ResponseModel()
            {
                Success = false,
                Message = "Invalid data send to server"
            });
        }
        #endregion

        #region Change password
        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
                var result = await _repos.ChangePassword(userId, model);
                if (result.Success)
                    return Ok(result);
                return BadRequest(result);
            }
            return BadRequest(new ResponseModel()
            {
                Success = false,
                Message = "Invalid data send to server"
            });
        }
        #endregion

        #region Get user info
        /// <summary>
        /// Get user info
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("getinfo")]
        public async Task<IActionResult> GetInfo()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest(new ResponseModel()
                {
                    Success = false,
                    Message = "User invalid"
                });
            }
            var result = await _repos.GetInfo(userId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region Get user info by id
        /// <summary>
        /// Get user info by id
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("getinfo/{userId}")]
        public async Task<IActionResult> GetInfoById(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest(new ResponseModel()
                {
                    Success = false,
                    Message = "User invalid"
                });
            }
            var result = await _repos.GetInfo(userId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region Update info
        /// <summary>
        /// Update user information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("updateinfo")]
        public async Task<IActionResult> UpdateInfo(UpdateInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
                var result = await _repos.UpdateInfo(userId, model);

                if (result.Success)
                    return Ok(result);
                return BadRequest(result);
            }
            return BadRequest(new ResponseModel()
            {
                Success = false,
                Message = "Invalid data send to server"
            });
        }
        #endregion

        #region Change avatar
        /// <summary>
        /// Change avatar
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("changeavatar")]
        public async Task<IActionResult> ChangeAvatar(string fileName)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            var result = await _repos.ChangeAvatar(userId, fileName);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region Change status
        [Authorize]
        [HttpPost("changestatus")]
        public async Task<IActionResult> ChangeStatus(bool isActive)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            var result = await _repos.ChangeStatus(userId, isActive);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion
    }
}

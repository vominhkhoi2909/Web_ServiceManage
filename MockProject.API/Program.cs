using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MockProject.API;
using MockProject.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.Reponsitory.Interface;
using Microsoft.AspNetCore.Authorization;
using MockProject.API.Reponsitory.Services;
using System.Reflection;

#region Builder
var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "WEBAPI",
            policy =>
            {
                policy.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
            });
});

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Cấu hình DB Context
builder.Services.AddDbContext<iHomeContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
});
// Cấu hình Identity
builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<iHomeContext>()
.AddDefaultTokenProviders();
// Cấu hình Authentication sử dụng JWT
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
        ValidateIssuerSigningKey = true
    };
}).AddJwtBearer("AdminJWT", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:AudienceAdmin"],
        ValidIssuer = builder.Configuration["JWT:IssuerAdmin"],
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:KeyAdmin"])),
        ValidateIssuerSigningKey = true
    };
}).AddGoogle(options =>
{
    options.ClientId = "264045962571-uu8t8ql3lls0rjeco4bvn4pdghsffpud.apps.googleusercontent.com";
    options.ClientSecret = "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";
});

#endregion

#region Khai báo Repository
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IConfigRepository, ConfigRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IJobOrderRepository, JobOrderRepository>();
builder.Services.AddScoped<IJobOrderDetailRepository, JobOrderDetailRepository>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IOptionRepository, OptionRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ISliderRepository, SliderRepository>();
builder.Services.AddScoped<IVanRepository, VanRepository>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IMailRepository, MailRepository>();
#endregion

#region App
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Allow CORS
app.UseCors("WEBAPI");

app.MapControllers();

app.Run();
#endregion

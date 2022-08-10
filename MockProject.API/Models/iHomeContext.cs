using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class iHomeContext : IdentityDbContext<User>
    {
        public iHomeContext(DbContextOptions options): base(options)
        {
            
        }

        #region Khai báo models.
        public DbSet<AdminUser>? tAdminUsers { get; set; }
        public DbSet<Config>? tConfigs { get; set; }
        public DbSet<Contact>? tContacts { get; set; }
        public DbSet<JobOrder>? tJobOrders { get; set; }
        public DbSet<JobOrderDetail>? tJobOrderDetails { get; set; }
        public DbSet<Log>? tLog { get; set; }
        public DbSet<Note>? tNotes { get; set; }
        public DbSet<Notification>? tNotifications { get; set; }
        public DbSet<Option>? tOptions { get; set; }
        public DbSet<Permission>? tPermissions { get; set; }
        public DbSet<PermissionDetail>? tPermissionDetails { get; set; }
        public DbSet<Promotion>? tPromotions { get; set; }
        public DbSet<Province>? tProvinces { get; set; }
        public DbSet<Review>? tReviews { get; set; }
        public DbSet<Role>? tRoles { get; set; }
        public DbSet<Service>? tServices { get; set; }
        public DbSet<Slider>? tSliders { get; set; }
        public DbSet<User>? tUsers { get; set; }
        public DbSet<Van>? tVans { get; set; }
        public DbSet<Comment>? tComments { get; set; }
        #endregion

        //Link để Migration tìm đến để tạo db khi Update-Database.
        #region Connection String.
        //link khởi tạo db xài chung.
        //private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_iHome;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //link khởi tạo db xài cho sql server cá nhân. Lúc dùng nhớ đổi lại 'Server=cvpkhoivm1-2' bằng tên sql server của bản thân.
        //private const string connectionString = @"Server=cvpkhoivm1-2;Initial Catalog=DB_iHomeTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        #endregion

        #region Định dạng khởi tạo cho Migration.
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
            .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Debug)
            .AddConsole();
        });

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
        #endregion

        #region Định dạng bảng bằng fluent.
        //Định dạng table khi mirgration.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Gán PK cho 3 trường.
            modelBuilder.Entity<Province>()
                .HasKey(a => new { a.CityId, a.DistrictId, a.WardId });
        }
        #endregion
    }
}

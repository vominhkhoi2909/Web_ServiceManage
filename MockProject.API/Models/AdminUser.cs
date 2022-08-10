using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class AdminUser
    {
        #region PK
        [Key]
        public int UserId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "nvarchar(max)")]
        public string? FullName { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Phone { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Address { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Username { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string PasswordHash { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string PasswordSalt { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Avatar { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? ResetToken { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ResetTokenExpire { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Permission { get; set; }
        
        #endregion

        #region FK
        [NotMapped]
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }
        #endregion

        #region FK(1-N)
        public virtual ICollection<Van>? Vans { get; set; }
        public virtual ICollection<Note>? Notes { get; set; }
        //public virtual ICollection<Notification>? Notifications { get; set; }
        public virtual ICollection<Log>? Logs { get; set; }
        #endregion
    }
}

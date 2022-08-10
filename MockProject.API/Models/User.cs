using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class User : IdentityUser
    {
        #region Column
        [Column(TypeName = "nvarchar(max)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Address { get; set; }
        [Column(TypeName = "int")]
        public int? WardId { get; set; }
        [Column(TypeName = "int")]
        public int? DistrictId { get; set; }
        [Column(TypeName = "int")]
        public int? CityId { get; set; }
        [Column(TypeName = "int")]
        public int? Status { get; set; } = 1;
        [Column(TypeName = "nvarchar(max)")]
        public string? Avatar { get; set; } = "default.png";
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        #endregion

        #region FK (1-N)
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<JobOrder>? JobOrders { get; set; }
        //public virtual ICollection<Notification>? Notifications { get; set; }
        #endregion
    }
}

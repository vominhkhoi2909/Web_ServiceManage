using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Role
    {
        #region PK
        [Key]
        public int RoleId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "nvarchar(max)")]
        public string Name { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion

        #region FK (1-N)
        public virtual ICollection<AdminUser>? AdminUsers { get; set; }
        public virtual ICollection<PermissionDetail>? PermissionDetails { get; set; }
        #endregion
    }
}

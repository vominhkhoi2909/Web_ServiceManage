using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class PermissionDetail
    {
        #region PK
        [Key]
        public int PermissionDetailId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion

        #region FK
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }
        public int PermissionId { get; set; }
        [ForeignKey("PermissionId")]
        public virtual Permission? Permission { get; set; }
        #endregion
    }
}

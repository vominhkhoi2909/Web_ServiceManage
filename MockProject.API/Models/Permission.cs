using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Permission
    {
        #region PK
        [Key]
        public int PermissionId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "nvarchar(max)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Link { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion

        #region FK (1-N)
        public virtual ICollection<PermissionDetail>? PermissionDetails { get; set; }
        #endregion
    }
}

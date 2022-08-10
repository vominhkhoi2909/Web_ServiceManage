using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Log
    {
        #region PK
        [Key]
        public int LogId { get; set; }
        #endregion

        #region Column       
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Image { get; set; }
        [Column(TypeName = "int")]
        public int Type { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion

        #region FK
        public int CreateBy { get; set; }
        [ForeignKey("CreateBy")]
        public virtual AdminUser? AdminUser { get; set; }
        #endregion
    }
}

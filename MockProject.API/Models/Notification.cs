using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Notification
    {
        #region PK
        [Key]
        public int NotifId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Link { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Image { get; set; }
        [Column(TypeName = "int")]
        public int Type { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion

        #region FK
        public string SendTo { get; set; } = null!;
        //[ForeignKey("SendTo")]
        //public virtual User User { get; set; } = null!;

        public int CreateBy { get; set; }
        //[ForeignKey("CreateBy")]
        //public virtual AdminUser? AdminUser { get; set; }
        #endregion

        #region FK (1-N)
        public virtual ICollection<Comment>? Comments { get; set; }
        #endregion
    }
}

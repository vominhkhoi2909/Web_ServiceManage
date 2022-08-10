using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Comment
    {
        #region PK
        [Key]
        public int CommentId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "nvarchar(max)")]
        public string CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Title { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion

        #region FK
        public int NotifId { get; set; }
        [ForeignKey("NotifId")]
        public virtual Notification? Notification { get; set; }
        #endregion
    }
}

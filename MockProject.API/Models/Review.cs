using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Review
    {
        #region PK
        [Key]
        public int ReviewId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "int")]
        public float RatingScore { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion

        #region FK
        public string CreateBy { get; set; } = null!;
        [ForeignKey("CreateBy")]
        public virtual User User { get; set; } = null!;
        #endregion
    }
}

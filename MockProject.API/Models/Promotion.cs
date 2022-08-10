using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Promotion
    {
        #region PK
        [Key]
        public int PromotionId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "nvarchar(max)")]
        public string Title { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateEnd { get; set; }
        [Column(TypeName = "float")]
        public float? DiscountPercent { get; set; }
        [Column(TypeName = "float")]
        public float? DiscountMoney { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Discription { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Image { get; set; }
        [Column(TypeName = "int")]
        public int ParentServiceId { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion
    }
}

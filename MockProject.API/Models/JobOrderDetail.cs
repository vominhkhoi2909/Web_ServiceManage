using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class JobOrderDetail
    {
        #region PK
        [Key]
        public int JODetailId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "int")]
        public int Quantily { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Image { get; set; }
        [Column(TypeName = "float")]
        public float Price { get; set; }
        #endregion

        #region FK
        public int OptionId { get; set; }
        [ForeignKey("OptionId")]
        public virtual Option? Option { get; set; }
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public virtual Service? Service { get; set; }
        public int JOId { get; set; }
        [ForeignKey("JOId")]
        public virtual JobOrder? JobOrder { get; set; }
        #endregion
    }
}

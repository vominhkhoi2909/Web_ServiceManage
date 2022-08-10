using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class JobOrder
    {
        #region PK
        [Key]
        public int JOId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "float")]
        public float Duration { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartAt { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Address { get; set; }
        [Column(TypeName = "int")]
        public int WardId { get; set; }
        [Column(TypeName = "int")]
        public int DistrictId { get; set; }
        [Column(TypeName = "int")]
        public int CityId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Column(TypeName = "int")]
        public int? State { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion

        #region FK
        public int? StaffId { get; set; }
        [ForeignKey("StaffId")]
        public virtual AdminUser? AdminUser { get; set; }

        public string CustomerId { get; set; } = null!;
        [ForeignKey("CustomerId")]
        public virtual User User { get; set; } = null!;
        #endregion

        #region FK (1-N)
        public virtual ICollection<JobOrderDetail>? JobOrderDetails { get; set; }
        #endregion
    }
}

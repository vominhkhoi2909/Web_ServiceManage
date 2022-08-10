using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Service
    {
        #region PK
        [Key]
        public int ServiceId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "nvarchar(max)")]
        public string Name { get; set; }
        //Type 1 = ParentService (Aircon)     | 2 = ParentService (Mattress)  | 3 = ParentService (Misc)
        [Column(TypeName = "int")]
        public int Type { get; set; }
        [Column(TypeName = "float")]
        public float Price { get; set; }
        [Column(TypeName = "float")]
        public float Duration { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion

        #region FK (1-N)
        public virtual ICollection<JobOrderDetail>? JobOrderDetails { get; set; }
        #endregion
    }
}

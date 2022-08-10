using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Option
    {
        #region PK
        [Key]
        public int OptionId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "nvarchar(max)")]
        public string Title { get; set; }
        //Type 1 = ParentService (Aircon)     | 2 = ParentService (Mattress)  | 3 = ParentService (Misc)
        //     4 = Aircon Brands              | 5 = Mattress Size             | 6 = User Cancellation Reason
        //     7 = User Delete Account Reason | 8 = Staff Cancellation Reason | 9 = About us
        [Column(TypeName = "int")]
        public int Type { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Image { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion
    }
}

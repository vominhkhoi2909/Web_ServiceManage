using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Province
    {
        #region PK
        public int CityId { get; set; }
        public int WardId { get; set; }
        public int DistrictId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "nvarchar(max)")]
        public int? CityName { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public int? WardName { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public int? DistrictName { get; set; }
        #endregion
    }
}

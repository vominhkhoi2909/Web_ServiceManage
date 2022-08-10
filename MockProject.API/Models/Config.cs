using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Config
    {
        #region PK
        [Key]
        public int ConfigId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "nvarchar(max)")]
        public string Key { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Value { get; set; }

        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion
    }
}

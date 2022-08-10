using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Slider
    {
        #region PK
        [Key]
        public int SliderId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "nvarchar(max)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Alt { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Image { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Link { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion
    }
}

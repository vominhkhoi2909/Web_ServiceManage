using MockProject.API.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockProject.API.Models
{
    public class Contact
    {
        #region PK
        [Key]
        public int ContactId { get; set; }
        #endregion

        #region Column
        [Column(TypeName = "nvarchar(max)")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Column(TypeName = "int")]
        public int ParentServiceId { get; set; }
        [Column(TypeName = "int")]
        public int Status { get; set; }
        #endregion
    }
}

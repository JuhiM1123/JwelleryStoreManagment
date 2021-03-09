using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JwelleryStore.DAL.Entities
{
    public class UserDetail
    {
        public int UserDetailId { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }
        public int RoleId { get; set; }
        [Required]
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

    }
}

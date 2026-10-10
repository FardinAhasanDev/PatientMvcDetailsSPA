using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientMvcDetailsSPA.Models
{
    public class tbl_User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "User Name is required.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class tbl_Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Role Name is required.")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }

    public class tbl_UserRole
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}

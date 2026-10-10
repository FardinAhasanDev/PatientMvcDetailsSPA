using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientMvcDetailsSPA.ViewModels
{
    public class RoleCheckBoxSelection
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsAssigned { get; set; }
    }

    public class ManageUserRoleViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<RoleCheckBoxSelection> UserRoles { get; set; } = new List<RoleCheckBoxSelection>();
    }
}

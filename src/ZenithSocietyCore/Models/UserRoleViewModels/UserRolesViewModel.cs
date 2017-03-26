using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZenithSocietyCore.Models.UserRolesViewModel;

namespace ZenithSocietyCore.Models.UserRolesViewModel
{
    public class UserRoleViewModel
    {
        [Display(Name = "Username")]
        public string Username { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Roles")]
        public ICollection<String> Roles { get; set; }

        // The selected role to add or delete from a user 
        [Required]
        [Display(Name = "Select Role")]
        public string SelectedRole { get; set; }
    }
}
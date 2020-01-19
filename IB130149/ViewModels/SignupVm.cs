using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IB130149.ViewModels
{
    public class SignupVm
    {
        [Required]
        [StringLength(20, ErrorMessage = "Username field must contain at least 3 characters", MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Password field must contain at least 4 characters", MinimumLength = 4)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password needs to match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Telephone { get; set; }

        public bool IsClient { get; set; }
    }
}

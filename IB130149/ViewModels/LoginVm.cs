using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IB130149.ViewModels
{
    public class LoginVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Username field must contain at least 3 characters.", MinimumLength = 3)]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Password field must contain at least 4 characters.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IB130149.ViewModels
{
    public class ProfileUpdateVm
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Username field must contain at least 3 characters.", MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password field must contain at least 4 characters.", MinimumLength = 4)]
        public string OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}

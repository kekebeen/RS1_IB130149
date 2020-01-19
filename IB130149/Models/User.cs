using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IB130149.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public bool isClient { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}

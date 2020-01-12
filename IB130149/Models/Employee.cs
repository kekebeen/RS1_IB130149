using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IB130149.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public DateTime ContractStart { get;set; }
        public DateTime ContractEnd { get; set; }
        public bool? isAdmin { get; set; }
        public bool? isRepairman { get; set; }
        public bool? isSeller { get; set; }
    }
}

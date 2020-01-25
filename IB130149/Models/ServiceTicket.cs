using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IB130149.Models
{
    public class ServiceTicket
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? RequestDoneDate { get; set; }
        public int StatusId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
        public virtual User Customer { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(ServiceRequestId))]
        public int ServiceRequestId { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }
        public string Note { get; set; }
    }
}

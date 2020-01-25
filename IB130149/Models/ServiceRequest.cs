using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IB130149.Models
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string DeliveryAddress { get; set; }
        public int RequestedById { get; set; }
        [ForeignKey(nameof(RequestedById))]
        public virtual User Client { get; set; }
        public string? Impression { get; set; }
        public bool IncludeHomeService { get; set; }
        public bool IncludeDelivery { get; set; }
        public bool IncludeCustomerPickup { get; set; }
    }
}

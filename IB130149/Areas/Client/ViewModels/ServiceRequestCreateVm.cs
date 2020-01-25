using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IB130149.Areas.Client.ViewModels
{

    public class ServiceRequestCreateVm
    {
        [Required]
        [StringLength(100, ErrorMessage = "Address field must have at least three characters.", MinimumLength = 3)]
        public string Address { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [Required]
        public int RequestedById { get; set; }
        public string? Impression { get; set; }
        [DefaultValue(false)]
        public bool IncludeHomeService { get; set; }
        [DefaultValue(false)]
        public bool IncludeDelivery { get; set; }
        [DefaultValue(false)]
        public bool IncludeCustomerPickup { get; set; }
    }
}

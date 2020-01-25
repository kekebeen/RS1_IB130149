using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace IB130149.Areas.Client.ViewModels
{
    public class ServiceRequestVm
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string DeliveryAddress { get; set; }
            [DefaultValue(false)]
            public bool IncludeHomeService { get; set; }
            [DefaultValue(false)]
            public bool IncludeDelivery { get; set; }
            [DefaultValue(false)]
            public bool IncludeCustomerPickup { get; set; }
            public string Status { get; set; }
    }
}

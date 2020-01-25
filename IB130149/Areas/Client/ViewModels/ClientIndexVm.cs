using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IB130149.Areas.Client.ViewModels
{
    public class ClientIndexVm
    {
        // initial client service request list
        // it consists of client list of rows
        public string? DeliveryAddress { get; set; } // latest request note
        public string? Status { get; set; } // latest request status
        public List<ServiceRequestVm> ClientServiceRequests { get; set; }
    }
}

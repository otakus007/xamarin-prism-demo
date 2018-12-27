using System.Collections.Generic;
using PriceSetting.Models;

namespace PriceSetting.Responses
{
    public class CustomerResponse
    {
        public IEnumerable<Customer> customers { get; set; }
        public Status Status { get; set; }
    }
}

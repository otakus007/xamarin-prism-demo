using System.Collections.Generic;
using PriceSetting.Models;

namespace PriceSetting.Responses
{
    public class ProductResponse
    {
        public IEnumerable<Product> products { get; set; }
        public Status Status { get; set; }
    }
}

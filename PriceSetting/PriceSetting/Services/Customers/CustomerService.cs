using System;
using System.Threading.Tasks;
using PriceSetting.Responses;

namespace PriceSetting.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRequestsService _requestService;

        public CustomerService(IRequestsService requestsService)
        {
            _requestService = requestsService;
        }

        public async Task<CustomerResponse> GetCustomersAsync()
        {
            UriBuilder builder = new UriBuilder($"{Setting.CustomerEndpoint}");

            var url = builder.ToString();

            return await _requestService.GetAsync<CustomerResponse>(url);
        }
    }
}

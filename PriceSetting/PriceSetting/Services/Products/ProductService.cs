using System;
using System.Threading.Tasks;
using PriceSetting.Responses;

namespace PriceSetting.Services
{
    public class ProductService : IProductService
    {
        private readonly IRequestsService _requestService;

        public ProductService(IRequestsService requestsService)
        {
            _requestService = requestsService;
        }

        public async Task<ProductResponse> GetProductsAsync()
        {
            UriBuilder builder = new UriBuilder($"{Setting.ProductEndpoint}");

            var url = builder.ToString();

            return await _requestService.GetAsync<ProductResponse>(url);
        }
    }
}

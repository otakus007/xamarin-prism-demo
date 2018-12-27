using System.Threading.Tasks;
using PriceSetting.Responses;

namespace PriceSetting.Services
{
    public interface IProductService
    {
        Task<ProductResponse> GetProductsAsync();
    }
}

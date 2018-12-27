using System.Threading.Tasks;
using PriceSetting.Responses;

namespace PriceSetting.Services
{
    public interface ICustomerService
    {
        Task<CustomerResponse> GetCustomersAsync();
    }
}

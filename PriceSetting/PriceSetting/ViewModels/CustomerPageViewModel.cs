#region

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Navigation;
using PriceSetting.Models;
using PriceSetting.Services;
using PriceSetting.Responses;

#endregion

namespace PriceSetting.ViewModels
{
    public class CustomerPageViewModel : ViewModelBase
    {

        #region Properties

        private readonly ICustomerService _customerService;

        private CustomerResponse _customerResponse;
        public CustomerResponse CustomerResponse
        {
            get => _customerResponse;
            set => SetProperty(ref _customerResponse, value);
        }

        private IEnumerable<Customer> _customers;
        public IEnumerable<Customer> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        #endregion

        #region Constructor

        public CustomerPageViewModel(INavigationService navigationService, ICustomerService customerService)
            : base(navigationService)
        {
            _customerService = customerService;
        }

        #endregion

        #region Navigation

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await LoadCustomers();
        }

        #endregion

        #region Command

        public ICommand LoadCustomerCommand => new Command(async () => { await LoadCustomers(); });

        #endregion

        #region Function

        private async Task LoadCustomers()
        {
            if (IsBusy) return;
            IsBusy = true;
            CustomerResponse = await _customerService.GetCustomersAsync();
            Customers = CustomerResponse.customers;
            IsBusy = false;
        }

        #endregion
    }
}


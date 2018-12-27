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
    public class ProductPageViewModel : ViewModelBase
    {
        #region Properties

        private readonly IProductService _productService;

        private ProductResponse _productResponse;
        public ProductResponse ProductResponse
        {
            get => _productResponse;
            set => SetProperty(ref _productResponse, value);
        }

        private IEnumerable<Product> _products;
        public IEnumerable<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        #endregion

        #region Constructor

        public ProductPageViewModel(INavigationService navigationService, IProductService productService)
            : base(navigationService)
        {
            _productService = productService;
        }

        #endregion

        #region Navigation

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await LoadProducts();
        }

        #endregion

        #region Command

        public ICommand LoadProductCommand => new Command(async () => { await LoadProducts(); });

        #endregion

        #region Function

        private async Task LoadProducts()
        {
            if (IsBusy) return;
            IsBusy = true;
            ProductResponse = await _productService.GetProductsAsync();
            Products = ProductResponse.products;
            IsBusy = false;
        }

        #endregion
    }
}

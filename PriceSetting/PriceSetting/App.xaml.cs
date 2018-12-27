#region Using

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PriceSetting.Services;
using PriceSetting.Views;
using Prism.Ioc;
using Prism.Autofac;

#endregion

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PriceSetting
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(Prism.IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(new System.Uri("/MasterPage/NavigationPage/CustomerPage"));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            #region Register View

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MasterPage>();

            containerRegistry.RegisterForNavigation<CustomerPage>();
            containerRegistry.RegisterForNavigation<ProductPage>();

            #endregion

            #region Register Services

            containerRegistry.Register<IRequestsService, RequestsService>();
            containerRegistry.Register<ICustomerService, CustomerService>();
            containerRegistry.Register<IProductService, ProductService>();

            #endregion
        }
    }
}

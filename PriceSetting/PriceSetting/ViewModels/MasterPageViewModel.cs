#region Using

using System;
using Prism.Commands;
using Prism.Navigation;

#endregion

namespace PriceSetting.ViewModels
{
    public class MasterPageViewModel : ViewModelBase
    {
        public DelegateCommand<string> OnNavigateCommand { get; set; }

        public MasterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            OnNavigateCommand = new DelegateCommand<string>(NavigateAsync);
        }

        private async void NavigateAsync(string page)
        {
            await NavigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }
    }
}

#region Using

using Prism.Navigation;
using Xamarin.Forms;

#endregion

namespace PriceSetting.Views
{
    public partial class MasterPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation
        {
            get { return false; }
        }
    }
}

using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace PriceSetting
{
    public static class Setting
    {
        //Endpoints
        private const string DefaultApiEndpoint = "http://apps.japfavietnam.com:62048/api/";
        private const string CustomerUri = "customers";
        private const string ProductUri = "products";
        private const string TemplatePriceUri = "templatePrice";

        private static ISettings Settings => CrossSettings.Current;

        public static string CustomerEndpoint
        {
            get => Settings.GetValueOrDefault(nameof(CustomerEndpoint), DefaultApiEndpoint + CustomerUri);

            set => Settings.AddOrUpdateValue(nameof(CustomerEndpoint), value);
        }

        public static string ProductEndpoint
        {
            get => Settings.GetValueOrDefault(nameof(ProductEndpoint), DefaultApiEndpoint + ProductUri);

            set => Settings.AddOrUpdateValue(nameof(ProductEndpoint), value);
        }

        public static string TemplatePriceEndpoint
        {
            get => Settings.GetValueOrDefault(nameof(TemplatePriceEndpoint), DefaultApiEndpoint + TemplatePriceUri);

            set => Settings.AddOrUpdateValue(nameof(TemplatePriceEndpoint), value);
        }
    }
}

using System;
namespace PriceSetting.Models
{
    public class TemplatePrice
    {
        public string PRODUCTID { get; set; }
        public string NAME_VN { get; set; }
        public string MEASURECODE { get; set; }
        public string PRODTYPE { get; set; }
        public decimal? VAT { get; set; }
        public string STROPERATOR { get; set; }
        public decimal? VALUE { get; set; }
        public decimal? PRICE { get; set; }
        public string ID { get; set; }
        public decimal? BYRANGE { get; set; }
        public string UNITID { get; set; }
        public decimal? COMPAREBY { get; set; }
    }
}

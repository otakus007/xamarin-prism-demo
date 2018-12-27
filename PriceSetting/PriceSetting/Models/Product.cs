using System;
namespace PriceSetting.Models
{
    public class Product
    {
        public string PRODUCTID { get; set; }
        public string NAME_VN { get; set; }
        public string MEASURECODE { get; set; }
        public string MEASURENAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string PRODTYPE { get; set; }
        public string ACTIVE { get; set; }
        public decimal? VAT { get; set; }
        public string USERCREATE { get; set; }
        public DateTime? CREATEDATE { get; set; }
    }
}

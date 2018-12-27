using System;
namespace PriceSetting.Models
{
    public class Customer
    {
        public string CUSTOMERID { get; set; }
        public string CUSTNAME { get; set; }
        public string ADDRESS { get; set; }
        public string TEL { get; set; }
        public string IDCARD { get; set; }
        public DateTime? IDCARDDATE { get; set; }
        public string BANKNAME { get; set; }
        public string BANKACCOUNT { get; set; }
        public string ISBUSINESS { get; set; }
        public string ISGENERAL { get; set; }
        public string USERCREATE { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string ACTIVE { get; set; }
    }
}

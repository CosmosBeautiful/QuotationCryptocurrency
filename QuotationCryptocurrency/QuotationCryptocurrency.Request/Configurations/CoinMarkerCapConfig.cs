namespace QuotationCryptocurrency.Request.Configurations
{
    public class CoinMarkerCapConfig
    {
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }
        public int StartElem { get; set; }
        public int LimitElem { get; set; }
        public string Currency { get; set; }
    }
}

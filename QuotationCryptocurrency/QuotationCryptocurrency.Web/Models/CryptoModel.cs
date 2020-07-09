namespace QuotationCryptocurrency.Web.Models
{
    public class CryptoModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public CryptoModel()
        {
        }

        public CryptoModel(QuotationModel quotation)
        {
            Id = quotation.CryptoId;
            Name = quotation.Name;
            Symbol = quotation.Symbol;
        }
    }
}

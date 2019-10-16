using System;

namespace QuotationCryptocurrency.Business.DTO
{
    public class CryptoDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public CryptoDTO()
        {
        }

        public CryptoDTO(QuotationDTO quotation)
        {
            Id = quotation.CryptoId;
            Name = quotation.Name;
            Symbol = quotation.Symbol;
        }
    }
}

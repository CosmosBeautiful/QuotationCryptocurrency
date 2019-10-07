using System;

namespace QuotationCryptocurrency.FilterModels.Quotation
{
    public class QuotationFilters
    {
        public string SelectedName { get; set; } = "";
        public string SelectedSymbol { get; set; } = "";

        public QuotationFilters()
        {
        }

        public QuotationFilters(string name = "", string symbol = "")
        {
            SelectedName = name;
            SelectedSymbol = symbol;
        }
    }
}

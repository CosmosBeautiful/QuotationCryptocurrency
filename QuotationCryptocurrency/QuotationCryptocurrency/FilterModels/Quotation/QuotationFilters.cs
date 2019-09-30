using System;

namespace QuotationCryptocurrency.FilterModels.Quotation
{
    public class QuotationFilters
    {
        public string SelectedName { get; private set; }

        public QuotationFilters(string name = "")
        {
            SelectedName = name;
        }
    }
}

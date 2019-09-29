using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Quotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotationCryptocurrency.FilterModels.CryptocurrencyQuotation
{
    public class CryptocurrencyQuotationViewModel : IndexViewModel
    {
        public CryptocurrencyQuotationSortModel SortModel { get; set; }

        public CryptocurrencyQuotationViewModel(IEnumerable<IModel> models, int page, CryptocurrencyQuotationSortType sortType) 
            : base(models, page)
        {
            SortModel = new CryptocurrencyQuotationSortModel(sortType);
            Models = GetSortModel(models, sortType);
        }

        private IEnumerable<IModel> GetSortModel(IEnumerable<IModel> models, CryptocurrencyQuotationSortType sortType)
        {
            IEnumerable<IModel> sortModels; 
            var CQModel = models.Cast<CryptocurrencyQuotationModel>();

            switch (sortType)
            {
                case CryptocurrencyQuotationSortType.IdAsc:
                    sortModels = CQModel.OrderBy(s => s.Id);
                    break;
                case CryptocurrencyQuotationSortType.IdDesc:
                    sortModels = CQModel.OrderByDescending(s => s.Id);
                    break;
                case CryptocurrencyQuotationSortType.NameAsc:
                    sortModels = CQModel.OrderBy(s => s.Name);
                    break;
                case CryptocurrencyQuotationSortType.NameDesc:
                    sortModels = CQModel.OrderByDescending(s => s.Name);
                    break;
                case CryptocurrencyQuotationSortType.SymbolAsc:
                    sortModels = CQModel.OrderBy(s => s.Symbol);
                    break;
                case CryptocurrencyQuotationSortType.SymbolDesc:
                    sortModels = CQModel.OrderByDescending(s => s.Symbol);
                    break;
                case CryptocurrencyQuotationSortType.PriceAsc:
                    sortModels = CQModel.OrderBy(s => s.Price);
                    break;
                case CryptocurrencyQuotationSortType.PriceDesc:
                    sortModels = CQModel.OrderByDescending(s => s.Price);
                    break;
                case CryptocurrencyQuotationSortType.PercentChange1hAsc:
                    sortModels = CQModel.OrderBy(s => s.PercentChange1h);
                    break;
                case CryptocurrencyQuotationSortType.PercentChange1hDesc:
                    sortModels = CQModel.OrderByDescending(s => s.PercentChange1h);
                    break;
                case CryptocurrencyQuotationSortType.PercentChange24hAsc:
                    sortModels = CQModel.OrderBy(s => s.PercentChange24h);
                    break;
                case CryptocurrencyQuotationSortType.PercentChange24hDesc:
                    sortModels = CQModel.OrderByDescending(s => s.PercentChange24h);
                    break;
                case CryptocurrencyQuotationSortType.MarketCapAsc:
                    sortModels = CQModel.OrderBy(s => s.MarketCap);
                    break;
                case CryptocurrencyQuotationSortType.MarketCapDesc:
                    sortModels = CQModel.OrderByDescending(s => s.MarketCap);
                    break;
                case CryptocurrencyQuotationSortType.LastUpdatedAsc:
                    sortModels = CQModel.OrderBy(s => s.LastUpdated);
                    break;
                case CryptocurrencyQuotationSortType.LastUpdatedDesc:
                    sortModels = CQModel.OrderByDescending(s => s.LastUpdated);
                    break;
                default:
                    sortModels = models;
                    break;
            }

            return sortModels;
        }
    }
}

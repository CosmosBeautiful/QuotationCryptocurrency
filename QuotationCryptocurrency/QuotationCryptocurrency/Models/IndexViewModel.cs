using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotationCryptocurrency.Models
{
    public class IndexViewModel
    {
        public IEnumerable<IModel> Models { get; set; }
        public PageNavigation PageNavigation { get; set; }

        public IndexViewModel(IEnumerable<IModel> models, int page)
        {
            PageNavigation = new PageNavigation(models.Count(), page);
            Models = models.Skip((page - 1) * PageNavigation.PageSize).Take(PageNavigation.PageSize).ToList();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using QuotationCryptocurrency.Models;

namespace QuotationCryptocurrency.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public string PageAction { get; set; }

        public QuotationViewModel Model { get; set; }

        public IUrlHelperFactory UrlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            UrlHelperFactory = helperFactory;
        }
    
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = UrlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "nav";

            TagBuilder tag = new TagBuilder("ul");
            tag.AddCssClass("pagination");

            TagBuilder currentItem = CreatePageItem(Model.PaginationModel.PageNumber, urlHelper);
            if (Model.PaginationModel.HasPreviousPage)
            {
                TagBuilder prevItem = CreatePageItem(Model.PaginationModel.PageNumber - 1, urlHelper);
                tag.InnerHtml.AppendHtml(prevItem);
            }

            tag.InnerHtml.AppendHtml(currentItem);
            if (Model.PaginationModel.HasNextPage)
            {
                TagBuilder nextItem = CreatePageItem(Model.PaginationModel.PageNumber + 1, urlHelper);
                tag.InnerHtml.AppendHtml(nextItem);
            }
            output.Content.AppendHtml(tag);
        }

        TagBuilder CreatePageItem(int pageNumber, IUrlHelper urlHelper)
        {
            TagBuilder item = new TagBuilder("li");
            item.AddCssClass("page-item");

            TagBuilder link = new TagBuilder("a");
            link.AddCssClass("page-link");

            if (pageNumber == Model.PaginationModel.PageNumber)
            {
                item.AddCssClass("active");
            }
            else
            {
                link.Attributes["href"] = urlHelper.Action(PageAction, new { pageNumber, sortOrder = Model.SortModel, name = Model.FilterData.Name, symbol = Model.FilterData.Symbol });
            }
            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);
            return item;
        }
    }
}

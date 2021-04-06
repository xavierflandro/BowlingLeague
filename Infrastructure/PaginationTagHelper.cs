using BowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo;
        //  initialization of IUrlHelperFactory in constructor
        public PaginationTagHelper(IUrlHelperFactory uhf)
        {
            urlInfo = uhf;
        }


        public PagingInfo PageInfo { get; set; }


        //  Build dictionary of attributes
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> CustAttrDict { get; set; } = new Dictionary<string, object>();


        //  Setup View Context
        [ViewContext] [HtmlAttributeNotBound] 
        public ViewContext ViewContext { get; set; }



        //   Required override function
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelp = urlInfo.GetUrlHelper(ViewContext);

            TagBuilder wrapperTag = new TagBuilder("div");

            for (int i = 1; i <= PageInfo.NumPages; i++)
            {
                //  Build and populate "a" tags with asp-action attr
                TagBuilder aTag = new TagBuilder("a");
                CustAttrDict["pageNum"] = i;
                aTag.Attributes["href"] = urlHelp.Action("Index", CustAttrDict);
                aTag.InnerHtml.Append(i.ToString());

                //  Add "a" tag to wrapper tag
                wrapperTag.InnerHtml.AppendHtml(aTag);
            }
            //  Define output
            output.Content.AppendHtml(wrapperTag.InnerHtml);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sauna.Pages.Abstractions.Extensions
{
    public static class DropDownHtml
    {
        public static IHtmlContent DropDown<TModel, TResult>(
            this IHtmlHelper<TModel> h, 
            Expression<Func<TModel, TResult>> e,
            IEnumerable<SelectListItem> items) {

            var s = HtmlStrings(h, e, items);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings<TModel, TResult>(
            IHtmlHelper<TModel> h, 
            Expression<Func<TModel, TResult>> e, 
            IEnumerable<SelectListItem> items) {

            return new List<object> {
                new HtmlString("<div class=\"form-group\">"), 
                h.LabelFor(e, new {@class = "text-light"}),
                h.DropDownListFor(e, items, new {@class = "form-control"}),
                h.ValidationMessageFor(e, "", new {@class = "text-danger"}),
                new HtmlString("</div>")
            };
        }
    }
}
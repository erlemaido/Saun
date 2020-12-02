using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sauna.Pages.Abstractions.Extensions
{
    public static class ShowHtml
    {
        public static IHtmlContent Show<TModel, TResult>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) 
        {
            if (h == null) throw new ArgumentNullException(nameof(h));

            var s = HtmlStrings(h, e);

            return new HtmlContentBuilder(s);
        }

        public static IHtmlContent Show<TModel, TResult>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, string value) 
        {
            if (h == null) throw new ArgumentNullException(nameof(h));

            var s = HtmlStrings(h, e, value);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) 
        {
            return new List<object> {
                new HtmlString("<dt class=\"col-sm-2\">"),
                h.DisplayNameFor(e),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                h.DisplayFor(e),
                new HtmlString("</dd>")
            };
        }

        private static List<object> HtmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, string value) 
        {
            return new List<object> {
                new HtmlString("<dt class=\"col-sm-2\">"),
                h.DisplayNameFor(e),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                h.Raw(value),
                new HtmlString("</dd>")
            };
        }
    }
}
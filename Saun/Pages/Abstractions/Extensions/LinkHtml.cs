using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pages.Abstractions.Aids;

namespace Pages.Abstractions.Extensions
{
    public static class LinkHtml 
    {

        public static IHtmlContent Link(this IHtmlHelper htmlHelper, string text, params Link[] items) 
        {
            var s = HtmlStrings(text, items);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings(string text, Link[] items) 
        {
            var l = new List<object> {
                new HtmlString("<p>"),
                new HtmlString($"<a>{text}</a>")
            };

            l.AddRange(items.Select(item => new HtmlString($"<a> </a><a href=\"{item.Url}\">{item.DisplayName}</a>")));

            l.Add(new HtmlString("</p>"));

            return l;
        }

        public static IHtmlContent Link(this IHtmlHelper htmlHelper, params Link[] items) 
        {
            var s = HtmlStrings(items);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings(Link[] items) 
        {
            var l = new List<object>();

            l.AddRange(items.Select(item => new HtmlString($"<a href=\"{item.Url}\">{item.DisplayName}</a>")));

            return l;
        }
    }
}

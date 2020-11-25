using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pages.Abstractions.Aids;
using Pages.Abstractions.Constants;

namespace Pages.Abstractions.Extensions
{
    public static class BackToHtml {

        public static IHtmlContent BackTo(this IHtmlHelper h, Args a) 
        {
            if (h == null) throw new ArgumentNullException(nameof(h));

            var s = HtmlStrings(a?? new Args());

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings(Args a) 
        {
            a.PageUrl = new Uri($"./{GetPageUrl(a.PageUrl)}", UriKind.Relative);
            a.Handler = GetHandler(a.Handler);
            a.Action = null;
            a.ItemId = null;
            a.Title = GetTitle(a.Title);
            a.ControlId = "backToList";
            var s = Href.Compose(a);
            return new List<object> {
                new HtmlString(s)
            };
        }

        internal static string GetTitle(string s) => s ?? Captions.BackToList;

        internal static string GetHandler(string s) => s ?? Actions.Index;

        internal static Uri GetPageUrl(Uri s) => s ?? new Uri(Actions.Index, UriKind.Relative);

    }
}
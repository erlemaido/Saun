using System;
using System.Collections.Generic;
using Aids.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions.Aids;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Abstractions.Extensions 
{
    public static class NavButtonsHtml 
    {

        public static IHtmlContent NavButtons(this IHtmlHelper h, Args a, int? totalPages) 
        {
            if (h == null) throw new ArgumentNullException(nameof(h));

            var s = HtmlStrings(a?? new Args(), totalPages);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings(Args a, int? totalPages) 
        {
            var pageIndex = a.PageIndex < 1 ? 1: a.PageIndex;
            a.Action = "Index";
            var l = new List<object>();
            AddFirst(l, a, pageIndex);
            AddSeparator(l);
            AddPrevious(l, a, pageIndex);
            AddSeparator(l);
            AddPagesInfo(l, pageIndex, totalPages);
            AddSeparator(l);
            AddNext(l, a, pageIndex, totalPages);
            AddSeparator(l);
            AddLast(l, a, pageIndex, totalPages);

            return l;
        }

        internal static void AddLast(ICollection<object> l, Args a, in int? pageIndex, in int? totalPages) 
        {
            a.ControlId = "lastButton";
            a.PageIndex = totalPages;
            var b = HtmlButton(a, Captions.Last, HasNext(pageIndex, totalPages));
            l.Add(b);
        }

        internal static string HasNext(in int? pageIndex, in int? totalPages) 
        {
            return pageIndex >= totalPages ? "disabled" : string.Empty;
        }

        internal static void AddNext(ICollection<object> l, Args a, in int? pageIndex, in int? totalPages) 
        {
            a.ControlId = "nextButton";
            a.PageIndex = pageIndex + 1;
            var b = HtmlButton(a, Captions.Next, HasNext(pageIndex, totalPages));
            l.Add(b);
        }

        internal static void AddPrevious(ICollection<object> l, Args a, in int? pageIndex) 
        {
            a.ControlId = "previousButton";
            a.PageIndex = pageIndex - 1;
            var b = HtmlButton(a, Captions.Previous, HasPrevious(pageIndex));
            l.Add(b);
        }

        internal static string HasPrevious(in int? pageIndex) 
        {
            return pageIndex <= 1 ? "disabled" : string.Empty;
        }

        internal static void AddFirst(ICollection<object> l, Args a, in int? pageIndex) 
        {
            a.ControlId = "firstButton";
            a.PageIndex = 1;
            var b = HtmlButton(a, Captions.First, HasPrevious(pageIndex));
            l.Add(b);
        }

        internal static void AddPagesInfo(ICollection<object> l, in int? pageIndex, in int? totalPages) 
            =>l.Add(new HtmlString($"<a id=\"pagesInfo\">{Messages.PagesOf.Format(pageIndex, totalPages)}</a>"));

        internal static void AddSeparator(ICollection<object> l) 
        {
            l.Add(new HtmlString("&nbsp;"));
        }

        internal static HtmlString HtmlButton(Args a, string title, string disabled) 
        {
            if (!(a is null)) {
                a.ItemId = null;
                a.Title = title;
                a.Handler = Actions.Index;
                a.Disabled = disabled;
            }

            var s = Href.Compose(a);

            return new HtmlString(s);
        }
    }
}
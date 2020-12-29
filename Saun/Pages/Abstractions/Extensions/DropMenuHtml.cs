using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions.Aids;

namespace Sauna.Pages.Abstractions.Extensions
{
    public static class DropMenuHtml
    {

        public static IHtmlContent DropMenu(this IHtmlHelper h, string name, params Link[] items)
        {
            var s = HtmlStrings(name, items);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings(string name, Link[] items)
        {
            var list = new List<object>();
            BeginMenu(list, name);
            foreach (var item in items) AddItem(list, item);
            EndMenu(list);

            return list;
        }

        internal static void AddItem(List<object> htmlStrings, Link item)
        {
            if (htmlStrings is null) return;
            if (item is null) return;
            var s = $"<a class='dropdown-item' href=\"{item.Url}\">{item.DisplayName}</a>";
            htmlStrings.Add(new HtmlString(s));
        }

        internal static void BeginMenu(List<object> htmlStrings, string name)
        {
            if (htmlStrings is null) return;
            htmlStrings.Add(new HtmlString("<li class=\"nav-item dropdown\">"));
            htmlStrings.Add(new HtmlString(
                "<a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"navbardrop\" data-toggle=\"dropdown\">"));
            htmlStrings.Add(new HtmlString(name));
            htmlStrings.Add(new HtmlString("</a>"));
            htmlStrings.Add(new HtmlString("<div class=\"dropdown-menu\">"));
        }

        internal static void EndMenu(List<object> htmlStrings)
        {
            if (htmlStrings is null) return;
            htmlStrings.Add(new HtmlString("</div>"));
            htmlStrings.Add(new HtmlString("</li>"));
        }
    }
}
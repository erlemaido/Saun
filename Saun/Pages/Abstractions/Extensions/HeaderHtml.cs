using System;
using System.Collections.Generic;
using Aids.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions.Aids;

namespace Sauna.Pages.Abstractions.Extensions
{
   public static class HeaderHtml {

        public static IHtmlContent Header(this IHtmlHelper h, params string[] names) 
        {
            if (h == null) throw new ArgumentNullException(nameof(h));
            var s = HtmlStrings( names);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings(params string[] names) 
        {
            var l = new List<object> { new HtmlString("<tr>") };
            foreach (var name in names) AddHeader(l, name);
            l.Add(new HtmlString("<th></th>"));
            l.Add(new HtmlString("</tr>"));

            return l;
        }
        internal static List<object> HtmlStrings(params Link[] attributes)
        {
            var l = new List<object> { new HtmlString("<tr>") };
            foreach (var attribute in attributes) AddLink(l, attribute);
            l.Add(new HtmlString("<th></th>"));
            l.Add(new HtmlString("</tr>"));

            return l;
        }

        public static IHtmlContent Header(this IHtmlHelper h, params Link[] attributes) 
        {
            if (h == null) throw new ArgumentNullException(nameof(h));
            var s = HtmlStrings(attributes);
            return new HtmlContentBuilder(s);
        }

        internal static void AddHeader(List<object> htmlStrings, string name) 
        {
            if (htmlStrings is null) return;
            if (name is null) return;
            htmlStrings.Add(new HtmlString("<th>"));
            htmlStrings.Add(name);
            htmlStrings.Add(new HtmlString("</th>"));
        }
        internal static void AddLink(List<object> htmlStrings, Link link) 
        {
            if (htmlStrings is null) return;
            if (link is null) return;
            var id = link.PropertyName.ToLowerCase().RemoveSpaces() + "Column"; 
            htmlStrings.Add(new HtmlString("<th>"));
            htmlStrings.Add(new HtmlString($"<a id=\"{id}\" href=\"{link.Url}\"><span style=\"font-weight:normal\">{link.DisplayName}</span></a>"));
            htmlStrings.Add(new HtmlString("</th>"));
        }
   }
}

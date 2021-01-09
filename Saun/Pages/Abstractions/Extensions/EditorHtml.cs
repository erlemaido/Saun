using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sauna.Pages.Abstractions.Extensions
{
    public static class EditorHtml
    {
        public static IHtmlContent Editor<TModel, TResult>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) 
        {
            var s = HtmlStrings(h, e);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) 
        {
            return new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                h.LabelFor(e, new {@class = "text-light"}),
                h.EditorFor(e,
                    new {htmlAttributes = new {@class = "form-control"}}),
                h.ValidationMessageFor(e, "", new {@class = "text-danger"}),
                new HtmlString("</div>")
            };
        }
        
        public static IHtmlContent DisabledEditor<TModel, TResult>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) 
        {
            var s = DisabledHtmlStrings(h, e);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> DisabledHtmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) 
        {
            return new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                h.LabelFor(e, new {@class = "text-light"}),
                h.EditorFor(e,
                    new {htmlAttributes = new {@class = "form-control", disabled = "disabled"}}),
                h.ValidationMessageFor(e, "", new {@class = "text-danger"}),
                new HtmlString("</div>")
            };
        }
    }
}
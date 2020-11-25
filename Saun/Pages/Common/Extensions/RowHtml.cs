using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pages.Common.Aids;
using Pages.Common.Constants;

namespace Pages.Common.Extensions
{
    public static class RowHtml {

        public static IHtmlContent Row(
            this IHtmlHelper h,
            bool hasSelect,
            Uri pageUrl, 
            string itemId,
            params IHtmlContent[] values) 
        {
            if (h == null) throw new ArgumentNullException(nameof(h));

            var a = new Args(pageUrl, itemId);

            return Row(hasSelect, a, values);
        }

        public static IHtmlContent Row(
            this IHtmlHelper h,
            bool hasSelect,
            Uri pageUrl, 
            string itemId,
            string fixedFilter, 
            string fixedValue,
            params IHtmlContent[] values) 
        {

            if (h == null) throw new ArgumentNullException(nameof(h));

            var a = new Args(pageUrl, itemId, fixedFilter, fixedValue);

            return Row(hasSelect, a, values);
        }


        public static IHtmlContent Row(
            this IHtmlHelper h,
            bool hasSelect,
            Uri pageUrl, 
            string itemId,
            string sortOrder, 
            string searchString, 
            int pageIndex,
            string fixedFilter, 
            string fixedValue,
            params IHtmlContent[] values) 
        {
 
            if (h == null) throw new ArgumentNullException(nameof(h));

            var a = new Args(pageUrl, itemId, fixedFilter, fixedValue, sortOrder, searchString, pageIndex);

            return Row(hasSelect, a, values);
        }
        
        public static IHtmlContent Row(
            this IHtmlHelper h,
            bool hasSelect,
            bool hasEdit,
            bool hasDetails,
            bool hasDelete,
            Uri pageUrl,
            string itemId,
            string sortOrder,
            string searchString,
            int pageIndex,
            string fixedFilter,
            string fixedValue,
            params IHtmlContent[] values)
        {

            if (h == null) throw new ArgumentNullException(nameof(h));

            var a = new Args(pageUrl, itemId, fixedFilter, fixedValue, sortOrder, searchString, pageIndex);

            return Row(hasSelect, hasEdit, hasDetails, hasDelete, a, values);
        }

        internal static IHtmlContent Row(bool hasSelect, Args a, params IHtmlContent[] values) {
            var s = HtmlStrings(hasSelect, a, values);

            return new HtmlContentBuilder(s);
        }
        internal static IHtmlContent Row(bool hasSelect, bool hasEdit, bool hasDetails, bool hasDelete, Args a, params IHtmlContent[] values)
        {
            var s = HtmlStrings(hasSelect, hasEdit, hasDetails, hasDelete, a, values);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings(bool hasSelect, bool hasEdit, bool hasDetails, bool hasDelete, Args a,
            params IHtmlContent[] values) 
        {
            var list = new List<object>();
            foreach (var value in values) AddValue(list, value);
            list.Add(new HtmlString("<td>"));
            var hasButton = false;
            if (hasSelect) {
                list.Add(new HtmlString(Href.Compose(a, Actions.Index, Captions.Select)));
                hasButton = true;
            }

            if (hasEdit) 
            {
                if (hasButton) list.Add(" | ");
                list.Add(new HtmlString(Href.Compose(a, Actions.Edit, Captions.Edit)));
                hasButton = true;
            }

            if (hasDetails) 
            {
                if (hasButton) list.Add(" | ");
                list.Add(new HtmlString(Href.Compose(a, Actions.Details, Captions.Details)));
                hasButton = true;
            }

            if (hasDelete) 
            {
                if (hasButton) list.Add(" | ");
                list.Add(new HtmlString(Href.Compose(a, Actions.Delete, Captions.Delete)));
                list.Add(new HtmlString("</td>"));
            }

            return list;
        }

        internal static List<object> HtmlStrings(bool hasSelect, Args a, params IHtmlContent[] values) 
        {
            var list = new List<object>();
            foreach (var value in values) AddValue(list, value);
            list.Add(new HtmlString("<td>"));

            if (hasSelect) 
            {
                list.Add(new HtmlString(Href.Compose(a, Actions.Index, Captions.Select)));
                list.Add(" | ");
            }

            list.Add(new HtmlString(Href.Compose(a, Actions.Edit, Captions.Edit)));
            list.Add(" | ");
            list.Add(new HtmlString(Href.Compose(a, Actions.Details, Captions.Details)));
            list.Add(" | ");
            list.Add(new HtmlString(Href.Compose(a, Actions.Delete, Captions.Delete)));
            list.Add(new HtmlString("</td>"));

            return list;
        }

        internal static void AddValue(List<object> htmlStrings, IHtmlContent value) 
        {
            if (htmlStrings is null) return;
            if (value is null) return;
            htmlStrings.Add(new HtmlString("<td>"));
            htmlStrings.Add(value);
            htmlStrings.Add(new HtmlString("</td>"));
        }
    }
}

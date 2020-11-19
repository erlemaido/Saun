using System;

namespace Pages.Common.Aids
{
    public static class Href 
    {

        public static string Compose(Args a, string handler, string title) 
        {
            if (a is null) return Compose(null);
            a.Handler = handler;
            a.Action = handler;
            a.Title = title;

            return Compose(a);
        }

        public static string Compose(Args args) 
        {
            var s = AddPage(args?.PageUrl, args?.ControlId.ToString()) 
                + AddAction(args?.Action) 
                + AddHandler(args?.Handler) 
                + AddItemId(args?.ItemId.ToString()) 
                + AddFixedFilter(args?.FixedFilter) 
                + AddFixedValue(args?.FixedValue) 
                + AddSearchString(args?.SearchString) 
                + AddCurrentFilter(args?.CurrentFilter) 
                + AddSortOrder(args?.SortOrder) 
                + AddPageIndex(args?.PageIndex);
            return Remove(s) + AddClass(args?.Disabled) + AddTitle(args?.Title);
        }

        internal static string AddPage(Uri s, string id = null) =>
            s is null ? "<a href=\"#" :
            id is null ? $"<a href=\"{s}" :
            $"<a id=\"{id}\" href=\"{s}";

        internal static string AddAction(string s) => s is null ? "?" : $"/{s}?";

        internal static string AddHandler(string s) => s is null ? string.Empty : $"handler={s}";

        internal static string AddItemId(string s) => s is null ? string.Empty : $"&id={s}";

        internal static string AddFixedFilter(string s) => s is null ? string.Empty : $"&fixedFilter={s}";

        internal static string AddFixedValue(string s) => s is null ? string.Empty : $"&fixedValue={s}";

        internal static string AddSortOrder(string s) => s is null ? string.Empty : $"&sortOrder={s}";

        internal static string AddSearchString(string s) => s is null ? string.Empty : $"&searchString={s}";

        internal static string AddCurrentFilter(string s) => s is null ? string.Empty : $"&currentFilter={s}";

        internal static string AddPageIndex(int? s) => s is null ? string.Empty : $"&pageIndex={s}";

        internal static string AddClass(string s) => s is null ? string.Empty : $"\" class=\"btn btn-link {s}";

        internal static string AddTitle(string s) 
        {
            return s is null ? "\"></a>" : $"\">{s}</a>";
        }

        internal static string Remove(string s) 
        {
            if (s is null) return null;
            if (s.EndsWith("?", StringComparison.InvariantCulture)) s = s[..^1];

            return s;
        }
    }
}
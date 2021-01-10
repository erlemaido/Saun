using System;

namespace Sauna.Pages.Abstractions.Aids
{
    public class Link 
    {
        public Link(string displayName, Uri url, string propertyName = null) 
        {
            DisplayName = displayName;
            Url = url;
            PropertyName = propertyName ?? displayName;
        }

        public string DisplayName { get; }
        public Uri Url { get; }
        public string PropertyName { get; }
    }
}
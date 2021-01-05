using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;

namespace Tests {

    internal class HtmlContentMock : IHtmlContent {

        private readonly string _content;

        public HtmlContentMock(string s) => _content = s;
        public void WriteTo(TextWriter writer, HtmlEncoder encoder) => writer.WriteLine(_content);

        public override string ToString() => _content;

    }

}
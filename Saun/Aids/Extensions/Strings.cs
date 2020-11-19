using System.Globalization;
using System.Linq;
using Aids.Methods;

namespace Aids.Extensions
{
    public static class Strings
    {
        public static string ToLowerCase(this string s)
        {
            return Safe.Run(
                () => s?.ToLower(CultureInfo.InvariantCulture) ?? string.Empty, s ?? string.Empty
                );
        }

        public static string RemoveSpaces(this string s)
        {
            return Safe.Run(
                () => s?.Where(char.IsLetterOrDigit)
                          .Aggregate(string.Empty, (current, c) => current + c) ??
                      string.Empty, s ?? string.Empty);
        }
    }
}
using System.Globalization;
using System.Linq;
using Aids.Methods;

namespace Aids.Extensions
{
    public static class Strings
    {
        public static string Format(this string s, params object[] args)
            => Safe.Run(
                () => string.Format(CultureInfo.InvariantCulture, s, args),
                s ?? string.Empty);
        
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
using System;
using System.Linq.Expressions;
using Aids.Methods;

namespace Aids.Reflection
{
    public class GetMember
    {
        public static string Name<T>(Expression<Func<T, object>> ex) {
            return Safe.Run(() => Name(ex?.Body), string.Empty);
        }

        private static string Name(Expression ex) {
            var member = ex as MemberExpression;
            var method = ex as MethodCallExpression;
            var operand = ex as UnaryExpression;

            if (!(member is null)) return Name(member);
            if (!(method is null)) return Name(method);
            return !(operand is null) ? Name(operand) : string.Empty;
        }

        private static string Name(MemberExpression ex) {
            return ex?.Member.Name ?? string.Empty;
        }

        private static string Name(MethodCallExpression ex) {
            return ex?.Method.Name ?? string.Empty;
        }

        private static string Name(UnaryExpression ex) {
            var member = ex?.Operand as MemberExpression;
            var method = ex?.Operand as MethodCallExpression;

            if (!(member is null)) return Name(member);
            return !(method is null) ? Name(method) : string.Empty;
        }
    }
}
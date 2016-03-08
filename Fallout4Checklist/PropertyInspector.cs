using System;
using System.Linq.Expressions;

namespace Fallout4Checklist
{
    public static class PropertyInspector
    {
        public static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            var body = (MemberExpression)expression.Body;
            return body.Member.Name;
        }
    }
}

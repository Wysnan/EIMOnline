using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Wysnan.EIMOnline.Tool.Extensions
{
    public static class ExpressionExtension
    {
        public static string Lamda<TDelegate>(this Expression<TDelegate> expression)
        {
            var propertyExpression = expression.Body;

            MemberExpression memberExpression;
            var builder = new StringBuilder();
            do
            {
                memberExpression = propertyExpression as MemberExpression;

                if (memberExpression == null) { break; }

                if (!(memberExpression.Member is System.Reflection.PropertyInfo || memberExpression.Member is System.Reflection.FieldInfo))
                {
                    throw new InvalidOperationException("ExpressionHelper:Property/field access expected");
                }
                if (builder.Length > 0)
                {
                    builder.Insert(0, ".");
                }
                builder.Insert(0, memberExpression.Member.Name);

                propertyExpression = memberExpression.Expression;

            } while (memberExpression != null);
            string lamda = builder.ToString();
            return lamda;
        }
    }
}

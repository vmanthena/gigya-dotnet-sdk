namespace Gigya.Socialize.SDK.DeepCopy.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class DeepCopyExtensions
    {
        public static T Copy<T>(this T data)
        {
            var result = DeepCopy.DeepCopyByExpressionTree<T>(data);
            return result;
        }
    }
}

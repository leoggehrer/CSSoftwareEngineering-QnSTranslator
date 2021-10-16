//@QnSCodeCopy
//MdStart
using System;

namespace CommonBase.Extensions
{
    public static class TypeExtensions
    {
        public static void CheckInterface(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (type.IsInterface == false)
                throw new ArgumentException($"The parameter '{nameof(type)}' must be an interface.");
        }
    }
}
//MdEnd

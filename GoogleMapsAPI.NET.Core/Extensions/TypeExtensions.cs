using System;
using System.Linq;

namespace GoogleMapsAPI.NET.Extensions
{

    /// <summary>
    /// Type extensions
    /// </summary>
    internal static class TypeExtensions
    {

        #region Extension methods

        /// <summary>
        /// Get if given child type implements a parent
        /// </summary>
        /// <param name="child">Child</param>
        /// <param name="parent">Parent</param>
        /// <returns>True/False, based on result</returns>
        public static bool InheritsOrImplements(this Type child, Type parent)
        {
            parent = ResolveGenericTypeDefinition(parent);

            var currentChild = child.IsGenericType
                                   ? child.GetGenericTypeDefinition()
                                   : child;

            while (currentChild != typeof(object))
            {
                if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
                    return true;

                currentChild = currentChild.BaseType != null
                               && currentChild.BaseType.IsGenericType
                                   ? currentChild.BaseType.GetGenericTypeDefinition()
                                   : currentChild.BaseType;

                if (currentChild == null)
                    return false;
            }
            return false;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Get if given parent has any child interface
        /// </summary>
        /// <param name="parent">Parent</param>
        /// <param name="child">Child</param>
        /// <returns>True/False based on result</returns>
        private static bool HasAnyInterfaces(Type parent, Type child)
        {
            return child.GetInterfaces()
                .Any(childInterface =>
                {
                    var currentInterface = childInterface.IsGenericType
                        ? childInterface.GetGenericTypeDefinition()
                        : childInterface;

                    return currentInterface == parent;
                });
        }

        /// <summary>
        /// Resolve generic type definition
        /// </summary>
        /// <param name="parent">Parent type</param>
        /// <returns>Result</returns>
        private static Type ResolveGenericTypeDefinition(Type parent)
        {

            var shouldUseGenericType = !(parent.IsGenericType && parent.GetGenericTypeDefinition() != parent);
            if (parent.IsGenericType && shouldUseGenericType)
                parent = parent.GetGenericTypeDefinition();
            return parent;

        }

        #endregion

    }
}
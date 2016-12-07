/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月07日	新建
 * 
 *********************************************************************************************************************/

using System;
using System.Linq;
using System.Reflection;

// ReSharper disable CheckNamespace
namespace HQY.Common
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 包含了 <see cref="Type"/> 类型扩展方法的静态类。
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// <para>返回一个布尔值，指示 <paramref name="type"/> 是否是从 <paramref name="baseType"/> 类型派生（或实现）的。</para>
        /// <para>如果 <paramref name="type"/> 继承于 <paramref name="baseType"/> 则返回真（<c>true</c>）。</para>
        /// <para>如果 <paramref name="type"/> 实现了 <paramref name="baseType"/>（当是一个接口类型时）则返回真（<c>true</c>）</para>
        /// </summary>
        /// <param name="type">将要检查的类型。</param>
        /// <param name="baseType">预期的基类或接口。</param>
        /// <returns>如果 <paramref name="type"/> 是从 <paramref name="baseType"/> 派生或实现了 <paramref name="baseType"/>（当是一个接口类型时）时返回真（<c>true</c>）；否则返回假（<c>false</c>）。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="type"/> 或 <paramref name="baseType"/> 为空引用（<c>null</c>）时引发。</exception>
        public static bool IsDerivedFrom(this Type type, Type baseType)
        {
            #region Parameter Check

            ParamCheck.NotNull(type, nameof(type));
            ParamCheck.NotNull(baseType, nameof(baseType));

            #endregion

            TypeInfo baseTypeInfo = baseType.GetTypeInfo();

            // 如果预期类型是一个接口，
            if (baseTypeInfo.IsInterface) return type.IsImplFrom(baseType);

            TypeInfo typeInfo = type.GetTypeInfo();
            
            // 如果预期类型不是泛型声明，
            if (!baseTypeInfo.IsGenericTypeDefinition)
                return baseTypeInfo.IsAssignableFrom(type);
            else
            { // 否则，
                // 如果被测类型是泛型，
                if (typeInfo.IsGenericType)
                    return baseTypeInfo.IsAssignableFrom(typeInfo.GetGenericTypeDefinition());
                else // 否则
                {
                    bool result = baseTypeInfo.IsAssignableFrom(typeInfo);
                    if (result) return true;

                    // 查询基类，
                    var typeOfBase = typeInfo.BaseType;
                    while (typeOfBase != typeof(object))
                    {
                        result = typeOfBase.IsDerivedFrom(baseType);
                        if (result) break;

                        typeOfBase = typeOfBase.GetTypeInfo().BaseType;
                    }

                    return result;
                }
            }
        }

        /// <summary>
        /// <para>返回一个布尔值，指示 <paramref name="type"/> 是否是从 <typeparamref name="TBase"/> 类型派生（或实现）的。</para>
        /// <para>如果 <paramref name="type"/> 继承于 <typeparamref name="TBase"/> 则返回真（<c>true</c>）。</para>
        /// <para>如果 <paramref name="type"/> 实现了 <typeparamref name="TBase"/>（当是一个接口类型时）则返回真（<c>true</c>）</para>
        /// </summary>
        /// <typeparam name="TBase">预期的基类或接口。</typeparam>
        /// <param name="type">将要检查的类型。</param>
        /// <returns>如果 <paramref name="type"/> 是从 <typeparamref name="TBase"/> 派生或实现了 <typeparamref name="TBase"/>（当是一个接口类型时）时返回真（<c>true</c>）；否则返回假（<c>false</c>）。</returns>
        public static bool IsDerivedFrom<TBase>(this Type type)
        {
            return type.IsDerivedFrom(typeof(TBase));
        }

        /// <summary>
        /// <para>返回一个布尔值，指示 <paramref name="type"/> 是否实现了 <paramref name="ifType"/> 代表的接口。</para>
        /// </summary>
        /// <param name="type">将要检查的类型。</param>
        /// <param name="ifType">预期的接口类型。</param>
        /// <returns>如果 <paramref name="type"/> 实现了 <paramref name="ifType"/> 代表的接口时返回真（<c>true</c>），否则返回假（<c>false</c>）。</returns>
        /// <remarks>注，如果 <paramref name="ifType"/> 不是一个接口类型，那么将返回一个假（<c>false</c>）。</remarks>
        /// <exception cref="ArgumentNullException">当 <paramref name="type"/> 或 <paramref name="ifType"/> 为空引用（<c>null</c>）时引发。</exception>
        public static bool IsImplFrom(this Type type, Type ifType)
        {
            #region Parameter Check

            ParamCheck.NotNull(type, nameof(type));
            ParamCheck.NotNull(ifType, nameof(ifType));

            #endregion

            var typeInfo = type.GetTypeInfo();
            var ifTypeInfo = ifType.GetTypeInfo();

            // 如果预期类型不是一个接口，
            if (!ifTypeInfo.IsInterface) return false;

            // 如果被测类型是泛型，
            if (typeInfo.IsGenericType)
                return typeInfo.GetGenericTypeDefinition() == ifType || ifTypeInfo.IsAssignableFrom(typeInfo);

            // 被测类型是一般类型，
            return ifTypeInfo.IsAssignableFrom(typeInfo) || typeInfo.GetInterfaces().Any(ifif =>
                   {
                       var ififInfo = ifif.GetTypeInfo();

                       // 如果是泛型则比较泛型定义，否则比较类型。
                       return ififInfo.IsGenericType
                           ? ififInfo.GetGenericTypeDefinition() == ifType
                           : ifif == ifType;
                   });
        }

        /// <summary>
        /// <para>返回一个布尔值，指示 <paramref name="type"/> 是否实现了 <typeparamref name="TIfType"/> 代表的接口。</para>
        /// </summary>
        /// <typeparam name="TIfType">预期的接口类型。</typeparam>
        /// <param name="type">将要检查的类型。</param>
        /// <returns>如果 <paramref name="type"/> 实现了 <typeparamref name="TIfType"/> 代表的接口时返回真（<c>true</c>），否则返回假（<c>false</c>）。</returns>
        public static bool IsImplFrom<TIfType>(this Type type)
        {
            return type.IsImplFrom(typeof(TIfType));
        }
    }
}

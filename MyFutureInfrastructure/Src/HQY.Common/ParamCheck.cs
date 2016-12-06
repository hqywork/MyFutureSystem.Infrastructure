/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月06日	新建
 * 
 *********************************************************************************************************************/

using System;
using System.Collections;

namespace HQY.Common
{
    /// <summary>
    /// 定义了方法参数检查相关方法的静态类。
    /// </summary>
    public static class ParamCheck
    {
        /// <summary>
        /// <para>检查 <paramref name="value"/> 是否为空全局唯一标识符（<see cref="Guid.Empty"/>）。</para>
        /// </summary>
        /// <param name="value">将要被检查的参数值。</param>
        /// <param name="name">被检查参数值的名称。</param>
        /// <exception cref="ArgumentNullException">当 <paramref name="name"/> 为空引用（<c>null</c>）时引发。</exception>
        /// <exception cref="ArgumentEmptyException">当 <paramref name="value"/> 为空全局唯一标识符（<see cref="Guid.Empty"/>） 或 <paramref name="name"/> 为空字符串（<see cref="String.Empty"/>）时引发。</exception>
        public static void NotEmpty(Guid value, string name)
        {
            if (Guid.Equals(value, Guid.Empty))
            {
                ParamCheck.NotEmptyOrNull(name, nameof(name));
                throw new ArgumentEmptyException(name);
            }
        }

        /// <summary>
        /// 检查 <paramref name="value"/>，
        /// 如果为空引用（<c>null</c>）则抛出 <see cref="ArgumentNullException"/>；
        /// 如果为空字符串（<see cref="String.Empty"/>）则抛出 <see cref="ArgumentEmptyException"/>。
        /// </summary>
        /// <param name="value">被检查的字符串类型值。</param>
        /// <param name="name">被检查值在方法定义中的名称。</param>
        public static void NotEmptyOrNull(string value, string name)
        {
            ArgumentException e = null;
            if (ReferenceEquals(value, null))
                e = new ArgumentNullException(name);
            else if (value.Trim().Length == 0)
                e = new ArgumentEmptyException(name);

            if (e != null)
            {
                ParamCheck.NotEmptyOrNull(name, nameof(name));
                throw e;
            }
        }

        /// <summary>
        /// 检查 <paramref name="value"/>，如果没有任何元素存在则抛出 <see cref="ArgumentEmptyException"/>。
        /// </summary>
        /// <param name="value">被检查集合值。</param>
        /// <param name="name">被检查值在方法定义中的名称。</param>
        public static void NotEmptyOrNull(ICollection value, string name)
        {
            ArgumentException e = null;

            if (ReferenceEquals(value, null))
                e = new ArgumentNullException(name);
            else if (value.Count == 0)
                e = new ArgumentEmptyException(name);

            if (e != null)
            {
                ParamCheck.NotEmptyOrNull(name, nameof(name));
                throw e;
            }
        }

        /// <summary>
        /// 检查 <paramref name="value"/>，如果为空引用（<c>null</c>）则抛出 <see cref="ArgumentNullException"/>。
        /// </summary>
        /// <typeparam name="T">指定 <paramref name="value"/> 的类型。</typeparam>
        /// <param name="value">被检查值。</param>
        /// <param name="name">被检查值在方法定义中的名称。</param>
        /// <exception cref="ArgumentNullException">如果被检查值为空引用（<c>null</c>）则抛出。</exception>
        public static void NotNull<T>(T value, string name) where T : class
        {
            if (ReferenceEquals(value, null))
            {
                ParamCheck.NotEmptyOrNull(name, nameof(name));
                throw new ArgumentNullException(name);
            }
        }
    }
}

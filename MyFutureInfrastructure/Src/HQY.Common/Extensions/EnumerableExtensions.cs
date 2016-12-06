/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月06日	新建	
 * 
 *********************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable CheckNamespace
namespace HQY.Common
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 包含 <see cref="IEnumerable{T}"/> 扩展方法的静态类。
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 循环对 <paramref name="source"/> 内的每个元素执行 <paramref name="action"/> 定义的操作。
        /// </summary>
        /// <typeparam name="T"><paramref name="source"/> 中元素的类型。</typeparam>
        /// <param name="source">包含将要处理元素的 <see cref="IEnumerable{T}"/>。</param>
        /// <param name="action">将要应用于元素的方法。</param>
        /// <exception cref="NullReferenceException">当 <paramref name="source"/> 为空引用（<c>null</c>）时引发。</exception>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            #region Param Check

            ParamCheck.NotNull(source, nameof(source));

            #endregion

            foreach (T item in source)
                action.Invoke(item);
        }

        /// <summary>
        /// 循环对 <paramref name="source"/> 内的每个元素执行 <paramref name="func"/> 定义的操作，并返回包含处理后元素的 <see cref="IEnumerable{T}"/>。
        /// </summary>
        /// <typeparam name="T"><paramref name="source"/> 中元素的类型。</typeparam>
        /// <param name="source">包含将要处理元素的 <see cref="IEnumerable{T}"/>。</param>
        /// <param name="func">将要应用于元素的方法。</param>
        /// <returns>包含处理后元素的 <see cref="IEnumerable{T}"/>。</returns>
        /// <exception cref="NullReferenceException">当 <paramref name="source"/> 为空引用（<c>null</c>）时引发。</exception>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Func<T, T> func)
        {
            #region Param Check

            ParamCheck.NotNull(source, nameof(source));

            #endregion

            return source.Select(item => func.Invoke(item)).ToList();
        }
    }
}

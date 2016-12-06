/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月06日	新建	
 * 
 *********************************************************************************************************************/

using System;
using System.Collections.Generic;
using Xunit;

namespace HQY.Common.Test.Extensions
{
    /// <summary>
    /// <see cref="EnumerableExtensions"/> 单元测试。
    /// </summary>
    public class EnumerableExtensionsTest
    {
        /// <summary>
        /// <see cref="EnumerableExtensions.ForEach{T}(IEnumerable{T}, Action{T})"/> 单元测试。
        /// </summary>
        [Theory(DisplayName = "IEnumerable{T}.ForEachByAction")]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, null, new[] { 1, 4, 9, 16, 25 })]
        [InlineData(null, typeof(ArgumentNullException), null)]
        public void ForEachByActionTest(IEnumerable<Int32> value, Type exType, IEnumerable<Int32> result)
        {
            if (exType != null)
            {
                ArgumentException ex =
                    (ArgumentException)
                    Assert.Throws(exType, () => EnumerableExtensions.ForEach(value, (ele)=> { }));
                Assert.Equal("source", ex.ParamName);
            }
            else
            {
                IList<Int32> tmp = new List<Int32>();
                value.ForEach(ele => tmp.Add(ele * ele));
                Assert.Equal(result, tmp);
            }
        }

        /// <summary>
        /// <see cref="EnumerableExtensions.ForEach{T}(IEnumerable{T}, Func{T, T})"/> 单元测试。
        /// </summary>
        [Theory(DisplayName = "IEnumerable{T}.ForEachByFunc")]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, null, new[] { 1, 4, 9, 16, 25 })]
        [InlineData(null, typeof(ArgumentNullException), null)]
        public void ForEachByFuncTest(IEnumerable<Int32> value, Type exType, IEnumerable<Int32> result)
        {
            if (exType != null)
            {
                ArgumentException ex =
                    (ArgumentException)
                    Assert.Throws(exType, () => EnumerableExtensions.ForEach(value, ele => ele * ele));
                Assert.Equal("source", ex.ParamName);
            }
            else
            {
                var tmp = value.ForEach(ele => ele * ele);
                Assert.Equal(result, tmp);
            }
        }
    }
}

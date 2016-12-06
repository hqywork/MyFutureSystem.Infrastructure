/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月06日	新建
 * 
 *********************************************************************************************************************/

using System;
using System.Collections;
using Xunit;

namespace HQY.Common.Test
{
    /// <summary>
    /// <see cref="ParamCheck"/> 单元测试。
    /// </summary>
    public class ParamCheckTest
    {
        /// <summary>
        /// <see cref="ParamCheck.NotEmpty(Guid, string)"/> 方法单元测试。
        /// </summary>
        [Theory(DisplayName = "ParamCheck.NotEmpty")]
        [InlineData("00000000-0000-0000-0000-000000000000", typeof(ArgumentEmptyException), "param")]
        [InlineData("00000000-0000-0000-0000-000000000000", typeof(ArgumentNullException), null)]
        [InlineData("00000000-0000-0000-0000-000000000000", typeof(ArgumentEmptyException), "")]
        [InlineData("6DA2B72B-4B33-4294-A292-CE850A086CFF", null, "param")]
        [InlineData("6DA2B72B-4B33-4294-A292-CE850A086CFF", null, null)]
        [InlineData("6DA2B72B-4B33-4294-A292-CE850A086CFF", null, "")]
        public void NotEmptyTest(string value, Type exType, string paramName)
        {
            Guid measurand = Guid.Parse(value);

            if (exType != null)
            {
                ArgumentException ex =
                    (ArgumentException)Assert.Throws(exType, () => ParamCheck.NotEmpty(measurand, paramName));

                Assert.Equal(String.IsNullOrEmpty(paramName) ? "name" : paramName, ex.ParamName);
            }
            else
                ParamCheck.NotEmpty(measurand, paramName);
        }

        /// <summary>
        /// <see cref="ParamCheck.NotEmptyOrNull(ICollection, string)"/> 方法单元测试。
        /// </summary>
        [Theory(DisplayName = "ParamCheck.NotEmptyOrNull(ICollection)")]
        [InlineData(null, typeof(ArgumentNullException), "param")]
        [InlineData(null, typeof(ArgumentNullException), null)]
        [InlineData(null, typeof(ArgumentEmptyException), "")]
        [InlineData(new Object[0], typeof(ArgumentEmptyException), "param")]
        [InlineData(new Object[0], typeof(ArgumentNullException), null)]
        [InlineData(new Object[0], typeof(ArgumentEmptyException), "")]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, null, "param")]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, null, null)]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, null, "")]
        public void NotEmptyOrNullByICollectionTest(ICollection value, Type exType, string paramName)
        {
            if (exType != null)
            {
                ArgumentException ex =
                    (ArgumentException)Assert.Throws(exType, () => ParamCheck.NotEmptyOrNull(value, paramName));
                Assert.Equal(String.IsNullOrEmpty(paramName) ? "name" : paramName, ex.ParamName);
            }
            else
                ParamCheck.NotEmptyOrNull(value, paramName);
        }

        /// <summary>
        /// <see cref="ParamCheck.NotEmptyOrNull(string, string)"/> 方法单元测试。
        /// </summary>
        [Theory(DisplayName = "ParamCheck.NotEmptyOrNull(string)")]
        [InlineData(null, typeof(ArgumentNullException), "param")]
        [InlineData(null, typeof(ArgumentNullException), null)]
        [InlineData(null, typeof(ArgumentEmptyException), "")]
        [InlineData("", typeof(ArgumentEmptyException), "param")]
        [InlineData("", typeof(ArgumentNullException), null)]
        [InlineData("", typeof(ArgumentEmptyException), "")]
        [InlineData("abcdefg", null, "param")]
        [InlineData("abcdefg", null, null)]
        [InlineData("abcdefg", null, "")]
        public void NotEmptyOrNullByStringTest(string value, Type exType, string paramName)
        {
            if (exType != null)
            {
                ArgumentException ex =
                    (ArgumentException)Assert.Throws(exType, () => ParamCheck.NotEmptyOrNull(value, paramName));
                Assert.Equal(String.IsNullOrEmpty(paramName) ? "name" : paramName, ex.ParamName);
            }
            else
                ParamCheck.NotEmptyOrNull(value, paramName);
        }

        /// <summary>
        /// <see cref="ParamCheck.NotNull{T}(T, string)"/> 方法单元测试。
        /// </summary>
        [Theory(DisplayName = "ParamCheck.NotNull")]
        [InlineData(null, typeof(ArgumentNullException), "param")]
        [InlineData(null, typeof(ArgumentNullException), null)]
        [InlineData(null, typeof(ArgumentEmptyException), "")]
        [InlineData("abcdefg", null, "param")]
        [InlineData("abcdefg", null, null)]
        [InlineData("abcdefg", null, "")]
        public void NotNullTest(string value, Type exType, string paramName)
        {
            if (exType != null)
            {
                ArgumentException ex =
                    (ArgumentException)Assert.Throws(exType, () => ParamCheck.NotNull(value, paramName));
                Assert.Equal(String.IsNullOrEmpty(paramName) ? "name" : paramName, ex.ParamName);
            }
            else
                ParamCheck.NotNull(value, paramName);
        }
    }
}

/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月03日	新建	
 * 
 *********************************************************************************************************************/

using System;
using Xunit;

namespace HQY.Common.Test.Extensions
{
    /// <summary>
    /// <see cref="HexStringExtensions"/> 单元测试。
    /// </summary>
    public class HexStringExtensionsTest
    {
        /// <summary>
        /// <see cref="HexStringExtensions.IsHexString(string)"/> 方法单元测试。
        /// </summary>
        [Theory(DisplayName = "HexStringExtensions.IsHexString")]
        [InlineData(null, typeof(ArgumentNullException), false)]
        [InlineData("", typeof(ArgumentEmptyException), false)]
        [InlineData("ABCDEFGH", null, false)]
        [InlineData("ABCDEFG", null, false)]
        [InlineData("1234567890abcdefABCDEF", null, true)]
        [InlineData("1234567890abcABCD", null, false)]
        public void IsHexStringTest(string hexStr, Type exType, bool result)
        {
            if (exType != null)
            {
                Assert.Throws(exType, () =>
                {
                    Assert.Equal(HexStringExtensions.IsHexString(hexStr), result);
                });
            }
            else
            {
                Assert.Equal(HexStringExtensions.IsHexString(hexStr), result);
            }
        }

        /// <summary>
        /// <see cref="HexStringExtensions.ToBytes(string)"/> 方法单元测试。
        /// </summary>
        [Theory(DisplayName = "HexStringExtensions.ToBytes")]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(ArgumentEmptyException))]
        [InlineData("1234567890abcdefABCDEF", null)]
        [InlineData("1234567890abcABCD", typeof(InvalidCastException))]
        public void ToBytesTest(string hexStr, Type exType)
        {
            if (exType != null)
                Assert.Throws(exType, () => HexStringExtensions.ToBytes(hexStr));
            else
                Assert.True(HexStringExtensions.ToBytes(hexStr).Length > 0);
        }

        /// <summary>
        /// <see cref="HexStringExtensions.ToBytes(string)"/> 方法单元测试。
        /// </summary>
        [Theory(DisplayName = "HexStringExtensions.ToHexString")]
        [InlineData(null, typeof(ArgumentNullException), null)]
        [InlineData(new byte[0], typeof(ArgumentEmptyException), null)]
        [InlineData(new byte[] { 25, 170 }, null, "19AA")]
        public void ToHexStringTest(byte[] bin, Type exType, string result)
        {
            if (exType != null)
                Assert.Throws(exType, () => HexStringExtensions.ToHexString(bin));
            else
                Assert.Equal(HexStringExtensions.ToHexString(bin), result);
        }
    }
}

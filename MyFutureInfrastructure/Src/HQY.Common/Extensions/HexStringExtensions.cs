/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月03日	新建	
 * 
 *********************************************************************************************************************/

using System;
using System.Globalization;
using System.Text;

// ReSharper disable CheckNamespace
namespace HQY.Common
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 包含了 <see cref="String"/> 扩展方法的静态类。
    /// </summary>
    public static class HexStringExtensions
    {
        /// <summary>
        /// <para>检查当前字符串是否是由 16 进制字符构成的。</para>
        /// <para>
        /// 检查内容包含：
        /// <list type="number">
        /// <item>1. 检查字符串的总字符个数是 2 的整数倍。</item>
        /// <item>2. 检查字符串中的构成字符为 0-9，A-F, a-f</item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="str">将被检查的字符串。</param>
        /// <returns>如果符合返回 <c>ture</c>；否则返回 <c>false</c>。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="str"/> 为空引用（<c>null</c>）时抛出。</exception>
        /// <exception cref="ArgumentEmptyException">当 <paramref name="str"/> 为空字符串（<see cref="String.Empty"/>）时抛出。</exception>
        /// <remarks>
        /// 本方法仅在字符串内容上保证是符合 16 进制的规则；但不保证转换成的 byte[] 一定符合业务要求。
        /// </remarks>
        public static bool IsHexString(this string str)
        {
            #region Parameter's Check

            ParamCheck.NotEmptyOrNull(str, nameof(str));

            #endregion

            // 如果不是 2 的整数倍。
            if (str.Length%2 > 0) return false;

            // 循环检查构成的字符。
            foreach (char c in str)
            {
                if (c >= 'a' && c <= 'f') continue;
                if (c >= 'A' && c <= 'F') continue;
                if (c >= '0' && c <= '9') continue;

                return false;
            }

            return true;
        }

        /// <summary>
        /// 转换当前 16 进制字符串为字节数组。
        /// </summary>
        /// <param name="hexStr">由 16 进制字符构成的字符串。</param>
        /// <returns>转换后的字节数组。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="hexStr"/> 为空引用（<c>null</c>）时抛出。</exception>
        /// <exception cref="ArgumentEmptyException">当 <pramref name="hexStr"/> 为空字符串（<see cref="String.Empty"/>）时抛出。</exception>
        /// <exception cref="InvalidCastException">当源字符串内容不符合十六进制字符规则时抛出。请参考 <see cref="IsHexString(string)"/> 方法。</exception>
        public static byte[] ToBytes(this string hexStr)
        {
            #region Parameter's Check

            ParamCheck.NotEmptyOrNull(hexStr, nameof(hexStr));

            #endregion

            // 检查字符串是否由 16 进制字符构成。
            if (!hexStr.IsHexString())
                throw new InvalidCastException(Properties.Resource.HexStringInvalid);

            int byteCount = hexStr.Length / 2; // 求得转换后的字节数组元素总数。
            byte[] bytes = new byte[byteCount]; // 存储转换后的字节数组。

            for (int i = 0; i < hexStr.Length; i++)
            {
                string hex = hexStr.Substring(i++, 2); // 取得二个字符，并使用字符计算加一。

                bytes[i / 2] = byte.Parse(hex, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
            }

            return bytes;
        }

        /// <summary>
        /// 转换当前字节数组为 16 进制字符构成的字符串。
        /// </summary>
        /// <param name="bin">待转换的字节数组。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="bin"/> 为空引用（<c>null</c>）时抛出。</exception>
        /// <exception cref="ArgumentEmptyException">当 <paramref name="bin"/> 为空集合时抛出。</exception>
        public static string ToHexString(this byte[] bin)
        {
            #region Parameter's Check

            ParamCheck.NotEmptyOrNull(bin, nameof(bin));

            #endregion

            StringBuilder hexStr = new StringBuilder();

            foreach (byte b in bin)
                hexStr.Append(b.ToString("X2", CultureInfo.InvariantCulture));

            return hexStr.ToString();
        }
    }
}

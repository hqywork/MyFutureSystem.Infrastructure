/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月03日	新建
 * 
 *********************************************************************************************************************/

using System;
using HQY.Common.Exception;

// ReSharper disable CheckNamespace
namespace HQY.Common
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 当将空字符串（<see cref="String.Empty"/>）或空集合传递给不接受它作为有效参数的方法时引发的异常。
    /// </summary>
    public sealed class ArgumentEmptyException : ArgumentException
    {
        /// <summary>
        /// 初始化 <see cref="ArgumentEmptyException"/> 类的新实例。
        /// </summary>
        public ArgumentEmptyException() : base(Properties.Resource.ArgumentEmpty_Generic)
        {
            base.HResult = ErrorCodes.ArgumentEmptyErrorCode;
        }

        /// <summary>
        /// 使用导致此异常的参数的名称初始化 <see cref="ArgumentEmptyException"/> 类的新实例。
        /// </summary>
        /// <param name="paramName">导致异常的参数的名称。</param>
        public ArgumentEmptyException(string paramName) : base(Properties.Resource.ArgumentEmpty_Generic, paramName)
        {
            base.HResult = ErrorCodes.ArgumentEmptyErrorCode;
        }

        /// <summary>
        /// 使用指定的错误消息和引发此异常的异常初始化 <see cref="ArgumentEmptyException"/> 类的新实例。
        /// </summary>
        /// <param name="message">说明发生此异常的原因的错误消息。</param>
        /// <param name="innerException">导致当前异常的异常；如果未指定内部异常，则是一个空引用（<c>null</c>）。</param>
        public ArgumentEmptyException(string message, System.Exception innerException) : base(message, innerException)
        {
            base.HResult = ErrorCodes.ArgumentEmptyErrorCode;
        }

        /// <summary>
        /// 使用指定的错误消息和导致此异常的参数的名称初始化 <see cref="ArgumentEmptyException"/> 类的新实例。
        /// </summary>
        /// <param name="paramName">导致异常的参数的名称。</param>
        /// <param name="message">描述错误的消息。</param>
        public ArgumentEmptyException(string paramName, string message) : base(message, paramName)
        {
            base.HResult = ErrorCodes.ArgumentEmptyErrorCode;
        }
    }
}

/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月03日	新建
 * 
 *********************************************************************************************************************/

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Domain
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// <para>定义了实体模型版本属性的接口。</para>
    /// <para>版本主要用于实体模型更新时的乐观锁。</para>
    /// </summary>
    public interface IVersionOfEntityModel
    {
        #region Properties

        /// <summary>
        /// 版本。
        /// </summary>
        byte[] Version { get; set; }

        #endregion
    }
}

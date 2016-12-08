/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Domain.EntityModel
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// <para>定义了实体模型的状态属性的接口。</para>
    /// <para>状态代表实体模型在业务中的情况。</para>
    /// </summary>
    public interface IStateOfEntityModel
    {
        #region Properties

        /// <summary>
        /// 状态。
        /// </summary>
        int State { get; set; }

        #endregion
    }
}

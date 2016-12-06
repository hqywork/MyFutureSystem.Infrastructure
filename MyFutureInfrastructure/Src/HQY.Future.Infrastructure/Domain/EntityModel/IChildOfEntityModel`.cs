/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月02日	新建
 * 
 *********************************************************************************************************************/

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Domain
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 实现此接口的实体模型意味着这个模型中拥有一个指向父实体模型。
    /// </summary>
    /// <typeparam name="TParentId">指定父实体模型唯一标识的类型。</typeparam>
    public interface IChildOfEntityModel<TParentId> : IChildOfEntityModel
    {
        #region Properties

        /// <summary>
        /// 父项的唯一标识。
        /// </summary>
        TParentId ParentId { get; set; }

        #endregion
    }
}

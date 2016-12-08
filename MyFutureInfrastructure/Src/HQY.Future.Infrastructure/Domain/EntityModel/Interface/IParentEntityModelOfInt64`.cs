/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月07日	新建
 * 
 *********************************************************************************************************************/

using System;

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Domain.EntityModel
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// <para>实现此接口的实体模型意味着拥有表示父实体（唯一标识的类型为 <see cref="Int64"/>）的关联属性。</para>
    /// <para>一般情况下，此接口应用于“One-to-Many”关系中表示“Many”的实体模型中。</para>
    /// </summary>
    /// <typeparam name="TParentModel">所关联的父实体模型的类型。</typeparam>
    public interface IParentEntityModelOfInt64<TParentModel> where TParentModel : EntityModelOfInt64
    {
        #region Properties

        /// <summary>
        /// 父实体模型。
        /// </summary>
        TParentModel Parent { get; set; }

        /// <summary>
        /// 父实体模型的唯一标识。
        /// </summary>
        long ParentId { get; set; }

        #endregion
    }
}

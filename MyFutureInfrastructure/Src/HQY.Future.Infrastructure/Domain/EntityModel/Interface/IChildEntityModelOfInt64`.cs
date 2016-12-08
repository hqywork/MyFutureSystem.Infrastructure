/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月07日	新建
 * 
 *********************************************************************************************************************/

using System;
using System.Collections.Generic;
using HQY.Future.Infrastructure.Domain.EntityModel.Internal;

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Domain.EntityModel
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// <para>实现此接口的实体模型意味着拥有一组表示子实体（唯一标识的类型为 <see cref="Int32"/>）的关联属性。</para>
    /// <para>一般情况下，此接口应用于“One-to-Many”关系中表示“One”的实体模型中。</para>
    /// </summary>
    /// <typeparam name="TChildModel">所关联的子实体模型的类型。</typeparam>
    public interface IChildEntityModelOfInt64<TChildModel> : IChildEntityModel where TChildModel : EntityModelOfInt64
    {
        #region Properties

        /// <summary>
        /// 包含了子实体的集合。
        /// </summary>
        ICollection<TChildModel> Children { get; set; }

        /// <summary>
        /// 子实体的数量。
        /// </summary>
        long CountOfChild { get; set; }

        #endregion
    }
}

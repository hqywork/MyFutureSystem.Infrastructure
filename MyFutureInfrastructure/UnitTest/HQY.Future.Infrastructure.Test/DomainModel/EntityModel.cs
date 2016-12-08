/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using System;
using HQY.Future.Infrastructure.Domain.EntityModel;

namespace HQY.Future.Infrastructure.Test.DomainModel
{
    /// <summary>
    /// 用于测试的 <see cref="IEntityModel{T}"/> 接口默认实现。
    /// </summary>
    internal class EntityModel : IEntityModel<Guid>
    {
        #region Implementation of IEntityModel<Guid>

        /// <summary>
        /// 唯一标识。
        /// </summary>
        public Guid Id { get; set; }

        #endregion
    }
}

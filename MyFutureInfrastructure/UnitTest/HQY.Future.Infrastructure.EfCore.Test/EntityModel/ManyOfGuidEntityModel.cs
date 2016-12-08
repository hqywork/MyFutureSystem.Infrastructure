/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using System;
using HQY.Future.Infrastructure.Domain.EntityModel;

namespace HQY.Future.Infrastructure.EfCore.Test.EntityModel
{
    /// <summary>
    /// 用于测试的 <see cref="IParentEntityModelOfGuid{TParentModel}"/> 接口默认实现。
    /// </summary>
    internal class ManyOfGuidEntityModel : EntityModelOfGuid, IParentEntityModelOfGuid<OneOfGuidEntityModel>
    {
        #region Implementation of IParentEntityModelOfGuid<OneOfGuidEntityModel>

        /// <summary>
        /// 父实体模型。
        /// </summary>
        public OneOfGuidEntityModel Parent { get; set; }

        /// <summary>
        /// 父实体模型的唯一标识。
        /// </summary>
        public Guid ParentId { get; set; }

        #endregion
    }
}

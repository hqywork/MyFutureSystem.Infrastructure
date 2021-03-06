﻿/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using HQY.Future.Infrastructure.Domain.EntityModel;

namespace HQY.Future.Infrastructure.EfCore.Test.EntityModel
{
    /// <summary>
    /// 用于测试的 <see cref="IParentEntityModelOfInt64{TParentModel}"/> 接口默认实现。
    /// </summary>
    internal class ManyOfInt64EntityModel : EntityModelOfInt64, IParentEntityModelOfInt64<OneOfInt64EntityModel>
    {
        #region Implementation of IParentEntityModelOfInt64<OneOfInt64EntityModel>

        /// <summary>
        /// 父实体模型。
        /// </summary>
        public OneOfInt64EntityModel Parent { get; set; }

        /// <summary>
        /// 父实体模型的唯一标识。
        /// </summary>
        public long ParentId { get; set; }

        #endregion
    }
}

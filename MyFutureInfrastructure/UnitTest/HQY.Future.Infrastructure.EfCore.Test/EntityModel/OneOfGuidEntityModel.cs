/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using System.Collections.Generic;
using HQY.Future.Infrastructure.Domain.EntityModel;

namespace HQY.Future.Infrastructure.EfCore.Test.EntityModel
{
    /// <summary>
    /// 用于测试的 <see cref="IChildEntityModelOfGuid{TChildModel}"/> 接口默认实现。
    /// </summary>
    internal class OneOfGuidEntityModel : EntityModelOfGuid, IChildEntityModelOfGuid<ManyOfGuidEntityModel>
    {
        #region Implementation of IChildEntityModelOfGuid<ManyOfGuidEntityModel>

        /// <summary>
        /// 包含了子实体的集合。
        /// </summary>
        public ICollection<ManyOfGuidEntityModel> Children { get; set; }

        /// <summary>
        /// 子实体的数量。
        /// </summary>
        public long CountOfChild { get; set; }

        #endregion
    }
}

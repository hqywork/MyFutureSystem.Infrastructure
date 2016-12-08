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
    /// 用于测试的 <see cref="IChildEntityModelOfInt32{TChildModel}"/> 接口默认实现。
    /// </summary>
    internal class OneOfInt32EntityModel : EntityModelOfInt32, IChildEntityModelOfInt32<ManyOfInt32EntityModel>
    {
        #region Implementation of IChildEntityModelOfInt32<ManyOfInt32EntityModel>

        /// <summary>
        /// 包含了子实体的集合。
        /// </summary>
        public ICollection<ManyOfInt32EntityModel> Children { get; set; }

        /// <summary>
        /// 子实体的数量。
        /// </summary>
        public int CountOfChild { get; set; }

        #endregion
    }
}

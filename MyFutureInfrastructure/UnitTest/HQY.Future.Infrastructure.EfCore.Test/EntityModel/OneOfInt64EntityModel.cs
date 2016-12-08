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
    /// 用于测试的 <see cref="IChildEntityModelOfInt64{TChildModel}"/> 接口默认实现。
    /// </summary>
    internal class OneOfInt64EntityModel : EntityModelOfInt64, IChildEntityModelOfInt64<ManyOfInt64EntityModel>
    {
        #region Implementation of IChildEntityModelOfInt64<ManyOfInt64EntityModel>

        /// <summary>
        /// 包含了子实体的集合。
        /// </summary>
        public ICollection<ManyOfInt64EntityModel> Children { get; set; }

        /// <summary>
        /// 子实体的数量。
        /// </summary>
        public long CountOfChild { get; set; }

        #endregion
    }
}

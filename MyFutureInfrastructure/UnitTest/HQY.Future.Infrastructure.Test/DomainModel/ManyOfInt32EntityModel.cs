/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using HQY.Future.Infrastructure.Domain.EntityModel;

namespace HQY.Future.Infrastructure.Test.DomainModel
{
    /// <summary>
    /// 用于测试的 <see cref="IParentEntityModelOfInt32{TParentModel}"/> 接口默认实现。
    /// </summary>
    internal class ManyOfInt32EntityModel : EntityModelOfInt32, IParentEntityModelOfInt32<OneOfInt32EntityModel>
    {
        #region Implementation of IParentEntityModelOfInt32<OneOfInt32EntityModel>

        /// <summary>
        /// 父实体模型。
        /// </summary>
        public OneOfInt32EntityModel Parent { get; set; }

        /// <summary>
        /// 父实体模型的唯一标识。
        /// </summary>
        public int ParentId { get; set; }

        #endregion
    }
}

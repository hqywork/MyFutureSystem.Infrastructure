/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using HQY.Future.Infrastructure.Domain.EntityModel;

namespace HQY.Future.Infrastructure.EfCore.Test.EntityModel
{
    /// <summary>
    /// 用于测试的 <see cref="ISortOfEntityModel"/> 接口默认实现。
    /// </summary>
    internal class SortOfEntityModel : EntityModelOfGuid, ISortOfEntityModel
    {
        #region Implementation of ISortOfEntityModel

        /// <summary>
        /// 实体的排序因子，一般是一个大于零的整数。
        /// </summary>
        public int Sort { get; set; }

        #endregion
    }
}

/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using HQY.Future.Infrastructure.Domain.EntityModel;

namespace HQY.Future.Infrastructure.EfCore.Test.EntityModel
{
    /// <summary>
    /// 用于测试的 <see cref="IStateOfEntityModel"/> 接口默认实现。
    /// </summary>
    internal class StateOfEntityModel : EntityModelOfGuid, IStateOfEntityModel
    {
        #region Implementation of IStateOfEntityModel

        /// <summary>
        /// 状态。
        /// </summary>
        public int State { get; set; }

        #endregion
    }
}

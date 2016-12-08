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
    /// 用于测试的 <see cref="ITimeOfEntityModel"/> 接口默认实现。
    /// </summary>
    internal class TimeOfEntityModel : EntityModelOfGuid, ITimeOfEntityModel
    {
        #region Implementation of ITimeOfEntityModel

        /// <summary>
        /// 创建时间。
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间。
        /// </summary>
        public DateTime ModifyTime { get; set; }

        #endregion
    }
}

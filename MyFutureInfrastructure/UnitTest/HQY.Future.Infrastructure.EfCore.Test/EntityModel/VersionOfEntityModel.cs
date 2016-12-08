/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using HQY.Future.Infrastructure.Domain.EntityModel;

namespace HQY.Future.Infrastructure.EfCore.Test.EntityModel
{
    /// <summary>
    /// 用于测试的 <see cref="IVersionOfEntityModel"/> 接口默认实现。
    /// </summary>
    public class VersionOfEntityModel : EntityModelOfGuid, IVersionOfEntityModel
    {
        #region Implementation of IVersionOfEntityModel

        /// <summary>
        /// 版本。
        /// </summary>
        public byte[] Version { get; set; }

        #endregion
    }
}

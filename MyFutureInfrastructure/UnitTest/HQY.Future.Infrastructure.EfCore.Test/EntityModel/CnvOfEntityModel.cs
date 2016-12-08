/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using HQY.Future.Infrastructure.Domain.EntityModel;

namespace HQY.Future.Infrastructure.EfCore.Test.EntityModel
{
    /// <summary>
    /// 用于测试的 <see cref="ICnvOfEntityModel"/> 接口默认实现。
    /// </summary>
    public class CnvOfEntityModel : EntityModelOfGuid, ICnvOfEntityModel
    {
        #region Implementation of ICnvOfEntityModel

        /// <summary>
        /// 编号。
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 描述。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 值。
        /// </summary>
        public string Value { get; set; }

        #endregion
    }
}

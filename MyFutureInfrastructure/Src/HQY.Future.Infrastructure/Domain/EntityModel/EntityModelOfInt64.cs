/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月06日	新建
 * 
 *********************************************************************************************************************/

using System;

namespace HQY.Future.Infrastructure.Domain.EntityModel
{
    /// <summary>
    /// 带有 <see cref="Int64"/> 类型唯一标识的实体模型。
    /// </summary>
    public class EntityModelOfInt64 : IEntityModel<Int64>
    {
        #region Implementation of IEntityModel<long>

        /// <summary>
        /// 唯一标识。
        /// </summary>
        public long Id { get; set; }

        #endregion
    }
}

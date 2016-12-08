/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月06日	新建
 * 
 *********************************************************************************************************************/

using System;

namespace HQY.Future.Infrastructure.Domain.EntityModel
{
    /// <summary>
    /// 带有 <see cref="Int32"/> 类型唯一标识的实体模型。
    /// </summary>
    public class EntityModelOfInt32 : IEntityModel<Int32>
    {
        #region Implementation of IEntityModel<int>

        /// <summary>
        /// 唯一标识。
        /// </summary>
        public int Id { get; set; }

        #endregion
    }
}

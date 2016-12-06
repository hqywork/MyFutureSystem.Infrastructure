/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月02日	新建
 * 
 *********************************************************************************************************************/

using System.Collections.Generic;

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Domain
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 实现此接口的实体模型意味着这个实体模型中拥有由子项实体模型构成的集合。
    /// </summary>
    public interface IParentOfEntityModel
    {
        #region Properties

        /// <summary>
        /// 包含了子项的集合。
        /// </summary>
        ICollection<IChildOfEntityModel> Children { get; set; }

        /// <summary>
        /// 子项的数量。
        /// </summary>
        int CountOfChild { get; set; }

        #endregion
    }
}

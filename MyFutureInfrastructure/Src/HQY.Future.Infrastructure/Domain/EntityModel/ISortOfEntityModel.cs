/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月02日	新建
 * 
 *********************************************************************************************************************/

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Domain
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 定义了实体模型的排序属性的接口。
    /// </summary>
    public interface ISortOfEntityModel
    {
        #region Properties

        /// <summary>
        /// 实体的排序因子，一般是一个大于零的整数。
        /// </summary>
        int Sort { get; set; }

        #endregion
    }
}

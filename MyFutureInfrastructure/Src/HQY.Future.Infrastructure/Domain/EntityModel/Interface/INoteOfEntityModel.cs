/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Domain.EntityModel
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 定义了实体模型备注属性的接口。
    /// </summary>
    public interface INoteOfEntityModel
    {
        #region Properties

        /// <summary>
        /// 常规备注。
        /// </summary>
        string Note { get; set; }

        /// <summary>
        /// 第二备注。
        /// </summary>
        string SecondNote { get; set; }

        /// <summary>
        /// 第三备注。
        /// </summary>
        string ThirdNote { get; set; }

        #endregion
    }
}

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
    /// 定义了包含编号、名称、值等属性的实体模型接口。
    /// </summary>
    public interface ICnvOfEntityModel
    {
        #region Properties

        /// <summary>
        /// 编号。
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// 描述。
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// 名称。
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 值。
        /// </summary>
        string Value { get; set; }

        #endregion
    }
}

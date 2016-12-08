/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using System;

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Domain.EntityModel
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// <para>定义了实体模型的时间跟踪属性的接口。</para>
    /// <para>
    /// 一个实体对象的时间跟踪一般包含了对象的创建时间以及最后修改时间。
    /// 创建时间是在实体对象初次产生时定义；最后修改时间会在实体属性每次变更时产生。
    /// </para>
    /// </summary>
    public interface ITimeOfEntityModel
    {
        #region Properties

        /// <summary>
        /// 创建时间。
        /// </summary>
        DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间。
        /// </summary>
        DateTime ModifyTime { get; set; }

        #endregion
    }
}

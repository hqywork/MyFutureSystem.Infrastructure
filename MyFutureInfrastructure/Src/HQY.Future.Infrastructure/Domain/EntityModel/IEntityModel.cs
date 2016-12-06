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
    /// <para>表示对象是一个实体模型。</para>
    /// <para>实体模型是一个业务领域的核心，是业务逻辑的加工焦点。</para>
    /// <para>实体模型可以通过关系映射直接存取物理存储（如数据库等）。</para>
    /// </summary>
    /// <remarks>
    /// 每一个实体模型都会存在一个标识来唯一定位对象，这个唯一标识在一定范围内不会重复。
    /// </remarks>
    /// <typeparam name="T">对象唯一标识的类型。</typeparam>
    public interface IEntityModel<T>
    {
        #region Properties

        /// <summary>
        /// 唯一标识。
        /// </summary>
        T Id { get; set; }

        #endregion
    }
}

/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月04日	新建	
 * 
 *********************************************************************************************************************/

using HQY.Future.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace HQY.Future.Infrastructure
{
    /// <summary>
    /// <para>添加了新增功能的 <see cref="DbContext"/> 派生类。</para>
    /// <para>
    /// 主要功能：
    /// <list type="bullet">
    /// <item>
    /// <term>支持固有实体模型的关系映射策略</term>
    /// </item>
    /// <item>
    /// <term>支持时间跟踪实体模型（<see cref="ITimeOfEntityModel"/>）的值生成策略</term>
    /// </item>
    /// </list>
    /// </para>
    /// </summary>
    public class FutureDbContext : DbContext
    {
        #region Constructors

        /// <summary>
        /// 使用指定的选项设置初始化 <see cref="FutureDbContext" /> 的新实例。
        /// </summary>
        /// <param name="options">用于当前上下文的选项设置。</param>
        public FutureDbContext(DbContextOptions options) : base(options)
        {
        }

        #endregion
    }
}

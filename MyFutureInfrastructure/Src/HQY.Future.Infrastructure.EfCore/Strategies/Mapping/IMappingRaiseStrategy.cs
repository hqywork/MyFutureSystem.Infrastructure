/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月03日	新建	
 * 
 *********************************************************************************************************************/

using Microsoft.EntityFrameworkCore;

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Strategies
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 实体模型关系映射增强处理策略接口。
    /// </summary>
    public interface IMappingRaiseStrategy
    {
        /// <summary>
        /// 返回一个布尔值，指示是否可以进行增强处理。
        /// </summary>
        /// <returns>如果可以进行增强则返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        bool CanRaise();

        /// <summary>
        /// 进行增强处理。
        /// </summary>
        /// <param name="builder">指定当前上下文构建模型的生成器。</param>
        void Raise(ModelBuilder builder);
    }
}

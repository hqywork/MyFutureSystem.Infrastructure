/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月07日	新建
 * 
 *********************************************************************************************************************/

using System;
using Microsoft.EntityFrameworkCore;

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.EfCore.Strategy
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 定义了实体模型属性映射以及模型间关系映射的策略接口。
    /// </summary>
    public interface IMappingStrategy
    {
        /// <summary>
        /// 进行映射处理。
        /// </summary>
        /// <param name="builder">指定当前上下文构建模型的生成器。</param>
        /// <param name="modelType">将要进行映射的实体模型类型。</param>
        /// <exception cref="ArgumentNullException">当 <paramref name="builder"/> 或 <paramref name="modelType"/> 为空引用（<c>null</c>）时引发。</exception>
        void Mapping(ModelBuilder builder, Type modelType);
    }
}

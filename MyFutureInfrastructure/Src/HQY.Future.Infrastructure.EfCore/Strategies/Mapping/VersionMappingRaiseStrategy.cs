/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月03日	新建	
 * 
 *********************************************************************************************************************/

using HQY.Common;
using HQY.Future.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Strategies
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 实现了 <see cref="IVersionOfEntityModel"/> 接口的实体模型关系映射策略。
    /// </summary>
    public class VersionMappingRaiseStrategy<TVersionEntityModel> : IMappingRaiseStrategy
        where TVersionEntityModel : class, IVersionOfEntityModel
    {
        #region Implementation of IMappingRaiseStrategy

        /// <summary>
        /// 返回一个布尔值，指示是否可以进行增强处理。
        /// </summary>
        /// <returns>如果可以进行增强则返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        public bool CanRaise() => true;

        /// <summary>
        /// 进行增强处理。
        /// </summary>
        /// <param name="builder">指定当前上下文构建模型的生成器。</param>
        public void Raise(ModelBuilder builder)
        {
            #region Parameter's Check

            ParamCheck.NotNull(builder, nameof(builder));

            #endregion

            builder.Entity<TVersionEntityModel>()
                .Property(v => v.Version)
                .IsRowVersion();
        }

        #endregion
    }
}

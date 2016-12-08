/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using System;
using HQY.Common;
using HQY.Future.Infrastructure.Domain.EntityModel;
using HQY.Future.Infrastructure.EfCore.Strategy;
using Microsoft.EntityFrameworkCore;

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Strategies
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 应用于 <see cref="ISortOfEntityModel"/> 实现类型的映射策略。
    /// </summary>
    public class SortMappingStrategy : IMappingStrategy
    {
        #region Methods

        /// <summary>
        /// <para>返回一个布尔值，指示 <paramref name="modelType"/> 是否可使用当前策略进行映射。</para>
        /// <para>可以在派生类中重写此方法，定义自己的策略可用规则。</para>
        /// </summary>
        /// <param name="modelType">将要进行映射的实体模型类型。</param>
        /// <returns>如果可以应用映射策略则返回真（<c>true</c>）；否则返回假（<c>false</c>）。</returns>
        protected virtual bool CanMapping(Type modelType)
        {
            return modelType.IsDerivedFrom(typeof(ISortOfEntityModel));
        }

        #endregion

        #region Implementation of IMappingStrategy

        /// <summary>
        /// 进行映射处理。
        /// </summary>
        /// <param name="builder">指定当前上下文构建模型的生成器。</param>
        /// <param name="modelType">将要进行映射的实体模型类型。</param>
        /// <exception cref="ArgumentNullException">当 <paramref name="builder"/> 或 <paramref name="modelType"/> 为空引用（<c>null</c>）时引发。</exception>
        public void Mapping(ModelBuilder builder, Type modelType)
        {
            #region Parameter Check

            ParamCheck.NotNull(builder, nameof(builder));
            ParamCheck.NotNull(modelType, nameof(modelType));

            #endregion

            // 检查可用性。
            if (!this.CanMapping(modelType)) return;

            var typeBuilder = builder.Entity(modelType);
            typeBuilder.Property(nameof(ISortOfEntityModel.Sort))
                       .IsRequired();
        }

        #endregion
    }
}

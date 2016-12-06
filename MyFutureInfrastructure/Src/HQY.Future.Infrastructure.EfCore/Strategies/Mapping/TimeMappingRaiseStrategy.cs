﻿/**********************************************************************************************************************
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
    /// 实现了 <see cref="ITimeOfEntityModel"/> 接口的实体模型关系映射策略。
    /// </summary>
    /// <typeparam name="TTimeEntityModel">指定实体模型的类型。</typeparam>
    public class TimeMappingRaiseStrategy<TTimeEntityModel> : IMappingRaiseStrategy
        where TTimeEntityModel:class, ITimeOfEntityModel
    {
        #region Implementation of IMappingRaiseStrategy

        /// <summary>
        /// 返回一个布尔值，指示是否可以进行增强处理。
        /// </summary>
        /// <returns>如果可以进行增强则返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        public virtual bool CanRaise() => true;

        /// <summary>
        /// 进行增强处理。
        /// </summary>
        /// <param name="builder">指定当前上下文构建模型的生成器。</param>
        public virtual void Raise(ModelBuilder builder)
        {
            #region Parameter's Check

            ParamCheck.NotNull(builder, nameof(builder));

            #endregion

            var typeBuilder = builder.Entity<TTimeEntityModel>();

            typeBuilder.Property(t => t.CreateTime).IsRequired();
            typeBuilder.Property(t => t.ModifyTime).IsRequired();
        }

        #endregion
    }
}

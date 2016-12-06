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
    /// 实现了 <see cref="IChildOfEntityModel{TParentId}"/> 接口的实体模型关系映射策略。
    /// </summary>
    /// <typeparam name="TChildEntityModel">指定实体模型的类型。</typeparam>
    /// <typeparam name="TParentId">指定实体模型关联的父项唯一标识的类型。</typeparam>
    public class ChildMappingRaiseStrategy<TChildEntityModel, TParentId> : IMappingRaiseStrategy
        where TChildEntityModel : class, IChildOfEntityModel<TParentId>
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

            builder.Entity<TChildEntityModel>()
                   .Property(p => p.ParentId)
                   .IsRequired();
        }

        #endregion
    }
}

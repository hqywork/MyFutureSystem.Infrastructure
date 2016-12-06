/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月02日	新建	
 * 
 *********************************************************************************************************************/

using System;
using HQY.Common;
using HQY.Future.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.Strategies
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 实现了 <see cref="IEntityModel{T}"/> 接口的实体模型关系映射策略。
    /// </summary>
    /// <typeparam name="TEnityModel">指定实体模型类型。</typeparam>
    /// <typeparam name="TId">指定实体模型唯一标识类型。</typeparam>
    public class EntityModelMappingRaiseStrategy<TEnityModel, TId> : IMappingRaiseStrategy
        where TEnityModel : class, IEntityModel<TId>
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

            // 根据模型类型计算对应的存储表名称。
            string modelTypeName = typeof(TEnityModel).Name;
            string tableName = modelTypeName.Replace("EntityModel", String.Empty)
                                            .Replace("Model", String.Empty)
                                            .Replace("Entity", String.Empty);
            // 如果表名称为空，则使用类型名称替代。
            if (String.IsNullOrEmpty(tableName)) tableName = modelTypeName;

            var typeBuilder = builder.Entity<TEnityModel>();
            typeBuilder.ToTable(tableName);
            typeBuilder.HasKey(nameof(IEntityModel<Object>.Id))
                       .HasName($"PK_{tableName}_{nameof(IEntityModel<TId>.Id)}");
        }

        #endregion
    }
}

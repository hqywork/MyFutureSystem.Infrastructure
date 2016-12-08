/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月02日	新建
 *      作者：张奇  时间：2016年12月06日	从项目“CST.Infrastructure”移植
 *      作者：张奇  时间：2016年12月08日	重新修正策略实现方式，引用模板方法模式
 * 
 *********************************************************************************************************************/

using System;
using HQY.Common;
using HQY.Future.Infrastructure.Domain.EntityModel;
using Microsoft.EntityFrameworkCore;

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.EfCore.Strategy
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 应用于 <see cref="IChildEntityModelOfInt64{TChildModel}"/> 实现类型的映射策略。
    /// </summary>
    public class ChildOfInt64MappingStrategy : IMappingStrategy
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
            return modelType.IsDerivedFrom(typeof(IChildEntityModelOfInt64<>));
        }

        #endregion

        #region Implementation of IMappingStrategy

        /// <summary>
        /// 进行映射处理。
        /// </summary>
        /// <param name="builder">指定当前上下文构建模型的生成器。</param>
        /// <param name="modelType">将要进行映射的实体模型类型。</param>
        /// <exception cref="ArgumentNullException">当 <paramref name="builder"/> 或 <paramref name="modelType"/> 为空引用（<c>null</c>）时引发。</exception>
        public virtual void Mapping(ModelBuilder builder, Type modelType)
        {
            #region Parameter Check

            ParamCheck.NotNull(builder, nameof(builder));
            ParamCheck.NotNull(modelType, nameof(modelType));

            #endregion
            
            // 检查可用性。
            if (!this.CanMapping(modelType)) return;

            // 映射实体类型。
            var typeBuilder = builder.Entity(modelType);

            // 映射实体属性。
            typeBuilder.Property(nameof(IChildEntityModelOfInt64<EntityModelOfInt64>.CountOfChild))
                       .IsRequired();

            // 获取子实体模型的类型。
            var cEntityModelType = modelType.FindManyTypeFromOne();

            // 获取子实体类型（EF 中的 EntityType）。
            var cEntityType = builder.Model.FindEntityType(cEntityModelType);
            // 获取子实体模型对应原表名称。
            var cTableName = cEntityType.Relational().TableName;

            // 映射“One-to-Many”关系。
            typeBuilder.HasMany(cEntityModelType,
                                nameof(IChildEntityModelOfInt64<EntityModelOfInt64>.Children))
                       .WithOne(nameof(IParentEntityModelOfInt64<EntityModelOfInt64>.Parent))
                       .HasForeignKey(nameof(IParentEntityModelOfInt64<EntityModelOfInt64>.ParentId))
                       .HasConstraintName($"FK_{cTableName}_{nameof(IParentEntityModelOfInt64<EntityModelOfInt64>.ParentId)}");
        }

        #endregion
    }
}

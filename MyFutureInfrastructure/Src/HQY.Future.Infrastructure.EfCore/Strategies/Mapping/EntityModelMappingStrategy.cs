/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月07日	新建
 * 
 *********************************************************************************************************************/

using System;
using HQY.Common;
using HQY.Future.Infrastructure.Domain;
using HQY.Future.Infrastructure.Domain.EntityModel;
using Microsoft.EntityFrameworkCore;

// ReSharper disable CheckNamespace
namespace HQY.Future.Infrastructure.EfCore.Strategy
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 应用于 <see cref="IEntityModel{T}"/> 实现类型的映射策略。
    /// </summary>
    public class EntityModelMappingStrategy : IMappingStrategy
    {
        #region Methods

        private string GetIdName(Type modelType)
        {
            if (modelType.IsDerivedFrom<EntityModelOfGuid>()) return nameof(EntityModelOfGuid.Id);
            if (modelType.IsDerivedFrom<EntityModelOfInt32>()) return nameof(EntityModelOfInt32.Id);
            if (modelType.IsDerivedFrom<EntityModelOfInt64>()) return nameof(EntityModelOfInt64.Id);

            return "Id";
        }

        /// <summary>
        /// <para>返回一个布尔值，指示 <paramref name="modelType"/> 是否可使用当前策略进行映射。</para>
        /// <para>可以在派生类中重写此方法，定义自己的策略可用规则。</para>
        /// </summary>
        /// <param name="modelType">将要进行映射的实体模型类型。</param>
        /// <returns>如果可以应用映射策略则返回真（<c>true</c>）；否则返回假（<c>false</c>）。</returns>
        protected virtual bool CanMapping(Type modelType)
        {
            return modelType.IsDerivedFrom(typeof(IEntityModel<>));
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

            #region 映射的目的表名称

            string modelTypeName = modelType.Name;
            string tableName = modelTypeName.Replace("EntityModel", String.Empty)
                                            .Replace("Model", String.Empty)
                                            .Replace("Entity", String.Empty);
            // 如果表名称为空，则使用类型名称替代。
            if (String.IsNullOrEmpty(tableName)) tableName = modelTypeName;

            #endregion

            // 主键 ID 的名称。
            string idName = this.GetIdName(modelType);

            var typeBuilder = builder.Entity(modelType);
            typeBuilder.ToTable(tableName)
                       .HasKey(idName)
                       .HasName($"PK_{tableName}_{idName}");
        }

        #endregion
    }
}

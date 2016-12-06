/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月03日	新建	
 * 
 *********************************************************************************************************************/

using System;
using System.Linq;
using HQY.Common;
using HQY.Future.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace HQY.Future.Infrastructure.Strategies.Mapping
{
    /// <summary>
    /// 实现了 <see cref="IParentOfEntityModel"/> 接口的实体模型关系映射策略。
    /// </summary>
    public class ParentMappingRaiseStrategy<TParentEntityModel, TChildEntityModel> : IMappingRaiseStrategy
        where TParentEntityModel : class, IParentOfEntityModel
        where TChildEntityModel:class, IChildOfEntityModel
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
        public void Raise(ModelBuilder builder)
        {
            #region Parameter's Check

            ParamCheck.NotNull(builder, nameof(builder));

            #endregion

            var typeBuilder = builder.Entity<TParentEntityModel>();

            typeBuilder.Property(p => p.CountOfChild)
                       .IsRequired()
                       .HasDefaultValue(0);

            // 获取子项实体模型对象的表名称。
            var tableNameObj = builder.Entity<TChildEntityModel>()
                                      .Metadata.GetAnnotations()
                                      .FirstOrDefault(s => s.Name.EndsWith("TableName"));
            string tableName = tableNameObj != null ? (string) tableNameObj.Value : String.Empty;

            typeBuilder.HasMany(typeof(TChildEntityModel), nameof(IParentOfEntityModel.Children))
                       .WithOne(nameof(IChildOfEntityModel.Parent))
                       .HasForeignKey(nameof(IChildOfEntityModel<Object>.ParentId))
                       .HasConstraintName($"FK_{tableName}_{nameof(IChildOfEntityModel<Object>.ParentId)}");
        }

        #endregion
    }
}

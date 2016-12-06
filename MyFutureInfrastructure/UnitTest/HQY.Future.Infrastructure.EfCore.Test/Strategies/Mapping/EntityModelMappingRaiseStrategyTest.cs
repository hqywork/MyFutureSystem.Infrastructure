/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月04日	新建	
 * 
 *********************************************************************************************************************/

using System;
using System.Linq;
using HQY.Future.Infrastructure.Domain;
using HQY.Future.Infrastructure.Strategies;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HQY.Future.Infrastructure.EfCore.Test.Strategies.Mapping
{
    /// <summary>
    /// <see cref="EntityModelMappingRaiseStrategy{TEnityModel, TId}"/> 单元测试。
    /// </summary>
    public class EntityModelMappingRaiseStrategyTest
    {
        #region Test's Models

        /// <summary>
        /// <see cref="EntityModelMappingRaiseStrategy{TEnityModel,TId}.Raise(ModelBuilder)"/> 方法单元测试。
        /// </summary>
        [Fact(DisplayName = "EntityModelMappingRaiseStrategy.Raise")]
        public void RaiseTest()
        {
            var strategy = new EntityModelMappingRaiseStrategy<EntityModel, Guid>();

            using (var context = new DbContextByMappingRaiseStrategy(builder => strategy.Raise(builder)))
            {
                for (int i = 0; i < 10; i++)
                    context.Add(new EntityModel());

                context.SaveChanges();
            }

            using (var context = new DbContextByMappingRaiseStrategy(builder => strategy.Raise(builder)))
            {
                //Assert.Equal("EntityModel", context.Model.FindEntityType(typeof(EntityModel)).Relational().TableName);
                var datas = context.Set<EntityModel>().ToList();
                Assert.Equal(datas.Count, 10);
                Assert.All(datas, data => Assert.True(data.Id != Guid.Empty));
            }
        }

        #endregion

        #region Extra test Code

        private class EntityModel : IEntityModel<Guid>
        {
            #region Implementation of IEntityModel<Guid>

            /// <summary>
            /// 唯一标识。
            /// </summary>
            public Guid Id { get; set; }

            #endregion
        }

        #endregion
    }
}

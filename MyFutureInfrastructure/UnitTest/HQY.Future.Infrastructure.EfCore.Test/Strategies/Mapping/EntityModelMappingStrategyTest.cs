/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月07日	新建
 * 
 *********************************************************************************************************************/

using System;
using System.Linq;
using HQY.Future.Infrastructure.EfCore.Strategy;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HQY.Future.Infrastructure.EfCore.Test.Strategies.Mapping
{
    /// <summary>
    /// <see cref="EntityModelMappingStrategy"/> 单元测试。
    /// </summary>
    public class EntityModelMappingStrategyTest
    {
        /// <summary>
        /// <see cref="EntityModelMappingStrategy.Mapping(ModelBuilder, Type)"/> 方法单元测试。
        /// </summary>
        [Fact(DisplayName = "EntityModelMappingStrategy.Mapping")]
        public void MappingTest()
        {
            var strategy = new EntityModelMappingStrategy();

            using (var context = new DbContextByMappingStrategy(builder => strategy.Mapping(builder, typeof(EntityModel.EntityModel))))
            {
                for (int i = 0; i < 10; i++)
                    context.Add(new EntityModel.EntityModel());

                context.SaveChanges();
            }

            using (var context = new DbContextByMappingStrategy(builder => strategy.Mapping(builder, typeof(EntityModel.EntityModel))))
            {
                var datas = context.Set<EntityModel.EntityModel>().ToList();
                Assert.NotNull(datas);
                Assert.Equal(10, datas.Count);
                Assert.All(datas, data => Assert.NotEqual(Guid.Empty, data.Id));
            }
        }
    }
}

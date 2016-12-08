/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using System;
using System.Linq;
using HQY.Future.Infrastructure.EfCore.Strategy;
using HQY.Future.Infrastructure.EfCore.Test.EntityModel;
using HQY.Future.Infrastructure.Strategies;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HQY.Future.Infrastructure.EfCore.Test.Strategies.Mapping
{
    /// <summary>
    /// <see cref="SortMappingStrategy"/> 单元测试。
    /// </summary>
    public class SortMappingStrategyTest
    {
        /// <summary>
        /// <see cref="SortMappingStrategy.Mapping(ModelBuilder, Type)"/> 方法单元测试。
        /// </summary>
        [Fact(DisplayName = "SortMappingStrategy.Mapping")]
        public void MappingTest()
        {
            var emStrategy = new EntityModelMappingStrategy();
            var smStrategy = new SortMappingStrategy();

            Action<ModelBuilder> action = builder =>
            {
                emStrategy.Mapping(builder, typeof(SortOfEntityModel));
                smStrategy.Mapping(builder, typeof(SortOfEntityModel));
            };

            using (var context = new DbContextByMappingStrategy(action))
            {
                for (int i = 0; i < 10; i++)
                    context.Sorts.Add(new SortOfEntityModel {Sort = i+1});

                context.SaveChanges();
            }

            using (var context = new DbContextByMappingStrategy(action))
            {
                var datas = context.Set<SortOfEntityModel>().ToList();

                Assert.NotNull(datas);
                Assert.Equal(10, datas.Count);
                for (int i = 0; i < 10; i++)
                {
                    Assert.NotEqual(Guid.Empty, datas[0].Id);
                    Assert.Equal(i + 1, datas[i].Sort);
                }
            }
        }
    }
}

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
    /// <see cref="VersionMappingStrategy"/> 单元测试。
    /// </summary>
    public class VersionMappingStrategyTest
    {
        /// <summary>
        /// <see cref="VersionMappingStrategy.Mapping(ModelBuilder, Type)"/> 方法单元测试。
        /// </summary>
        [Fact(DisplayName = "VersionMappingStrategy.Mapping")]
        public void MappingTest()
        {
            var emStrategy = new EntityModelMappingStrategy();
            var vmStrategy = new VersionMappingStrategy();

            Action<ModelBuilder> action = builder =>
            {
                emStrategy.Mapping(builder, typeof(VersionOfEntityModel));
                vmStrategy.Mapping(builder, typeof(VersionOfEntityModel));
            };

            using (var context = new DbContextByMappingStrategy(action))
            {
                for (int i = 0; i < 10; i++)
                    context.Versions.Add(new VersionOfEntityModel {Version = new byte[] {1, 2, 3, 4, 5, 6}});

                context.SaveChanges();
            }

            using (var context = new DbContextByMappingStrategy(action))
            {
                var datas = context.Versions.ToList();

                Assert.NotNull(datas);
                Assert.Equal(10, datas.Count);
                Assert.All(datas, data =>
                           {
                               Assert.NotEqual(Guid.Empty, data.Id);
                               Assert.NotNull(data.Version);
                               Assert.NotEqual(0, data.Version.Length);
                           });
            }
        }
    }
}

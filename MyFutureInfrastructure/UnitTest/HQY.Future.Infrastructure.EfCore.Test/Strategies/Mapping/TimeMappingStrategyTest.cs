/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using System;
using System.Linq;
using CST.Infrastructure.EfCore.Strategy;
using HQY.Future.Infrastructure.EfCore.Strategy;
using HQY.Future.Infrastructure.EfCore.Test.EntityModel;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HQY.Future.Infrastructure.EfCore.Test.Strategies.Mapping
{
    /// <summary>
    /// <see cref="TimeMappingStrategy"/> 单元测试。
    /// </summary>
    public class TimeMappingStrategyTest
    {
        /// <summary>
        /// <see cref="TimeMappingStrategy.Mapping(ModelBuilder, Type)"/> 方法单元测试。
        /// </summary>
        [Fact(DisplayName = "TimeMappingStrategy.Mapping")]
        public void MappingTest()
        {
            var emStrategy = new EntityModelMappingStrategy();
            var tmStrategy = new TimeMappingStrategy();

            Action<ModelBuilder> action = builder =>
            {
                emStrategy.Mapping(builder, typeof(TimeOfEntityModel));
                tmStrategy.Mapping(builder, typeof(TimeOfEntityModel));
            };

            using (var context = new DbContextByMappingStrategy(action))
            {
                for (int i = 0; i < 10; i++)
                    context.Times.Add(new TimeOfEntityModel
                                      {
                                          CreateTime = DateTime.MinValue,
                                          ModifyTime = DateTime.MaxValue
                                      });

                context.SaveChanges();
            }

            using (var context = new DbContextByMappingStrategy(action))
            {
                var datas = context.Times.ToList();

                Assert.NotNull(datas);
                Assert.Equal(10, datas.Count);
                Assert.All(datas, data =>
                           {
                               Assert.Equal(DateTime.MinValue, data.CreateTime);
                               Assert.Equal(DateTime.MaxValue, data.ModifyTime);
                           });
            }
        }
    }
}

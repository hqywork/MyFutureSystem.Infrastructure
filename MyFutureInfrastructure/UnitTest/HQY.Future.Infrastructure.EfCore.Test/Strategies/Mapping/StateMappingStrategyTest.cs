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
    /// <see cref="StateMappingStrategy"/> 单元测试。
    /// </summary>
    public class StateMappingStrategyTest
    {
        /// <summary>
        /// <see cref="StateMappingStrategy.Mapping(ModelBuilder, Type)"/> 方法单元测试。
        /// </summary>
        [Fact(DisplayName = "StateMappingRaiseStrategy.Mapping")]
        public void MappingTest()
        {
            var emStrategy = new EntityModelMappingStrategy();
            var smStrategy = new StateMappingStrategy();

            Action<ModelBuilder> action = builder =>
            {
                emStrategy.Mapping(builder, typeof(StateOfEntityModel));
                smStrategy.Mapping(builder, typeof(StateOfEntityModel));
            };

            using (var context = new DbContextByMappingStrategy(action))
            {
                for (int i = 0; i < 10; i++)
                    context.States.Add(new StateOfEntityModel {State = i});

                context.SaveChanges();
            }

            using (var context = new DbContextByMappingStrategy(action))
            {
                var datas = context.States.ToList();

                Assert.NotNull(datas);
                Assert.Equal(10, datas.Count);
                for (int i = 0; i < datas.Count; i++)
                {
                    Assert.NotEqual(Guid.Empty, datas[i].Id);
                    Assert.Equal(i, datas[i].State);
                }
            }
        }
    }
}

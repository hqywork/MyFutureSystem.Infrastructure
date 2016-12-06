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
    /// <see cref="StateMappingRaiseStrategy{TStateEntityModel}"/> 单元测试。
    /// </summary>
    public class StateMappingRaiseStrategyTest
    {
        #region Test's Models

        /// <summary>
        /// <see cref="StateMappingRaiseStrategy{TStateEntityModel}.Raise(ModelBuilder)"/> 方法单元测试。
        /// </summary>
        [Fact(DisplayName = "StateMappingRaiseStrategy.Raise")]
        public void RaiseTest()
        {
            var emStrategy = new EntityModelMappingRaiseStrategy<StateEntityModel, Guid>();
            var smStrategy = new StateMappingRaiseStrategy<StateEntityModel>();

            Action<ModelBuilder> action = builder =>
            {
                emStrategy.Raise(builder);
                smStrategy.Raise(builder);
            };

            using (var context = new DbContextByMappingRaiseStrategy(action))
            {
                for (int i = 0; i < 10; i++)
                    context.Add(new StateEntityModel { State = i });

                context.SaveChanges();
            }

            using (var context = new DbContextByMappingRaiseStrategy(action))
            {
                Assert.Equal("State", context.Model.FindEntityType(typeof(StateEntityModel)).Relational().TableName);

                var datas = context.Set<StateEntityModel>().ToList();
                Assert.NotNull(datas);
                Assert.Equal(10, datas.Count);
                Assert.Collection(datas,
                                  data => Assert.Equal(data.State, 0),
                                  data => Assert.Equal(data.State, 1),
                                  data => Assert.Equal(data.State, 2),
                                  data => Assert.Equal(data.State, 3),
                                  data => Assert.Equal(data.State, 4),
                                  data => Assert.Equal(data.State, 5),
                                  data => Assert.Equal(data.State, 6),
                                  data => Assert.Equal(data.State, 7),
                                  data => Assert.Equal(data.State, 8),
                                  data => Assert.Equal(data.State, 9));
            }
        }

        #endregion

        #region Extra test Code

        private class StateEntityModel : IEntityModel<Guid>, IStateOfEntityModel
        {
            #region Implementation of IEntityModel<decimal>

            /// <summary>
            /// 唯一标识。
            /// </summary>
            public Guid Id { get; set; }

            #endregion

            #region Implementation of IStateOfEntityModel

            /// <summary>
            /// 状态。
            /// </summary>
            public int State { get; set; }

            #endregion
        }

        #endregion
    }
}

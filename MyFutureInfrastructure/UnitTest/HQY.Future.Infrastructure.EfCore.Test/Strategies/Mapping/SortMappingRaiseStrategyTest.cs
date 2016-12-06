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
    /// <see cref="SortMappingRaiseStrategy{TSortEntityModel}"/> 单元测试。
    /// </summary>
    public class SortMappingRaiseStrategyTest
    {
        #region Test's Models

        /// <summary>
        /// <see cref="SortMappingRaiseStrategy{TSortEntityModel}.Raise(ModelBuilder)"/> 方法单元测试。
        /// </summary>
        [Fact(DisplayName = "SortMappingRaiseStrategy.Raise")]
        public void RaiseTest()
        {
            var emStrategy = new EntityModelMappingRaiseStrategy<SortEntityModel, Int32>();
            var smStrategy = new SortMappingRaiseStrategy<SortEntityModel>();

            Action<ModelBuilder> action = builder =>
            {
                emStrategy.Raise(builder);
                smStrategy.Raise(builder);
            };

            using (var context = new DbContextByMappingRaiseStrategy(action))
            {
                for (int i = 10; i > 0; i--)
                    context.Add(new SortEntityModel {Sort = i});

                context.SaveChanges();
            }

            using (var context = new DbContextByMappingRaiseStrategy(action))
            {
                Assert.Equal("Sort", context.Model.FindEntityType(typeof(SortEntityModel)).Relational().TableName);

                var datas = context.Set<SortEntityModel>()
                    .OrderBy(o => o.Sort)
                    .ToList();

                Assert.NotNull(datas);
                Assert.Equal(10, datas.Count);
                Assert.Collection(datas,
                                  data => Assert.Equal(data.Sort, 1),
                                  data => Assert.Equal(data.Sort, 2),
                                  data => Assert.Equal(data.Sort, 3),
                                  data => Assert.Equal(data.Sort, 4),
                                  data => Assert.Equal(data.Sort, 5),
                                  data => Assert.Equal(data.Sort, 6),
                                  data => Assert.Equal(data.Sort, 7),
                                  data => Assert.Equal(data.Sort, 8),
                                  data => Assert.Equal(data.Sort, 9),
                                  data => Assert.Equal(data.Sort, 10));
            }
        }

        #endregion

        #region Extra test Code

        private class SortEntityModel : IEntityModel<Int32>, ISortOfEntityModel
        {
            #region Implementation of IEntityModel<int>

            /// <summary>
            /// 唯一标识。
            /// </summary>
            public int Id { get; set; }

            #endregion

            #region Implementation of ISortOfEntityModel

            /// <summary>
            /// 实体的排序因子，一般是一个大于零的整数。
            /// </summary>
            public int Sort { get; set; }

            #endregion
        }

        #endregion
    }
}

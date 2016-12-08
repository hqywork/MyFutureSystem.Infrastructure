/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using System;
using System.Linq;
using HQY.Future.Infrastructure.EfCore.Strategy;
using HQY.Future.Infrastructure.EfCore.Test.EntityModel;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HQY.Future.Infrastructure.EfCore.Test.Strategies.Mapping
{
    /// <summary>
    /// <see cref="CnvMappingStrategy"/> 单元测试。
    /// </summary>
    public class CnvMappingStrategyTest
    {
        /// <summary>
        /// <see cref="CnvMappingStrategy.Mapping(ModelBuilder, Type)"/> 方法单元测试。
        /// </summary>
        [Fact(DisplayName = "CnvMappingStrategy.Mapping")]
        public void MappingTest()
        {
            var emStrategy = new EntityModelMappingStrategy();
            var cmStrategy = new CnvMappingStrategy();

            Action<ModelBuilder> action = builder =>
            {
                emStrategy.Mapping(builder, typeof(CnvOfEntityModel));
                cmStrategy.Mapping(builder, typeof(CnvOfEntityModel));
            };

            using (var context = new DbContextByMappingStrategy(action))
            {
                for (int i = 0; i < 10; i++)
                    context.Cnvs.Add(new CnvOfEntityModel
                                     {
                                         Code = $"C_00{i}",
                                         Description = $"D_{i}",
                                         Name = $"N_{i}",
                                         Value = $"V_{i}"
                                     });

                context.SaveChanges();
            }

            using (var context = new DbContextByMappingStrategy(action))
            {
                var datas = context.Cnvs.ToList();

                Assert.NotNull(datas);
                Assert.Equal(10, datas.Count);
                for (int i = 0; i < 10; i++)
                {
                    Assert.NotEqual(Guid.Empty, datas[0].Id);
                    Assert.Equal($"C_00{i}", datas[i].Code);
                    Assert.Equal($"D_{i}", datas[i].Description);
                    Assert.Equal($"N_{i}", datas[i].Name);
                    Assert.Equal($"V_{i}", datas[i].Value);
                }
            }
        }
    }
}

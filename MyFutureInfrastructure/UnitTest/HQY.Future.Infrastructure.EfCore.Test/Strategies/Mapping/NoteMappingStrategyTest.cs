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
    /// <see cref="NoteMappingStrategy"/> 单元测试。
    /// </summary>
    public class NoteMappingStrategyTest
    {
        /// <summary>
        /// <see cref="NoteMappingStrategy.Mapping(ModelBuilder, Type)"/> 方法单元测试。
        /// </summary>
        [Fact(DisplayName = "NoteMappingStrategy.Mapping")]
        public void MappingTest()
        {
            var emStrategy = new EntityModelMappingStrategy();
            var nmStrategy = new NoteMappingStrategy();

            Action<ModelBuilder> action = builder =>
            {
                emStrategy.Mapping(builder, typeof(NoteOfEntityModel));
                nmStrategy.Mapping(builder, typeof(NoteOfEntityModel));
            };

            using (var context = new DbContextByMappingStrategy(action))
            {
                for (int i = 0; i < 10; i++)
                    context.Add(new NoteOfEntityModel
                                {
                                    Note = $"Note_{i}",
                                    SecondNote = $"SecondNote_{i}",
                                    ThirdNote = $"ThirdNote_{i}"
                                });

                context.SaveChanges();
            }

            using (var context = new DbContextByMappingStrategy(action))
            {
                var datas = context.Notes.ToList();
                Assert.NotNull(datas);
                Assert.Equal(10, datas.Count);
                for (int i = 0; i < 10; i++)
                {
                    Assert.NotEqual(Guid.Empty, datas[i].Id);
                    Assert.Equal($"Note_{i}", datas[i].Note);
                    Assert.Equal($"SecondNote_{i}", datas[i].SecondNote);
                    Assert.Equal($"ThirdNote_{i}", datas[i].ThirdNote);
                }
            }
        }
    }
}

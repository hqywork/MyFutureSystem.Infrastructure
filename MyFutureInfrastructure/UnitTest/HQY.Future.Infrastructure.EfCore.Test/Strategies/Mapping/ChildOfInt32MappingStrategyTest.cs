/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using HQY.Future.Infrastructure.EfCore.Strategy;
using HQY.Future.Infrastructure.EfCore.Test.EntityModel;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HQY.Future.Infrastructure.EfCore.Test.Strategies.Mapping
{
    /// <summary>
    /// <see cref="ChildOfInt32MappingStrategy"/> 单元测试。
    /// </summary>
    public class ChildOfInt32MappingStrategyTest
    {
        /// <summary>
        /// <see cref="ChildOfInt32MappingStrategy.Mapping(ModelBuilder, Type)"/> 方法单元测试。
        /// </summary>
        [Fact(DisplayName = "ChildOfInt32MappingStrategy.Mapping")]
        public void MappingTest()
        {
            var emStrategy = new EntityModelMappingStrategy();
            var cogmStrategy = new ChildOfGuidMappingStrategy();
            var pogmStrategy = new ParentOfGuidMappingStrategy();

            Action<ModelBuilder> mappingAction = modelBuild =>
            {
                emStrategy.Mapping(modelBuild, typeof(OneOfInt32EntityModel));
                cogmStrategy.Mapping(modelBuild, typeof(OneOfInt32EntityModel));
                pogmStrategy.Mapping(modelBuild, typeof(ManyOfInt32EntityModel));
            };

            using (var context = new DbContextByMappingStrategy(mappingAction))
            {
                var oneEntityModel = new OneOfInt32EntityModel
                {
                                         CountOfChild = 10,
                                         Children = new List<ManyOfInt32EntityModel>(10)
                                     };
                for (int i = 0; i < 10; i++)
                    oneEntityModel.Children.Add(new ManyOfInt32EntityModel { Parent = oneEntityModel});

                context.Add(oneEntityModel);
                Assert.Equal(11, context.SaveChanges());
            }

            using (var context = new DbContextByMappingStrategy(mappingAction))
            {
                var data = context.Set<OneOfInt32EntityModel>()
                                  .Include(one => one.Children)
                                  .SingleOrDefault();

                Assert.NotNull(data);
                Assert.NotEqual(0, data.Id);
                Assert.Equal(10, data.CountOfChild);
                Assert.NotNull(data.Children);
                Assert.Equal(10, data.Children.Count);
                Assert.All(data.Children.AsEnumerable(), child =>
                           {
                               Assert.NotEqual(0, child.Id);
                               Assert.Equal(data.Id, child.ParentId);
                               Assert.NotNull(child.Parent);
                               Assert.Equal(child.ParentId, child.Parent.Id);
                           });
            }
        }
    }
}

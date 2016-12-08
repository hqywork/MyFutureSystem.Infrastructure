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
    /// <see cref="ChildOfGuidMappingStrategy"/> 单元测试。
    /// </summary>
    public class ChildOfGuidMappingStrategyTest
    {
        /// <summary>
        /// <see cref="ChildOfGuidMappingStrategy.Mapping(ModelBuilder, Type)"/> 方法单元测试。
        /// </summary>
        [Fact(DisplayName = "ChildOfGuidMappingStrategy.Mapping")]
        public void MappingTest()
        {
            var emStrategy = new EntityModelMappingStrategy();
            var cogmStrategy = new ChildOfGuidMappingStrategy();
            var pogmStrategy = new ParentOfGuidMappingStrategy();

            Action<ModelBuilder> mappingAction = modelBuild =>
            {
                emStrategy.Mapping(modelBuild, typeof(OneOfGuidEntityModel));
                cogmStrategy.Mapping(modelBuild, typeof(OneOfGuidEntityModel));
                pogmStrategy.Mapping(modelBuild, typeof(ManyOfGuidEntityModel));
            };

            using (var context = new DbContextByMappingStrategy(mappingAction))
            {
                var oneEntityModel = new OneOfGuidEntityModel
                                     {
                                         CountOfChild = 10,
                                         Children = new List<ManyOfGuidEntityModel>(10)
                                     };
                for (int i = 0; i < 10; i++)
                    oneEntityModel.Children.Add(new ManyOfGuidEntityModel {Parent = oneEntityModel});

                context.Add(oneEntityModel);
                Assert.Equal(11, context.SaveChanges());
            }

            using (var context = new DbContextByMappingStrategy(mappingAction))
            {
                var data = context.Set<OneOfGuidEntityModel>()
                                  .Include(one => one.Children)
                                  .SingleOrDefault();

                Assert.NotNull(data);
                Assert.NotEqual(Guid.Empty, data.Id);
                Assert.Equal(10, data.CountOfChild);
                Assert.NotNull(data.Children);
                Assert.Equal(10, data.Children.Count);
                Assert.All(data.Children.AsEnumerable(), child =>
                           {
                               Assert.NotEqual(Guid.Empty, child.Id);
                               Assert.Equal(data.Id, child.ParentId);
                               Assert.NotNull(child.Parent);
                               Assert.Equal(child.ParentId, child.Parent.Id);
                           });
            }
        }
    }
}

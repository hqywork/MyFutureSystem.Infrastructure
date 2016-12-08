/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using System;
using HQY.Future.Infrastructure.Domain.EntityModel;
using Xunit;

namespace HQY.Future.Infrastructure.Test.DomainModel
{
    /// <summary>
    /// <see cref="EntityModelTypeExtensions"/> 单元测试。
    /// </summary>
    public class EntityModelTypeExtensionsTest
    {
        /// <summary>
        /// <see cref="EntityModelTypeExtensions.FindManyTypeFromOne(Type)"/> 方法单元测试。
        /// </summary>
        [Theory(DisplayName = "EntityModelTypeExtensions.FindManyTypeFromOne")]
        [InlineData(null, typeof(ArgumentNullException), "oneType", null)]
        [InlineData(typeof(EntityModel), typeof(InvalidOperationException), null, null)]
        [InlineData(typeof(OneOfGuidEntityModel), null, null, typeof(ManyOfGuidEntityModel))]
        [InlineData(typeof(OneOfInt32EntityModel), null, null, typeof(ManyOfInt32EntityModel))]
        [InlineData(typeof(OneOfInt64EntityModel), null, null, typeof(ManyOfInt64EntityModel))]
        public void FindManyTypeFromOneTest(Type type, Type exType, string paramName, Type resultType)
        {
            if (exType != null)
            {
                if (String.IsNullOrEmpty(paramName))
                    Assert.Throws<InvalidOperationException>(() => EntityModelTypeExtensions.FindManyTypeFromOne(type));
                else
                {
                    var ex =
                        Assert.Throws<ArgumentNullException>(() => EntityModelTypeExtensions.FindManyTypeFromOne(type));
                    Assert.Equal(paramName, ex.ParamName);
                }
            }
            else
                Assert.Equal(resultType, EntityModelTypeExtensions.FindManyTypeFromOne(type));
        }
    }
}

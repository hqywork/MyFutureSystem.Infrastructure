/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月07日	新建	
 * 
 *********************************************************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using HQY.Common.Test.TestClasses;
using Xunit;

namespace HQY.Common.Test.Extensions
{
    /// <summary>
    /// <see cref="TypeExtensions"/> 单元测试。
    /// </summary>
    public class TypeExtensionsTest
    {
        /// <summary>
        /// <see cref="TypeExtensions.IsDerivedFrom(Type, Type)"/> 方法单元测试。
        /// </summary>
        [Theory(DisplayName = "TypeExtensions.IsDerivedFrom")]
        [InlineData(null, typeof(IBase), typeof(ArgumentNullException), "type", false)]
        [InlineData(typeof(ImplIBase), null, typeof(ArgumentNullException), "baseType", false)]
        [InlineData(typeof(ImplIBase), typeof(IBase), null, null, true)]
        [InlineData(typeof(ImplIBaseGeneric), typeof(IBase<>), null, null, true)]
        [InlineData(typeof(DerivedCBase), typeof(CBase), null, null, true)]
        [InlineData(typeof(DerivedCBaseGeneric), typeof(CBase<>), null, null, true)]
        [InlineData(typeof(ImplIBase), typeof(ICollection), null, null, false)]
        [InlineData(typeof(DerivedCBase), typeof(Array), null, null, false)]
        [InlineData(typeof(ImplIBaseGeneric), typeof(IList<>), null, null, false)]
        [InlineData(typeof(DerivedCBaseGeneric), typeof(List<>), null, null, false)]
        public void IsDerivedFromTest(Type type, Type baseType, Type exType, string paramName, bool result)
        {
            if (exType != null)
            {
                ArgumentException ex =
                    (ArgumentException) Assert.Throws(exType, () => TypeExtensions.IsDerivedFrom(type, baseType));
                Assert.Equal(paramName, ex.ParamName);
            }
            else
            {
                bool actualResult = type.IsDerivedFrom(baseType);
                Assert.Equal(result, actualResult);
            }
        }

        /// <summary>
        /// <see cref="TypeExtensions.IsImplFrom(Type, Type)"/> 方法单元测试。
        /// </summary>
        [Theory(DisplayName = "TypeExtensions.IsImplFrom")]
        [InlineData(null, typeof(IBase), typeof(ArgumentNullException), "type", false)]
        [InlineData(typeof(ImplIBase), null, typeof(ArgumentNullException), "ifType", false)]
        [InlineData(typeof(ImplIBase), typeof(ImplIBaseGeneric), null, null, false)]
        [InlineData(typeof(ImplIBase), typeof(IBase), null, null, true)]
        [InlineData(typeof(ImplIBaseGeneric), typeof(IBase<>), null, null, true)]
        [InlineData(typeof(ImplIBase), typeof(ICollection), null, null, false)]
        [InlineData(typeof(ImplIBaseGeneric), typeof(IList<>), null, null, false)]
        public void IsImplFromTest(Type type, Type baseType, Type exType, string paramName, bool result)
        {
            if (exType != null)
            {
                ArgumentException ex =
                    (ArgumentException)Assert.Throws(exType, () => TypeExtensions.IsImplFrom(type, baseType));
                Assert.Equal(paramName, ex.ParamName);
            }
            else
            {
                bool actualResult = type.IsImplFrom(baseType);
                Assert.Equal(result, actualResult);
            }
        }
    }
}

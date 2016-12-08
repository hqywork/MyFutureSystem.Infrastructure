/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using HQY.Common;
using HQY.Future.Infrastructure.Domain.EntityModel.Internal;

namespace HQY.Future.Infrastructure.Domain.EntityModel
{
    /// <summary>
    /// 包含了实体模型类型扩展方法的静态类。
    /// </summary>
    public static class EntityModelTypeExtensions
    {
        /// <summary>
        /// <para>从“One-to-Many”关系的“One”实体模型中查找表示“Many”的实体模型的类型。</para>
        /// <para>代表“One”的实体模型类型必须实现 <see cref="IChildEntityModel"/> 接口。</para>
        /// </summary>
        /// <param name="oneType">代表“One”的实体模型类型。</param>
        /// <returns>返回代表“Many”实体模型的类型（已找到）或空引用（<c>null</c>，未找到）</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="oneType"/> 为空引用（<c>null</c>）时引发。</exception>
        /// <exception cref="InvalidOperationException">当 <paramref name="oneType"/> 未实现 <see cref="IChildEntityModel"/> 接口时引发。</exception>
        /// <exception cref="InvalidOperationException">当 <paramref name="oneType"/> 代表的类型未实现 <see cref="IChildEntityModel"/> 接口时引发。</exception>
        public static Type FindManyTypeFromOne(this Type oneType)
        {
            #region Paramter Check

            ParamCheck.NotNull(oneType, nameof(oneType));

            #endregion

            // 如果 oneType 未实现 IChildEntityModel 接口，则
            if (!oneType.IsImplFrom<IChildEntityModel>())
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture,
                                                                  Properties.Resource.TypeImplInterfaceRequire,
                                                                  typeof(IChildEntityModel).FullName));

            // 获取给定类型已实现的满足条件的接口类型（泛型&是 IChildEntityModel 的继承）
            var oneTypeInfo = oneType.GetTypeInfo();
            var childIfType = oneTypeInfo.GetInterfaces()
                                         .FirstOrDefault(ifType =>
                                                             ifType.GetTypeInfo().IsGenericType &&
                                                             ifType.IsDerivedFrom<IChildEntityModel>());

            return childIfType?.GenericTypeArguments[0];
        }
    }
}

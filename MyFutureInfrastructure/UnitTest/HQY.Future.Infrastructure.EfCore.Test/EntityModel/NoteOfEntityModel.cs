/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建
 * 
 *********************************************************************************************************************/

using HQY.Future.Infrastructure.Domain.EntityModel;

namespace HQY.Future.Infrastructure.EfCore.Test.EntityModel
{
    /// <summary>
    /// <see cref="INoteOfEntityModel"/> 接口默认实现。
    /// </summary>
    public class NoteOfEntityModel : EntityModelOfGuid, INoteOfEntityModel
    {
        #region Implementation of INoteOfEntityModel

        /// <summary>
        /// 常规备注。
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 第二备注。
        /// </summary>
        public string SecondNote { get; set; }

        /// <summary>
        /// 第三备注。
        /// </summary>
        public string ThirdNote { get; set; }

        #endregion
    }
}

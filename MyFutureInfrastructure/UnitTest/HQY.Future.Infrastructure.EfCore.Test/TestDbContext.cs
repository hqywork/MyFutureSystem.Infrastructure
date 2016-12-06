/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月03日	新建	
 * 
 *********************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HQY.Future.Infrastructure.EfCore.Test
{
    /// <summary>
    /// 用于测试的 <see cref="DbContext"/> 派生类。
    /// </summary>
    internal class TestDbContext : DbContext
    {
        #region Member of DbContext

        /// <summary>
        /// 配置被当前上下文使用的数据库（及其它选项）。
        /// </summary>
        /// <param name="optionsBuilder">用来创建或修改当前上下文选项的构建器。</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
        }

        #endregion
    }
}

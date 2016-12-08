/**********************************************************************************************************************
 * 变更历史：
 *      作者：张奇  时间：2016年12月08日	新建	
 * 
 *********************************************************************************************************************/

using System;
using System.Diagnostics;
using HQY.Common;
using HQY.Future.Infrastructure.EfCore.Test.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace HQY.Future.Infrastructure.EfCore.Test.Strategies.Mapping
{
    /// <summary>
    /// 应用于映射增加策略测试的 <see cref="DbContext"/> 派生类。
    /// </summary>
    internal sealed class DbContextByMappingStrategy : DbContext
    {
        #region Fields

        private readonly Action<ModelBuilder> _action;

        #endregion

        #region DbSet

        public DbSet<CnvOfEntityModel> Cnvs { get; set; }
        public DbSet<EntityModel.EntityModel> EntityModels { get; set; }
        public DbSet<OneOfGuidEntityModel> OneOfGuids { get; set; }
        public DbSet<OneOfInt32EntityModel> OneOfInt32s { get; set; }
        public DbSet<OneOfInt64EntityModel> OneOfInt64s { get; set; }
        public DbSet<ManyOfGuidEntityModel> ManyOfGuids { get; set; }
        public DbSet<ManyOfInt32EntityModel> ManyOfInt32s { get; set; }
        public DbSet<ManyOfInt64EntityModel> ManyOfInt64s { get; set; }
        public DbSet<NoteOfEntityModel> Notes { get; set; }
        public DbSet<SortOfEntityModel> Sorts { get; set; }
        public DbSet<StateOfEntityModel> States { get; set; }
        public DbSet<TimeOfEntityModel> Times { get; set; }
        public DbSet<VersionOfEntityModel> Versions { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 使用指定的模型生成操作来初始化 <see cref="DbContextByMappingStrategy"/> 的新实例。
        /// </summary>
        /// <param name="action">用于配置模型的生成操作。</param>
        public DbContextByMappingStrategy(Action<ModelBuilder> action)
        {
            #region Parameter's Check

            ParamCheck.NotNull(action, nameof(action));

            #endregion

            this._action = action;
        }

        #endregion

        #region Member of DbContext

        /// <summary>
        /// 配置被当前上下文使用的数据库（及其它选项）。
        /// </summary>
        /// <param name="optionsBuilder">用来创建或修改当前上下文选项的构建器。</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
        }

        /// <summary>
        /// 深层次的配置模型。
        /// </summary>
        /// <param name="modelBuilder">当前上下文构建模型的生成器。</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Debug.WriteLine($"{nameof(this.OnModelCreating)} 被执行...");
            this._action.Invoke(modelBuilder);
        }

        #endregion
    }
}

namespace MVC_homework1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SkillTreeHomeworkContext : DbContext
    {
        public SkillTreeHomeworkContext()
            : base("name=SkillTreeHomeworkContext")
        {
        }

        public virtual DbSet<AccountBook> AccountBook { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

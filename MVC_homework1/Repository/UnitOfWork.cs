using MVC_homework1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_homework1.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; set; }

        public UnitOfWork()
        {
            Context = new SkillTreeHomeworkContext();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
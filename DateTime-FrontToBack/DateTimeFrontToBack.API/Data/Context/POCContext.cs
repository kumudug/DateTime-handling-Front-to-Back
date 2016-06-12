using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DateTimeFrontToBack.API.Data.Entities;
using DateTimeFrontToBack.API.Data.Mappings;

namespace DateTimeFrontToBack.API.Data.Context
{
    public class PocContext : DbContext
    {
        public PocContext() : base("PocContext")
        {
        }

        public virtual DbSet<DataPoc> DataPocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DataPocMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
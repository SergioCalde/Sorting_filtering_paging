using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Sorting_Filtering_Paging.Models;

namespace Sorting_Filtering_Paging.Context
{
    public class EstudianteContext: DbContext
    {
        public EstudianteContext() : base("DefaultConnection")
        {
        }

        public DbSet<Estudiante> Estudiante { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
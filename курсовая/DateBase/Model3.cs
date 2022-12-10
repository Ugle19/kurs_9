using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace курсовая.DateBase
{
    public partial class Model3 : DbContext
    {
        public Model3()
            : base("name=Model311")
        {
        }

        public virtual DbSet<bron> bron { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bron>()
                .Property(e => e.hotel)
                .IsUnicode(false);

            modelBuilder.Entity<bron>()
                .Property(e => e.Room)
                .IsUnicode(false);

            modelBuilder.Entity<bron>()
                .Property(e => e.Bron1)
                .IsUnicode(false);
        }
    }
}

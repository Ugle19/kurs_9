namespace курсовая.DateBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<otel> otel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<otel>()
                .Property(e => e.N)
                .IsUnicode(false);

            modelBuilder.Entity<otel>()
                .Property(e => e.Gorod)
                .IsUnicode(false);

            modelBuilder.Entity<otel>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<otel>()
                .Property(e => e.Nomer_tel)
                .IsUnicode(false);
        }
    }
}

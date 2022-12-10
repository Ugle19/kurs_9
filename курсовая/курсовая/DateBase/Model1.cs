namespace курсовая.DateBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Clientt> Clientt { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientt>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<Clientt>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Clientt>()
                .Property(e => e.second_surname)
                .IsUnicode(false);

            modelBuilder.Entity<Clientt>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Clientt>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<Clientt>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}

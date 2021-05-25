namespace proga
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BD : DbContext
    {
        public BD()
            : base("name=BD")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Dostavchik> Dostavchik { get; set; }
        public virtual DbSet<Dostavka> Dostavka { get; set; }
        public virtual DbSet<Izdelie> Izdelie { get; set; }
        public virtual DbSet<Izgotovlenie> Izgotovlenie { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<ProbPalata> ProbPalata { get; set; }
        public virtual DbSet<Prodaga> Prodaga { get; set; }
        public virtual DbSet<Sdacha> Sdacha { get; set; }
        public virtual DbSet<Sotrudnik> Sotrudnik { get; set; }
        public virtual DbSet<Vydacha> Vydacha { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Prodaga)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Zakaz)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dostavchik>()
                .HasMany(e => e.Dostavka)
                .WithRequired(e => e.Dostavchik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Izdelie>()
                .HasMany(e => e.Izgotovlenie)
                .WithRequired(e => e.Izdelie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Izdelie>()
                .HasMany(e => e.Prodaga)
                .WithRequired(e => e.Izdelie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Izdelie>()
                .HasMany(e => e.Zakaz)
                .WithRequired(e => e.Izdelie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Izgotovlenie>()
                .HasMany(e => e.Sdacha)
                .WithRequired(e => e.Izgotovlenie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Izgotovlenie>()
                .HasMany(e => e.Vydacha)
                .WithRequired(e => e.Izgotovlenie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Sdacha)
                .WithRequired(e => e.Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Vydacha)
                .WithRequired(e => e.Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProbPalata>()
                .HasMany(e => e.Izdelie)
                .WithRequired(e => e.ProbPalata)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prodaga>()
                .HasMany(e => e.Dostavka)
                .WithRequired(e => e.Prodaga)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sotrudnik>()
                .HasMany(e => e.Izgotovlenie)
                .WithRequired(e => e.Sotrudnik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zakaz>()
                .HasMany(e => e.Prodaga)
                .WithRequired(e => e.Zakaz)
                .WillCascadeOnDelete(false);
        }
    }
}

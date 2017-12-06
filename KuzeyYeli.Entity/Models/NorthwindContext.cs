namespace KuzeyYeli.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base("name=NorthwindContext")
        {
        }

        public virtual DbSet<aspnet_Applications> aspnet_Applications { get; set; }
        public virtual DbSet<aspnet_Membership> aspnet_Membership { get; set; }
        public virtual DbSet<aspnet_Paths> aspnet_Paths { get; set; }
        public virtual DbSet<aspnet_PersonalizationAllUsers> aspnet_PersonalizationAllUsers { get; set; }
        public virtual DbSet<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
        public virtual DbSet<aspnet_Profile> aspnet_Profile { get; set; }
        public virtual DbSet<aspnet_Roles> aspnet_Roles { get; set; }
        public virtual DbSet<aspnet_SchemaVersions> aspnet_SchemaVersions { get; set; }
        public virtual DbSet<AspNet_SqlCacheTablesForChangeNotification> AspNet_SqlCacheTablesForChangeNotification { get; set; }
        public virtual DbSet<aspnet_Users> aspnet_Users { get; set; }
        public virtual DbSet<aspnet_WebEvent_Events> aspnet_WebEvent_Events { get; set; }
        public virtual DbSet<Bolge> Bolge { get; set; }
        public virtual DbSet<Bolgeler> Bolgeler { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<Maas> Maas { get; set; }
        public virtual DbSet<MusteriDemographics> MusteriDemographics { get; set; }
        public virtual DbSet<Musteriler> Musteriler { get; set; }
        public virtual DbSet<Nakliyeciler> Nakliyeciler { get; set; }
        public virtual DbSet<Personeller> Personeller { get; set; }
        public virtual DbSet<PersonellerYeni> PersonellerYeni { get; set; }
        public virtual DbSet<Satis_Detaylari> Satis_Detaylari { get; set; }
        public virtual DbSet<Satislar> Satislar { get; set; }
        public virtual DbSet<Tedarikciler> Tedarikciler { get; set; }
        public virtual DbSet<Urunler> Urunler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Membership)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Paths)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Roles)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Users)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Paths>()
                .HasOptional(e => e.aspnet_PersonalizationAllUsers)
                .WithRequired(e => e.aspnet_Paths);

            modelBuilder.Entity<aspnet_Roles>()
                .HasMany(e => e.aspnet_Users)
                .WithMany(e => e.aspnet_Roles)
                .Map(m => m.ToTable("aspnet_UsersInRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<aspnet_Users>()
                .HasOptional(e => e.aspnet_Membership)
                .WithRequired(e => e.aspnet_Users);

            modelBuilder.Entity<aspnet_Users>()
                .HasOptional(e => e.aspnet_Profile)
                .WithRequired(e => e.aspnet_Users);

            modelBuilder.Entity<aspnet_WebEvent_Events>()
                .Property(e => e.EventId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<aspnet_WebEvent_Events>()
                .Property(e => e.EventSequence)
                .HasPrecision(19, 0);

            modelBuilder.Entity<aspnet_WebEvent_Events>()
                .Property(e => e.EventOccurrence)
                .HasPrecision(19, 0);

            modelBuilder.Entity<Bolge>()
                .Property(e => e.BolgeTanimi)
                .IsFixedLength();

            modelBuilder.Entity<Bolge>()
                .HasMany(e => e.Bolgeler)
                .WithRequired(e => e.Bolge)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bolgeler>()
                .Property(e => e.TerritoryTanimi)
                .IsFixedLength();

            modelBuilder.Entity<Bolgeler>()
                .HasMany(e => e.Personeller)
                .WithMany(e => e.Bolgeler)
                .Map(m => m.ToTable("PersonelBolgeler").MapLeftKey("TerritoryID").MapRightKey("PersonelID"));

            modelBuilder.Entity<Maas>()
                .Property(e => e.Adi)
                .IsUnicode(false);

            modelBuilder.Entity<Maas>()
                .Property(e => e.Soyadi)
                .IsUnicode(false);

            modelBuilder.Entity<Maas>()
                .Property(e => e.TCKimlikNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MusteriDemographics>()
                .Property(e => e.MusteriTypeID)
                .IsFixedLength();

            modelBuilder.Entity<MusteriDemographics>()
                .HasMany(e => e.Musteriler)
                .WithMany(e => e.MusteriDemographics)
                .Map(m => m.ToTable("MusteriMusteriDemo").MapLeftKey("MusteriTypeID").MapRightKey("MusteriID"));

            modelBuilder.Entity<Musteriler>()
                .Property(e => e.MusteriID)
                .IsFixedLength();

            modelBuilder.Entity<Nakliyeciler>()
                .HasMany(e => e.Satislar)
                .WithOptional(e => e.Nakliyeciler)
                .HasForeignKey(e => e.ShipVia);

            modelBuilder.Entity<Satis_Detaylari>()
                .Property(e => e.BirimFiyati)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Satislar>()
                .Property(e => e.MusteriID)
                .IsFixedLength();

            modelBuilder.Entity<Satislar>()
                .Property(e => e.NakliyeUcreti)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Satislar>()
                .HasMany(e => e.Satis_Detaylari)
                .WithRequired(e => e.Satislar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Urunler>()
                .Property(e => e.BirimFiyati)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urunler>()
                .HasMany(e => e.Satis_Detaylari)
                .WithRequired(e => e.Urunler)
                .WillCascadeOnDelete(false);
        }
    }
}

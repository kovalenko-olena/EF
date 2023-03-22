using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using AvtoParkCreateDB.Models;

namespace AvtoParkCreateDB.EF
{
    public partial class AvtoParkEntities : DbContext
    {
        public AvtoParkEntities()
            : base("name=AvtoParkCreateDB")
        {
        }

        public virtual DbSet<BrandSpr> BrandSprs { get; set; }
        public virtual DbSet<DriverSpr> DriverSprs { get; set; }
        public virtual DbSet<FuelSpr> FuelSprs { get; set; }
        public virtual DbSet<ModelSpr> ModelSprs { get; set; }
        public virtual DbSet<VehicleSpr> VehicleSprs { get; set; }
        public virtual DbSet<WayBill> WayBills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandSpr>()
                .Property(e => e.CdNm)
                .IsUnicode(false);

            modelBuilder.Entity<BrandSpr>()
                .HasMany(e => e.ModelSprs)
                .WithOptional(e => e.BrandSpr)
                .HasForeignKey(e => e.IdBrand);

            modelBuilder.Entity<DriverSpr>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<DriverSpr>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<DriverSpr>()
                .HasMany(e => e.VehicleSprs)
                .WithOptional(e => e.DriverSpr)
                .HasForeignKey(e => e.IdDriver);

            modelBuilder.Entity<DriverSpr>()
                .HasMany(e => e.WayBills)
                .WithOptional(e => e.DriverSpr)
                .HasForeignKey(e => e.IdDriver);

            modelBuilder.Entity<FuelSpr>()
                .Property(e => e.CdNm)
                .IsUnicode(false);

            modelBuilder.Entity<FuelSpr>()
                .HasMany(e => e.ModelSprs)
                .WithOptional(e => e.FuelSpr)
                .HasForeignKey(e => e.IdFuel);

            modelBuilder.Entity<FuelSpr>()
                .HasMany(e => e.WayBills)
                .WithOptional(e => e.FuelSpr)
                .HasForeignKey(e => e.IdFuel);

            modelBuilder.Entity<ModelSpr>()
                .Property(e => e.CdNm)
                .IsUnicode(false);

            modelBuilder.Entity<ModelSpr>()
                .HasMany(e => e.VehicleSprs)
                .WithOptional(e => e.ModelSpr)
                .HasForeignKey(e => e.IdModel);

            modelBuilder.Entity<VehicleSpr>()
                .Property(e => e.RegNumber)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleSpr>()
                .Property(e => e.Norm)
                .HasPrecision(8, 2);

            modelBuilder.Entity<VehicleSpr>()
                .HasMany(e => e.WayBills)
                .WithOptional(e => e.VehicleSpr)
                .HasForeignKey(e => e.IdVehicle);

            modelBuilder.Entity<WayBill>()
                .Property(e => e.FuelBalOut)
                .HasPrecision(5, 2);

            modelBuilder.Entity<WayBill>()
                .Property(e => e.FuelBalIn)
                .HasPrecision(5, 2);

            modelBuilder.Entity<WayBill>()
                .Property(e => e.FuelConsumNorm)
                .HasPrecision(5, 0);

            modelBuilder.Entity<WayBill>()
                .Property(e => e.FuelConsumFact)
                .HasPrecision(5, 0);
        }
    }
}

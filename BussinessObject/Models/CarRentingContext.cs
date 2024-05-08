using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BussinessObject.Models;

public partial class CarRentingContext : DbContext
{
    public CarRentingContext()
    {
    }

    public CarRentingContext(DbContextOptions<CarRentingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarType> CarTypes { get; set; }

    public virtual DbSet<CrcOffice> CrcOffices { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<OfficeTel> OfficeTels { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =120.72.85.82,9033; database = CarRenting;uid=sa;pwd=f0^wyhMfl*25;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__car__1436F094D33F81E8");

            entity.ToTable("car");

            entity.Property(e => e.CarId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("carID");
            entity.Property(e => e.Brand)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.Color)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.CurrentLocationId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("currentLocationID");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Model)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.PurchDate).HasColumnName("purchDate");
            entity.Property(e => e.TypeId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("typeID");

            entity.HasOne(d => d.CurrentLocation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CurrentLocationId)
                .HasConstraintName("FK_car_crc_office");

            entity.HasOne(d => d.Type).WithMany(p => p.Cars)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_car_car_type");
        });

        modelBuilder.Entity<CarType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__car_type__F04DF11A428D1851");

            entity.ToTable("car_type");

            entity.Property(e => e.TypeId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("typeID");
            entity.Property(e => e.TypeDescr)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("typeDescr");
            entity.Property(e => e.TypeLabel)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("typeLabel");
        });

        modelBuilder.Entity<CrcOffice>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__crc_offi__30646B0EC7921E42");

            entity.ToTable("crc_office");

            entity.Property(e => e.LocationId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("locationID");
            entity.Property(e => e.City)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.DefaultTel).HasColumnName("defaultTel");
            entity.Property(e => e.Number)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.State)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("street");

            entity.HasOne(d => d.DefaultTelNavigation).WithMany(p => p.CrcOffices)
                .HasForeignKey(d => d.DefaultTel)
                .HasConstraintName("FK_crc_office_office_tel");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__B611CB9DDFB516C9");

            entity.ToTable("customers");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Country)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Mobile)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.Ssn).HasColumnName("ssn");
            entity.Property(e => e.State)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("state");
        });

        modelBuilder.Entity<OfficeTel>(entity =>
        {
            entity.HasKey(e => e.DefaultTel).HasName("PK__office_t__0BEEC80D736E92B2");

            entity.ToTable("office_tel");

            entity.Property(e => e.DefaultTel).HasColumnName("defaultTel");
            entity.Property(e => e.Tel1).HasColumnName("tel1");
            entity.Property(e => e.Tel2).HasColumnName("tel2");
            entity.Property(e => e.Tel3).HasColumnName("tel3");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__reservat__B14BF5A571BA2591");

            entity.ToTable("reservation");

            entity.Property(e => e.ReservationId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("reservationID");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.CarId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("carID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.PickupDate).HasColumnName("pickupDate");
            entity.Property(e => e.PickupLocationId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("pickupLocationID");
            entity.Property(e => e.ReturnDate).HasColumnName("returnDate");
            entity.Property(e => e.ReturnLocationId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("returnLocationID");

            entity.HasOne(d => d.Car).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK_reservation_car");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_reservation_customers");

            entity.HasOne(d => d.PickupLocation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.PickupLocationId)
                .HasConstraintName("FK_reservation_crc_office");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

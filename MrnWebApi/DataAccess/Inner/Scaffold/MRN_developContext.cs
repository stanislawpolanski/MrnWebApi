using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MrnWebApi.DataAccess.Inner.Scaffold.Entities
{
    public partial class MRN_developContext : DbContext
    {
        public MRN_developContext()
        {
        }

        public MRN_developContext(DbContextOptions<MRN_developContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Geometries> Geometries { get; set; }
        public virtual DbSet<ObjectsOfInterest> ObjectsOfInterest { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<PhotosToObjectsOfInterest> PhotosToObjectsOfInterest { get; set; }
        public virtual DbSet<RailwayUnits> RailwayUnits { get; set; }
        public virtual DbSet<Railways> Railways { get; set; }
        public virtual DbSet<Stations> Stations { get; set; }
        public virtual DbSet<StationsToGeometries> StationsToGeometries { get; set; }
        public virtual DbSet<TypesOfAstation> TypesOfAstation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MRN_develop;Trusted_Connection=True;", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Geometries>(entity =>
            {
                entity.Property(e => e.SpatialData)
                    .IsRequired()
                    .HasColumnType("geometry");
            });

            modelBuilder.Entity<ObjectsOfInterest>(entity =>
            {
                entity.HasIndex(e => new { e.OwnerId, e.Name })
                    .HasName("AK_ObjectsOfInterest_OwnerId_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.ObjectsOfInterest)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ObjectsOfInterest_ToOwners");
            });

            modelBuilder.Entity<Owners>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("AK_Owners_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.HasIndex(e => e.FilePath)
                    .HasName("AK_Photos_FilePath")
                    .IsUnique();

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhotoDescription).HasMaxLength(500);
            });

            modelBuilder.Entity<PhotosToObjectsOfInterest>(entity =>
            {
                entity.HasIndex(e => new { e.PhotoId, e.ObjectOfInterestId })
                    .HasName("AK_PhotosToObjectsOfInterest_ObjectOfInterestIdPhotoId")
                    .IsUnique();

                entity.HasOne(d => d.ObjectOfInterest)
                    .WithMany(p => p.PhotosToObjectsOfInterest)
                    .HasForeignKey(d => d.ObjectOfInterestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhotosToObjectsOfInterest_ToObjectsOfInterest");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.PhotosToObjectsOfInterest)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhotosToObjectsOfInterest_ToTablePhotos");
            });

            modelBuilder.Entity<RailwayUnits>(entity =>
            {
                entity.HasIndex(e => e.GeometriesId)
                    .HasName("UQ__RailwayU__F79989B9973713DC")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("AK_RailwayUnits_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Geometries)
                    .WithOne(p => p.RailwayUnits)
                    .HasForeignKey<RailwayUnits>(d => d.GeometriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RailwayUnits_ToGeometries");
            });

            modelBuilder.Entity<Railways>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("AK_Railways_Name")
                    .IsUnique();

                entity.HasIndex(e => e.OwnerId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Geometry)
                    .WithMany(p => p.Railways)
                    .HasForeignKey(d => d.GeometryId)
                    .HasConstraintName("FK_Railways_ToGeometries");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Railways)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Railways_ToOwners");
            });

            modelBuilder.Entity<Stations>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TypeOfAstationId).HasColumnName("TypeOfAStationId");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Stations)
                    .HasForeignKey<Stations>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stations_ToObjectsOfInterest");

                entity.HasOne(d => d.TypeOfAstation)
                    .WithMany(p => p.Stations)
                    .HasForeignKey(d => d.TypeOfAstationId)
                    .HasConstraintName("FK_Stations_ToTypes");
            });

            modelBuilder.Entity<StationsToGeometries>(entity =>
            {
                entity.HasIndex(e => e.RailwayId);

                entity.HasIndex(e => e.StationId);

                entity.Property(e => e.BeginningKmpost).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.CentreKmpost).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.EndingKmpost).HasColumnType("decimal(6, 3)");

                entity.HasOne(d => d.Geometry)
                    .WithMany(p => p.StationsToGeometries)
                    .HasForeignKey(d => d.GeometryId)
                    .HasConstraintName("FK_StationsToGeometries_ToGeometries");

                entity.HasOne(d => d.Railway)
                    .WithMany(p => p.StationsToGeometries)
                    .HasForeignKey(d => d.RailwayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StationsToGeometries_ToRailways");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.StationsToGeometries)
                    .HasForeignKey(d => d.StationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StationsToGeometries_ToStations");
            });

            modelBuilder.Entity<TypesOfAstation>(entity =>
            {
                entity.ToTable("TypesOfAStation");

                entity.HasIndex(e => e.AbbreviatedName)
                    .HasName("AK_TypesOfAStation_Name")
                    .IsUnique();

                entity.Property(e => e.AbbreviatedName)
                    .IsRequired()
                    .HasMaxLength(5);
            });
        }
    }
}

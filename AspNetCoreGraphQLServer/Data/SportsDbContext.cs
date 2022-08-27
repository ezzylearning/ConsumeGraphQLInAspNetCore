using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AspNetCoreGraphQLServer.Models;

namespace AspNetCoreGraphQLServer.Data
{
    public partial class SportsDbContext : DbContext
    {
        public SportsDbContext()
        {
        }

        public SportsDbContext(DbContextOptions<SportsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasOne(d => d.Team1Navigation)
                    .WithMany(p => p.MatchTeam1Navigations)
                    .HasForeignKey(d => d.Team1)
                    .HasConstraintName("FK_Matches_Team1_Teams_Id");

                entity.HasOne(d => d.Team2Navigation)
                    .WithMany(p => p.MatchTeam2Navigations)
                    .HasForeignKey(d => d.Team2)
                    .HasConstraintName("FK_Matches_Team2_Teams_Id");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Players_Positions");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Logo).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

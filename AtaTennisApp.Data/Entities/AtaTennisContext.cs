using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AtaTennisApp.Data.Entities
{
    public partial class AtaTennisContext : DbContext
    {
        public AtaTennisContext()
        {
        }

        public AtaTennisContext(DbContextOptions<AtaTennisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=PCPQ\\SQLEXPRESS;Database=AtaTennis;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasIndex(e => e.AwayPlayerId)
                    .HasName("FK_Match_PlayerAway");

                entity.HasIndex(e => e.HomePlayerId)
                    .HasName("FK_Match_PlayerHome");

                entity.HasIndex(e => e.TournamentId)
                    .HasName("FK_Tournament_Player");

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.AwayPlayer)
                    .WithMany(p => p.MatchAwayPlayer)
                    .HasForeignKey(d => d.AwayPlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_PlayerAway");

                entity.HasOne(d => d.HomePlayer)
                    .WithMany(p => p.MatchHomePlayer)
                    .HasForeignKey(d => d.HomePlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_PlayerHome");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tournament_Player");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}

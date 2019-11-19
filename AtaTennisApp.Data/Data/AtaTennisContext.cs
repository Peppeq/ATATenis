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

        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<MatchEntry> MatchEntries { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<TournamentEntry> TournamentEntries { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
            modelBuilder.HasAnnotation("ProductVersion", "3.0.1");

            //This will singularize all table names
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            modelBuilder.Entity<Match>(entity =>
            {
                //entity.HasIndex(e => e.Id)
                //    .HasName("PK_Match");
                entity.Property(e => e.Id).UseIdentityColumn();
                //entity.HasIndex(e => e.Id).IsClustered();

                entity.HasMany(e => e.MatchEntries)
                    .WithOne(me => me.Match);
            });

            modelBuilder.Entity<MatchEntry>(entity =>
            {
                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchEntries)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchEntry_Match");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.FavouritePlayer).HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Racquet).HasMaxLength(30);

                entity.Property(e => e.Residence).HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.BirthDate).HasColumnType("Date");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasOne(e => e.MatchEntry)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.MatchEntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Score_MatchEntry");
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

            modelBuilder.Entity<TournamentEntry>(entity =>
            {
                //entity.HasKey(e => new { e.Id })
                //    .HasName("PK_TournamentEntry");

                entity.Property(e => e.Id).UseIdentityColumn();
                //entity.HasIndex(e => e.Id).IsClustered();

                entity.HasOne(e => e.Player)
                    .WithMany(p => p.TournamentEntries)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TournamentEntry_Player");

                entity.HasOne(e => e.Tournament)
                    .WithMany(t => t.TournamentEntries)
                    .HasForeignKey(e => e.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TournamentEntry_Tournament");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(75);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(75);
            });
        }
    }
}

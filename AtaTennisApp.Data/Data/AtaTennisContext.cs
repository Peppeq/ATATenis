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

        public virtual DbSet<Draw> Draw { get; set; }
        public virtual DbSet<DrawMatch> DrawMatch { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<MatchPlayer> MatchPlayer { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<User> User { get; set; }

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

            modelBuilder.Entity<Draw>(entity =>
            {
                entity.HasIndex(e => e.TournamentId)
                    .HasName("FK_Draw_Tournament")
                    .IsUnique();

                entity.HasOne(d => d.Tournament)
                    .WithOne(p => p.Draw)
                    .HasForeignKey<Draw>(d => d.TournamentId)
                    .HasConstraintName("FK_Draw_Tournament");
            });

            modelBuilder.Entity<DrawMatch>(entity =>
            {
                entity.HasKey(e => new { e.DrawId, e.MatchId })
                    .HasName("PK__DrawMatc__0696BFAF7276884F");

                entity.HasIndex(e => e.MatchId);

                entity.HasOne(d => d.Draw)
                    .WithMany(p => p.DrawMatch)
                    .HasForeignKey(d => d.DrawId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DrawMatch_Draw");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.DrawMatch)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DrawMatch_Match");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasIndex(e => e.TournamentId)
                    .HasName("fkIdx_Match_Tournament");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.TournamentId)
                    .HasConstraintName("FK_Match_Tournament");
            });

            modelBuilder.Entity<MatchPlayer>(entity =>
            {
                entity.HasIndex(e => e.MatchId)
                    .HasName("fkIdx_MatchPlayer_Match");

                entity.HasIndex(e => e.PlayerId)
                    .HasName("fkIdx_MatchPlayer_Player");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchPlayer)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchPlayer_Match");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.MatchPlayer)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchPlayer_Player");
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

#nullable disable

namespace PrivateNotes
{
    using Microsoft.EntityFrameworkCore;
    using PrivateNotes.Models;

    /// <summary>
    /// db-context.
    /// </summary>
    public partial class PrivateNotesContext : DbContext
    {
        public PrivateNotesContext()
        {
        }

        public PrivateNotesContext(DbContextOptions<PrivateNotesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Note> Notes { get; set; }

        public virtual DbSet<Note1> Notes1 { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=private_notes;Username=postgres;Password=Ye8g6K_r?");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("accounts_pkey");

                entity.ToTable("accounts");

                entity.HasIndex(e => e.Email, "accounts_email_key")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("password");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password_hash");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("notes");

                entity.Property(e => e.NoteId).HasColumnName("note_id");

                entity.Property(e => e.NoteDate)
                    .HasColumnType("date")
                    .HasColumnName("note_date");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("text");
            });

            modelBuilder.Entity<Note1>(entity =>
            {
                entity.ToTable("Note");

                entity.HasIndex(e => e.NoteUserId, "IX_Note_NoteUserId");

                entity.HasOne(d => d.NoteUser)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.NoteUserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

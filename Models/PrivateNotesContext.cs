using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#nullable disable

namespace PrivateNotes.Models
{
    using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<Note> Notes { get; set; }

        public virtual DbSet<User> Users { get; set; }

        // public virtual DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("Note");

                entity.HasIndex(e => e.NoteUserId, "IX_Note_NoteUserId");

                entity.HasOne(d => d.NoteUser)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.NoteUserId);
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("public");
        }
    }
}
using Microsoft.EntityFrameworkCore;
using RazorPagesCore.EF.DataAccessLib.Models;

namespace RazorPagesCore.EF.DataAccessLib.DataAccess
{
    public partial class TodoListDataContext : DbContext
    {
        public TodoListDataContext()
        {
        }

        public TodoListDataContext(DbContextOptions<TodoListDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<TodoItems> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasIndex(e => e.TodoItemId);

                entity.Property(e => e.NoteText)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.TodoItem)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.TodoItemId);
            });

            modelBuilder.Entity<TodoItems>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}



using Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class NotesContext : DbContext
    {

        public NotesContext(DbContextOptions<NotesContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data source=notes.db");
            base.OnConfiguring(options);
        }
        public DbSet<Note> Notes { get; set; }
    }
}

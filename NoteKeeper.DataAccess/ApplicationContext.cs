using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NoteKeeper.DataAccess.Configurations;
using NoteKeeper.DataAccess.Models;

namespace NoteKeeper.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
        }
    }
}
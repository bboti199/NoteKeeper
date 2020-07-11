using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteKeeper.DataAccess.Models;

namespace NoteKeeper.DataAccess.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        private readonly DatabaseFacade _database;

        public NoteConfiguration(DatabaseFacade database)
        {
            _database = database;
        }

        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(n => n.Title)
                .IsRequired();

            builder
                .Property(n => n.Content);

            if (!_database.IsNpgsql())
                builder
                    .Property(n => n.Keywords)
                    .HasConversion(
                        v => string.Join(';', v),
                        v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
                    );

            builder
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId);

            builder
                .Property(n => n.CreatedAt);

            builder.ToTable("notes");
        }
    }
}
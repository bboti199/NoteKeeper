using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteKeeper.DataAccess.Models;

namespace NoteKeeper.DataAccess.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Id)
                .UseIdentityColumn();

            builder
                .Property(n => n.Title)
                .IsRequired();

            builder
                .Property(n => n.Content);

            builder
                .Property(n => n.Keywords)
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            builder
                .HasOne<User>(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId);

            builder
                .Property(n => n.CreatedAt);

            builder.ToTable("Notes");
        }
    }
}
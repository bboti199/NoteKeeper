using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteKeeper.DataAccess.Models;

namespace NoteKeeper.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(u => u.UserName)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .IsRequired();

            builder
                .Property(u => u.PasswordHash)
                .IsRequired();

            builder
                .Property(u => u.AvatarUrl);

            builder
                .HasMany<Note>(u => u.Notes)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("users");
        }
    }
}
using Auth.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Service.Infrastructure.Data.EntityFramework;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired();

        builder.Property(u => u.Password)
            .IsRequired();

        builder.Property(u => u.Role)
            .IsRequired();

        builder.HasData(
            new User
            {
                Id = Guid.Parse("3f4d9473-551d-4e8c-a8ab-7f604862d478"),
                Username = "microservices@code-maze.com",
                Password = "oKNrqkO7iC#G",
                Role = "Administrator"
            });
    }
}

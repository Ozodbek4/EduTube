using EduTube.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduTube.Infrastructure.Persistence.Configurations;

public class UserCredentialsConfigurations : IEntityTypeConfiguration<UserCredentials>
{
    public void Configure(EntityTypeBuilder<UserCredentials> builder)
    {
        builder
            .HasOne(credentials => credentials.User)
            .WithOne(user => user.Credentials)
            .HasForeignKey<UserCredentials>(credentials => credentials.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
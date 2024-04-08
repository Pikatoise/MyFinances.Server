using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Domain.Entity;

namespace MyFinances.DAL.Configurations
{
    public class UserTokenConfiguration: IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.RefreshToken).IsRequired();
            builder.Property(x => x.RefreshTokenExpiryTime).IsRequired();
        }
    }
}

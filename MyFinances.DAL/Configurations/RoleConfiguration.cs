using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Domain.Entity;

namespace MyFinances.DAL.Configurations
{
    public class RoleConfiguration: IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasData(new List<Role>
            {
                new Role()
                {
                    Id = 1,
                    Name = "User"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Admin"
                },
                new Role()
                {
                    Id = 3,
                    Name = "Premium"
                }
            });
        }
    }
}

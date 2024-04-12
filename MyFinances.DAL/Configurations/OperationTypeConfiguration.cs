using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Domain.Entity;

namespace MyFinances.DAL.Configurations
{
    public class OperationTypeConfiguration: IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IconSrc).IsRequired().HasMaxLength(200);

            builder.HasMany<TypeAssociation>(x => x.Associations)
                .WithOne(x => x.Type)
                .HasForeignKey(x => x.TypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

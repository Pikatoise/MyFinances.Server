using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Domain.Entity;

namespace MyFinances.DAL.Configurations
{
    public class TypeAssociationConfiguration: IEntityTypeConfiguration<TypeAssociation>
    {
        public void Configure(EntityTypeBuilder<TypeAssociation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Association).IsRequired().HasMaxLength(50);

            builder.HasOne<OperationType>(x => x.Type)
                .WithMany(x => x.Associations)
                .HasForeignKey(x => x.TypeId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Domain.Entity;

namespace MyFinances.DAL.Configurations
{
    public class OperationConfiguration: IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);

            builder.HasOne<OperationType>(x => x.Type)
                .WithMany(x => x.Operations)
                .HasForeignKey(x => x.TypeId);

            builder.HasOne<Period>(x => x.Period)
                .WithMany(x => x.Operations)
                .HasForeignKey(x => x.PeriodId);
        }
    }
}

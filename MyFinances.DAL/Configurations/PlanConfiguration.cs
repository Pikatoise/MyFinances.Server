using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Domain.Entity;

namespace MyFinances.DAL.Configurations
{
    public class PlanConfiguration: IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Amount).HasDefaultValue(0);
            builder.Property(x => x.FinalDate).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne<User>(x => x.User)
                .WithMany(x => x.Plans)
                .HasForeignKey(x => x.UserId);

            builder.HasOne<OperationType>(x => x.Type)
                .WithMany(x => x.Plans)
                .HasForeignKey(x => x.TypeId);
        }
    }
}

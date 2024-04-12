using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Domain.Entity;

namespace MyFinances.DAL.Configurations
{
    public class PeriodConfiguration: IEntityTypeConfiguration<Period>
    {
        public void Configure(EntityTypeBuilder<Period> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Month).IsRequired();
            builder.Property(x => x.Year).IsRequired();

            builder.HasOne<User>(x => x.User)
                .WithMany(x => x.Periods)
                .HasForeignKey(x => x.UserId);

            builder.HasMany<Operation>(x => x.Operations)
                .WithOne(x => x.Period)
                .HasForeignKey(x => x.PeriodId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Kursverwaltung.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kursverwaltung.Data.Configurations
{
    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasMany(t => t.Courses)
                   .WithOne(c => c.Trainer)
                   .HasForeignKey(c => c.TrainerId);
        }
    }
}
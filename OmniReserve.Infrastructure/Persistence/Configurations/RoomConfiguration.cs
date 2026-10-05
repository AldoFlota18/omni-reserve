using OmniReserve.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace OmniReserve.Infrastructure.Persistence.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.RoomNumber)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(r => r.PricePerNight)
            .HasPrecision(18, 2);

        builder.Property(r => r.Type)
            .HasConversion<string>();
    }
}
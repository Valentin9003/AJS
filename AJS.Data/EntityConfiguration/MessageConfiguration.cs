using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// Message data Model Configuration
    /// </summary>
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(k => new { k.SenderId, k.ReceivedId });
        }
    }
}

using FriendOrganizer.Model;
using System.Data.Entity.ModelConfiguration;

namespace FriendOrganizer.DataAccess.entity_config
{
    class FriendModelConfiguration : EntityTypeConfiguration<Friend>
    {
        public FriendModelConfiguration()
        {
            Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(f => f.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

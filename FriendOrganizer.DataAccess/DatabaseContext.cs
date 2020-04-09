using FriendOrganizer.DataAccess.entity_config;
using FriendOrganizer.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FriendOrganizer.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("friend_org_db")
        {

        }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}

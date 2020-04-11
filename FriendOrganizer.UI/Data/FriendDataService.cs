using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private Func<DatabaseContext> _contextCreator;

        public FriendDataService(Func<DatabaseContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }
        public async Task<Friend> GetFriendByIdAsync(int id)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Friends.AsNoTracking().SingleAsync(f => f.Id == id);
            }
        }

    }
}

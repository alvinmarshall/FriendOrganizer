using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendOrganizer.UI.Data
{
    public class DataService : IDataService
    {
        private Func<DatabaseContext> _contextCreator;

        public DataService(Func<DatabaseContext> contextCreator )
        {
            _contextCreator = contextCreator;
        }
        public IEnumerable<Friend> GetAll()
        {
            using (var ctx = _contextCreator())
            {
                return ctx.Friends.AsNoTracking().ToList();
            }
        }

    }
}

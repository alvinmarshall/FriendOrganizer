using FriendOrganizer.Model;
using System.Collections.Generic;

namespace FriendOrganizer.UI.Data
{
    public class DataService : IDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            yield return new Friend { FirstName = "f1", LastName = "l1", Email = "e1" };
            yield return new Friend { FirstName = "f2", LastName = "l2", Email = "e2" };
            yield return new Friend { FirstName = "f3", LastName = "l3", Email = "e3" };
        }

    }
}

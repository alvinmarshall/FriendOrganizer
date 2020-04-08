using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private IDataService _dataService;
        private Friend _selectedFriend;
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Friends = new ObservableCollection<Friend>();

        }

        public ObservableCollection<Friend> Friends { get; set; }


        public Friend SelectedFriend
        {
            get => _selectedFriend;
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
            }

        }

        public void Load()
        {
            Friends.Clear();
            var friends = _dataService.GetAll();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }

        }




    }
}

using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : BaseViewModel, IFriendDetailViewModel
    {
        private FriendWrapper _friend;
        private IFriendDataService _friendDataService;
        private IEventAggregator _eventAggregator;
        public ICommand SaveFriendCommand { get; }

        public FriendDetailViewModel(IFriendDataService friendDataService, IEventAggregator eventAggregator)
        {
            _friendDataService = friendDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);
            SaveFriendCommand = new DelegateCommand(OnSaveFriendAction, OnCanSaveFriend);

        }

        private bool OnCanSaveFriend()
        {
            return Friend != null && !Friend.HasErrors;
        }

        private async void OnSaveFriendAction()
        {
            await _friendDataService.SaveFriendAsync(Friend.Model);
            _eventAggregator
                .GetEvent<AfterSaveFriendEvent>()
                .Publish(new AfterSaveFriendEventArgs { Id = Friend.Id, DisplayMember = $"{Friend.FirstName} {Friend.LastName}" });
        }

        private async void OnOpenFriendDetailView(int friendId)
        {
            await LoadFriendById(friendId);
            
        }

        public async Task LoadFriendById(int friendId)
        {
            var friend = await _friendDataService.GetFriendByIdAsync(friendId);
            Friend = new FriendWrapper(friend);
            ((DelegateCommand)SaveFriendCommand).RaiseCanExecuteChanged();
            Friend.PropertyChanged += (e, s) =>
            {
                ((DelegateCommand)SaveFriendCommand).RaiseCanExecuteChanged();
            };
        }



        public FriendWrapper Friend
        {
            get => _friend;
            set { _friend = value; OnPropertyChanged(); }
        }






    }
}

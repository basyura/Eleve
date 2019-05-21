using System.Collections.ObjectModel;
using System.Windows.Data;
using Eleve;
using Tweetinvi.Models;

namespace TweetWPF.ViewModels
{
    public class TweetWPFViewModel : ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public TweetWPFViewModel()
        {
            BindingOperations.EnableCollectionSynchronization(_Tweets, new object());
            BindingOperations.EnableCollectionSynchronization(_Mentions, new object());
        }
        /// <summary></summary>
        public string Title
        {
            get { return User == null ? "TweetWPF" : $"TweetWPF - @{User.ScreenName}"; }
        }
        /// <summary></summary>
        public IAuthenticatedUser _User;
        public IAuthenticatedUser User
        {
            get { return _User; }
            set
            {
                _User = value;
                RaisePropertyChanged(() => Title);
                RaisePropertyChanged(() => IsTweetEnabled);
            }
        }
        /// <summary></summary>
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { SetProperty(ref _Message, value); }
        }
        /// <summary></summary>
        private string _TweetText;
        public string TweetText
        {
            get { return _TweetText; }
            set { SetProperty(ref _TweetText, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<ITweet> _Tweets = new ObservableCollection<ITweet>();
        public ObservableCollection<ITweet> Tweets
        {
            get { return _Tweets; }
            set { SetProperty(ref _Tweets, value); }
        }
        /// <summary></summary>
        private ObservableCollection<ITweet> _Mentions = new ObservableCollection<ITweet>();
        public ObservableCollection<ITweet> Mentions
        {
            get { return _Mentions; }
            set { SetProperty(ref _Mentions, value); }
        }
        /// <summary></summary>
        public bool IsTweetEnabled
        {
            get { return User != null; }
        }
        /// <summary></summary>
        private bool _IsReloadEnabled = false;
        public bool IsReloadEnabled
        {
            get { return _IsReloadEnabled; }
            set { SetProperty(ref _IsReloadEnabled, value); }
        }
        /// <summary></summary>
        private string _SelectedTabHeader;
        public string SelectedTabHeader
        {
            get { return _SelectedTabHeader; }
            set { SetProperty(ref _SelectedTabHeader, value); }
        }
        /// <summary></summary>
        private ITweet _SelectedTweet;
        public ITweet SelectedTweet
        {
            get { return _SelectedTweet; }
            set { SetProperty(ref _SelectedTweet, value); }
        }
    }
}

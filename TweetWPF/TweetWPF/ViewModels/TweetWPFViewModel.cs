using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using Eleve;
using Tweetinvi.Models;
using TweetWPF.Models;

namespace TweetWPF.ViewModels
{
    public class TweetWPFViewModel : ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public TweetWPFViewModel()
        {
            BindingOperations.EnableCollectionSynchronization(_Tabs, new object());
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsInitialized { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        private Visibility _TabVisibility = Visibility.Collapsed;
        public Visibility TabVisibility
        {
            get { return _TabVisibility; }
            set { SetProperty(ref _TabVisibility, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<TweetTab> _Tabs = new ObservableCollection<TweetTab>();
        public ObservableCollection<TweetTab> Tabs
        {
            get { return _Tabs; }
            set { SetProperty(ref _Tabs, value); }
        }


        /// <summary></summary>
        private TweetTab _SelectedTabHeader;
        public TweetTab SelectedTabHeader
        {
            get { return _SelectedTabHeader; }
            set { SetProperty(ref _SelectedTabHeader, value); }
        }
    }
}

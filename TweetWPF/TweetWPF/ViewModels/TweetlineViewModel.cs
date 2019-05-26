using System.Collections.ObjectModel;
using System.Windows.Data;
using Eleve;
using Tweetinvi.Models;

namespace TweetWPF.ViewModels
{
    public class TweetlineViewModel : ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public TweetlineViewModel()
        {
            BindingOperations.EnableCollectionSynchronization(_Tweets, new object());
        }
        private ITweet _SelectedItem;
        public ITweet SelectedItem
        {
            get { return _SelectedItem; }
            set { SetProperty(ref _SelectedItem, value); }
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
    }
}

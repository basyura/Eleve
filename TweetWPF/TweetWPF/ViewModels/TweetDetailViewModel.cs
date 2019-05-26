using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;
using Tweetinvi.Models;

namespace TweetWPF.ViewModels
{
    public class TweetDetailViewModel : ViewModelBase
    {
        private ITweet _Tweet;
        public ITweet Tweet
        {
            get { return _Tweet; }
            set { SetProperty(ref _Tweet, value); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eleve;
using Tweetinvi;
using Tweetinvi.Models;
using TweetWPF.ViewModels;

namespace TweetWPF.Actions.Tweetline
{
    public class Initialize : TweetlineActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            IEnumerable<ITweet> tweets = Timeline.GetHomeTimeline();
            if (tweets != null)
            {
                foreach (ITweet tweet in tweets)
                {
                    ViewModel.Tweets.Add(tweet);
                }
            }

            // todo
            BeginInvoke(() => ((TweetWPFViewModel)(ViewModel.View.DataContext)).IsInitialized = true);

            return OK;
        }
    }
}

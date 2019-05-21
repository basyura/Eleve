using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eleve;
using Tweetinvi;
using Tweetinvi.Models;
using TweetWPF.ViewModels;

namespace TweetWPF.Actions.Tweetline
{
    public class Reload : TweetlineActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            // todo
            TweetWPFViewModel rootVM = obj as TweetWPFViewModel;

            rootVM.IsReloadEnabled = false;

            ReloadHomeTimeline();

            rootVM.IsReloadEnabled = true;

            return OK;
        }
        /// <summary>
        /// 
        /// </summary>
        private void ReloadHomeTimeline()
        {
            IEnumerable<ITweet> tweets = Timeline.GetHomeTimeline();
            if (tweets == null)
            {
                return;
            }
            ITweet last = ViewModel.Tweets.FirstOrDefault();

            foreach (ITweet tweet in tweets.Reverse())
            {
                if (last == null)
                {
                    ViewModel.Tweets.Insert(0, tweet);
                    continue;
                }

                // todo : retweet

                if (last.CreatedAt < tweet.CreatedAt)
                {
                    ViewModel.Tweets.Insert(0, tweet);
                    continue;
                }
            }
        }
    }
}

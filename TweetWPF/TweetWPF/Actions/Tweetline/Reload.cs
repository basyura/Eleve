using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eleve;
using Tweetinvi;
using Tweetinvi.Models;
using TweetWPF.Models;
using TweetWPF.ViewModels;

namespace TweetWPF.Actions.Tweetline
{
    public class Reload : TweetlineActionBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            // todo
            TweetWPFViewModel rootVM = obj as TweetWPFViewModel;

            rootVM.IsReloadEnabled = false;

            TweetTab tab = rootVM.SelectedTabHeader;

            ReloadTimeline(tab);

            rootVM.IsReloadEnabled = true;

            return OK;
        }
        /// <summary>
        /// 
        /// </summary>
        private void ReloadTimeline(TweetTab tab)
        {
            IEnumerable<ITweet> tweets = new List<ITweet>();
            List<ITweet> cache = null;

            if (tab.Key == "HOME")
            {
                tweets = Timeline.GetHomeTimeline();
                cache = ViewModel.HomeTweets;
            }
            else if (tab.Key == "MENTION")
            {
                tweets = Timeline.GetMentionsTimeline();
                cache = ViewModel.MentionTweets;
            }

            ITweet last = cache.LastOrDefault();

            foreach (ITweet tweet in tweets.Reverse())
            {
                if (last == null)
                {
                    cache.Insert(0, tweet);
                    ViewModel.Tweets.Insert(0, tweet);
                    continue;
                }

                // todo : retweet
                if (last.CreatedAt < tweet.CreatedAt)
                {
                    cache.Insert(0, tweet);
                    ViewModel.Tweets.Insert(0, tweet);
                    continue;
                }
            }
        }
    }
}

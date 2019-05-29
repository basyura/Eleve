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
    public class Initialize : TweetlineActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            NavigateParam param = obj as NavigateParam;

            if (param.Mode == NavigateMode.ChangeTab)
            {
                ChangeTab(param);
            }

            // todo
            BeginInvoke(() => ((TweetWPFViewModel)(ViewModel.View.DataContext)).IsInitialized = true);

            return OK;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        private void ChangeTab(NavigateParam param)
        {
            IEnumerable<ITweet> tweets = new List<ITweet>();

            if (param.Tab.Key == "HOME")
            {
                if (!ViewModel.HomeTweets.Any())
                {
                    ViewModel.HomeTweets = new List<ITweet>(Timeline.GetHomeTimeline());
                }

                tweets = ViewModel.HomeTweets;
            }
            else if (param.Tab.Key == "MENTION")
            {
                if (!ViewModel.MentionTweets.Any())
                {
                    ViewModel.MentionTweets = new List<ITweet>(Timeline.GetMentionsTimeline());
                }

                tweets = ViewModel.MentionTweets;
            }

            ViewModel.Tweets.Clear();
            tweets.ToList().ForEach(v => ViewModel.Tweets.Add(v));
        }
    }
}

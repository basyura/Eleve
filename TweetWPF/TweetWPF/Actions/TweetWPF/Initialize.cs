using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Eleve;
using Tweetinvi.Models;
using TweetWPF.Controls;

namespace TweetWPF.Actions.TweetWPF
{
    public class Initialize : TweetWPFActionBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override Task<ActionResult> Execute(object sender, EventArgs args, object parameter)
        {
            IAuthenticatedUser user = Authenticate();
            if (user == null)
            {
                ViewModel.Message = "failed to authenticate.";
                return OK;
            }

            ViewModel.User = user;
            ViewModel.IsReloadEnabled = true;

            BeginInvoke(() => Navigate<TimelineView>("Container"));
            /*
            IEnumerable<ITweet> tweets = Timeline.GetHomeTimeline();
            if (tweets != null)
            {
                foreach (ITweet tweet in tweets)
                {
                    ViewModel.Tweets.Add(tweet);
                }
            }

            IEnumerable<ITweet> mentions = Timeline.GetMentionsTimeline();
            if (mentions != null)
            {
                foreach (ITweet mention in mentions)
                {
                    ViewModel.Mentions.Add(mention);
                }
            }
            */

            return OK;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IAuthenticatedUser Authenticate()
        {
            string tokenPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config", "tweetwpf", "token.txt");
            string[] lines = File.ReadAllLines(tokenPath);

            Tweetinvi.Auth.SetUserCredentials(lines[0], lines[1], lines[2], lines[3]);

            IAuthenticatedUser user = Tweetinvi.User.GetAuthenticatedUser();

            return user;
        }
    }
}

using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Eleve;
using Tweetinvi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Eleve;

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

            return OK;
        }
    }
}

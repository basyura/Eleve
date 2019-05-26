using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;
using Tweetinvi.Models;

namespace TweetWPF.Actions.TweetDetail
{
    public class Initialize : TweetDetailActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            ITweet tweet = obj as ITweet;

            ViewModel.Tweet = tweet;


            return OK;
        }
    }
}

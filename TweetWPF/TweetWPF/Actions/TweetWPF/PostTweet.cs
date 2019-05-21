using System;
using System.Threading.Tasks;
using Eleve;
using Tweetinvi;
using Tweetinvi.Models;

namespace TweetWPF.Actions.TweetWPF
{
    public class PostTweet : TweetWPFActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            string text = ViewModel.TweetText;

            if (string.IsNullOrEmpty(text))
            {
                return OK;
            }
            
            try
            {
                ITweet tweet = Tweet.PublishTweet(text);
                // todo
                if (tweet != null)
                {
                    ViewModel.TweetText = "";
                }
            }
            catch (Exception)
            {
                // todo
            }

            return OK;
        }
    }
}

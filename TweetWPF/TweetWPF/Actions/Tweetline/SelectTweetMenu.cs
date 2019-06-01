using System;
using System.Threading.Tasks;
using Eleve;
using Tweetinvi;
using Tweetinvi.Models;

namespace TweetWPF.Actions.Tweetline
{
    public class SelectTweetMenu : TweetlineActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            string key = obj as string;
            if (string.IsNullOrEmpty(key))
            {
                return OK;
            }

            ITweet tweet = ViewModel.SelectedItem;
            if (tweet == null)
            {
                return OK;
            }

            if (key == "fav")
            {
                Tweet.FavoriteTweet(tweet);
                return OK;
            }

            if (key == "rewtweet")
            {
                Tweet.PublishRetweet(tweet);
                return OK;
            }

            if (key == "reply")
            {
            }

            return OK;
        }
    }
}

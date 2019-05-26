using System;
using System.Threading.Tasks;
using Eleve;
using TweetWPF.Views;

namespace TweetWPF.Actions.TweetWPF
{
    [ThreadMode(ThreadMode.Foreground)]
    public class ShowHome : TweetWPFActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            Navigate<TweetlineView>("Container");

            return OK;
        }
    }
}

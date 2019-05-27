using System;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using Eleve;
using TweetWPF.Extensions;
using TweetWPF.Views;

namespace TweetWPF.Actions.Tweetline
{
    [ThreadMode(ThreadMode.Foreground)]
    public class ShowDetail : TweetlineActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            if (args.HasParent<ScrollBar>())
            {
                return OK;
            }

            if (ViewModel.SelectedItem == null)
            {
                return OK;
            }

            NavigateTo<TweetDetailView>("Container", ViewModel.SelectedItem);

            return OK;
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using Eleve;
using TweetWPF.Controls;

namespace TweetWPF.Actions.TweetWPF
{
    [ThreadMode(ThreadMode.Foreground)]
    public class ShowDetail : TweetWPFActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            /*
            if (HasParent<ScrollBar>(args))
            {
                return OK;
            }

            TimelineView view = sender as TimelineView;

            view.Append(new DetailView()
            {
                DataContext = ViewModel.SelectedTweet
            });
            */

            return OK;
        }
    }
}

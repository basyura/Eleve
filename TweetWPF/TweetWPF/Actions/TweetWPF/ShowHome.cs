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
            if (!ViewModel.IsInitialized)
            {
                return OK;
            }

            string header = ViewModel.SelectedTabHeader;


            NavigateToCacheOrDefault<TweetlineView>("Container");

            return OK;
        }
    }
}

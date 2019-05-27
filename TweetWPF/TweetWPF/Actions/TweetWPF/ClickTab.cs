using Eleve;
using TweetWPF.Models;

namespace TweetWPF.Actions.TweetWPF
{
    [ThreadMode(ThreadMode.Foreground)]
    public class ClickTab : ChangeTab
    {
        protected override NavigateParam CreateParam()
        {
            return new NavigateParam
            {
                Tab = ViewModel.SelectedTabHeader,
                Mode = NavigateMode.ClickTab,
            };
        }
    }
}

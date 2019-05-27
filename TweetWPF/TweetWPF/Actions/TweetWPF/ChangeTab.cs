using System;
using System.Threading.Tasks;
using Eleve;
using TweetWPF.Models;
using TweetWPF.Views;

namespace TweetWPF.Actions.TweetWPF
{
    [ThreadMode(ThreadMode.Foreground)]
    public class ChangeTab : TweetWPFActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            if (!ViewModel.IsInitialized)
            {
                return OK;
            }

            NavigateParam param = CreateParam();

            NavigateToCacheOrDefault<TweetlineView>("Container", param);

            return OK;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual NavigateParam CreateParam()
        {
            return new NavigateParam
            {
                Tab = ViewModel.SelectedTabHeader,
                Mode = NavigateMode.ChangeTab,
            };
        }
    }
}

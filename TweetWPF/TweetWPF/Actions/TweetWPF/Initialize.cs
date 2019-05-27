using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Eleve;
using Tweetinvi;
using Tweetinvi.Models;
using TweetWPF.Views;

namespace TweetWPF.Actions.TweetWPF
{
    public class Initialize : TweetWPFActionBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override Task<ActionResult> Execute(object sender, EventArgs args, object parameter)
        {
            IAuthenticatedUser user = Authenticate();
            if (user == null)
            {
                ViewModel.Message = "failed to authenticate.";
                return OK;
            }

            ViewModel.User = user;
            ViewModel.IsReloadEnabled = true;

            BeginInvoke(() =>
            {
                ViewModel.Tabs.Add(" Home ");
                ViewModel.Tabs.Add(" Mention ");
                NavigateTo<TweetlineView>("Container");
                ViewModel.TabVisibility = Visibility.Visible;
            });

            return OK;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IAuthenticatedUser Authenticate()
        {
            string tokenPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config", "tweetwpf", "token.txt");
            string[] lines = File.ReadAllLines(tokenPath);

            Auth.SetUserCredentials(lines[0], lines[1], lines[2], lines[3]);

            IAuthenticatedUser user = User.GetAuthenticatedUser();

            return user;
        }
    }
}

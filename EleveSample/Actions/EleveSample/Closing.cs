using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class Closing : EleveSampleActionBase
    {
        public override async Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            if (ViewModel.IsTerminating)
            {
                return Success;
            }
            CancelEventArgs evnt = args as CancelEventArgs;
            evnt.Cancel = true;

            bool result = await Task.Run(() =>
            {
                Thread.Sleep(100);
                return true;
            });

            if (result)
            {
                ViewModel.IsTerminating = true;
                ShutDown();
            }

            return Success;
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual void ShutDown()
        {
            App.Current.Shutdown();
        }
    }
}

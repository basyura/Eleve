using System;
using System.Threading.Tasks;
using System.Windows;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class ShowMessage : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            MessageBoxResult res = ShowMessageBox();

            if (res == MessageBoxResult.OK)
            {
                ViewModel.Message = "OK";
            }
            else
            {
                ViewModel.Message = "not OK";
            }

            return OK;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual MessageBoxResult ShowMessageBox()
        {
            return MessageBox.Show("hello", "select", MessageBoxButton.OKCancel);
        }
    }
}

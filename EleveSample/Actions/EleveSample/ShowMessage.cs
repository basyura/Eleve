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
            MessageBoxResult res = MessageBox.Show("hello", "select", MessageBoxButton.OKCancel);

            if (res == MessageBoxResult.OK)
            {
                ViewModel.Message = "OK";
            }
            else
            {
                ViewModel.Message = "not OK";
            }

            return SuccessTask;
        }
    }
}

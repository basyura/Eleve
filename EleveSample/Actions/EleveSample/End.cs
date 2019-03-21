using System;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class End : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs evnt, object parameter)
        {
            ViewModel.Message = ViewModel.Counter.ToString();

            System.Threading.Thread.Sleep(3000);

            return SuccessTask;
        }
    }
}

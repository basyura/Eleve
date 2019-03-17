using System;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class Start : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs evnt, object parameter)
        {
            ViewModel.Counter = 0;

            return SuccessTask;
        }
    }
}

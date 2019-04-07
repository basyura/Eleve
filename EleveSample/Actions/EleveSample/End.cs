using System;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class End : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object parameter)
        {
            ViewModel.Message = ViewModel.Counter.ToString();

            return SuccessTask;
        }
    }
}

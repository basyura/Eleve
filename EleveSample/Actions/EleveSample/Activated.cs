using System;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class Activated : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            ViewModel.Message = "This window has become 'Active'";

            return SuccessTask;
        }
    }
}

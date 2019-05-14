using System;
using System.Threading;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    [ThreadMode(ThreadMode.Background)]
    public class Sleep : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            Thread.Sleep(5000);

            ViewModel.Message = "BG Sleep end";

            return OK;
        }
    }
}

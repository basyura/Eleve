using System;
using System.Threading;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class Hello : EleveSampleActionBase
    {
        public async override Task<ActionResult> Execute(object sender, EventArgs args, object parameter)
        {
            ViewModel.Message = "Hello";

            await Task.Run(() => {

                Thread.Sleep(1000);
                ViewModel.Message += " Wait";
                Thread.Sleep(1000);

            });

            ViewModel.Message += " World";

            return ActionResult.OK;
        }
    }
}

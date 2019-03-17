using System;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class Hello : EleveSampleActionBase
    {
        public async override Task<ActionResult> Execute(object sender, EventArgs evnt, object parameter)
        {
            ViewModel.Message = "Hello";

            await Task.Run(() => {

                System.Threading.Thread.Sleep(3000);
                ViewModel.Message += " Wait";

            });

            ViewModel.Message += " World";

            return Success;
        }
    }
}

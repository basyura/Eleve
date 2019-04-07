using System;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.ItemSelector
{
    public class Notify : ItemSelectorActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            CloseWindow(WindowCloseType.OK, ViewModel.ID);

            return SuccessTask;
        }
    }
}

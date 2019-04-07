using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.ItemSelector
{
    public class Initialize : ItemSelectorActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            ViewModel.ID = ((Dictionary<string, object>)obj)["ID"] as string;

            return SuccessTask;
        }
    }
}

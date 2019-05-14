using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eleve;
using EleveSample.Views;

namespace EleveSample.Actions.EleveSample
{
    public class OpenItemSelectorAsync : EleveSampleActionBase
    {
        public async override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            Dictionary<string, object> param = new Dictionary<string, object> {
                { "ID", "0000000001" }
            };

            WindowCloseResult ret = await OpenDialogWindowAsync<ItemSelectorView>(param);
            ViewModel.Message = ret.Type.ToString() + " - " + ret.Result??ToString();

            return ActionResult.OK;
        }
    }
}

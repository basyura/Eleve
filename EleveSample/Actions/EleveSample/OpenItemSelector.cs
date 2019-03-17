using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eleve;
using EleveSample.Views;

namespace EleveSample.Actions.EleveSample
{
    public class OpenItemSelector : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs e, object obj)
        {
            Dictionary<string, object> param = new Dictionary<string, object> {
                { "ID", "0000000001" }
            };

            OpenDialogWindow<ItemSelectorView>(param, (type, ret) => {
                ViewModel.Message = type.ToString() + " - " + ret;
            });

            return SuccessTask;
        }
    }
}

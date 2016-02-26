using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EleveSample.Views;

namespace EleveSample.Actions.EleveSample
{
    public class OpenItemSelector : EleveSampleActionBase
    {
        public override void Execute(object sender, EventArgs e, object obj)
        {
            Dictionary<string, object> param = new Dictionary<string, object> {
                { "ID", "0000000001" }
            };

            OpenDialogWindow<ItemSelectorView>(param, (type, ret) => {
                ViewModel.Message = type.ToString() + " - " + ret;
            });
        }
    }
}

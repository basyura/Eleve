using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleveSample.Actions.ItemSelector
{
    public class Initialize : ItemSelectorActionBase
    {
        public override void Execute(object sender, EventArgs e, object obj)
        {
            ViewModel.ID = ((Dictionary<string, object>)obj)["ID"] as string;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.ItemSelector
{
    public class Notify : ItemSelectorActionBase
    {
        public override void Execute(object sender, EventArgs e, object obj)
        {
            CloseWindow(WindowCloseType.OK, ViewModel.ID);
        }
    }
}

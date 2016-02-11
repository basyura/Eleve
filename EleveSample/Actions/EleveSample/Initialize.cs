using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class Initialize : EleveSampleActionBase
    {
        public override void Execute(object sender, EventArgs evnt, object parameter)
        {
            MessageBox.Show("initialized");
        }
    }
}

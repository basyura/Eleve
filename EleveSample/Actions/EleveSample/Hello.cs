using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleveSample.Actions.EleveSample
{
    public class Hello : EleveSampleActionBase
    {
        public override void Execute(object sender, EventArgs evnt, object parameter)
        {
            ViewModel.Message = "World";
        }
    }
}

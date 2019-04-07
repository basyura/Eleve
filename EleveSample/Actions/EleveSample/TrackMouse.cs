using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class TrackMouse : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object parameter)
        {
            MouseEventArgs evnt = args as MouseEventArgs;
            Point point = evnt.GetPosition((UIElement)sender);
            ViewModel.Message = string.Format("{0}, {1}", point.X, point.Y);
            ViewModel.Counter ++;

            return SuccessTask;
        }
    }
}

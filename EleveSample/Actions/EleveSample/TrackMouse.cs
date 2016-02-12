using System;
using System.Windows;
using System.Windows.Input;

namespace EleveSample.Actions.EleveSample
{
    public class TrackMouse : EleveSampleActionBase
    {
        public override void Execute(object sender, EventArgs evnt, object parameter)
        {
            MouseEventArgs args = evnt as MouseEventArgs;
            Point point = args.GetPosition((UIElement)sender);
            ViewModel.Message = string.Format("{0}, {1}", point.X, point.Y);
            ViewModel.Counter ++;
        }
    }
}

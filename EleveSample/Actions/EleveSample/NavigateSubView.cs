using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using Eleve;
using EleveSample.ViewModels;
using EleveSample.Views;

namespace EleveSample.Actions.EleveSample
{
    public class NavigateSubView : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            Navigate<UserView>("FrameContent");

            return OK;
        }
    }
}

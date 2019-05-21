using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;
using EleveSample.Views;

namespace EleveSample.Actions.User
{
    public class NavigateToDetail : UserActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            Navigate<UserDetailView>("FrameContent", new Dictionary<string, object> { { "Sample", "Parameter" } });


            return OK;
        }
    }
}

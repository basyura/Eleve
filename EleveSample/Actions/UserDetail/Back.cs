using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.UserDetail
{
    public class Back : UserDetailActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            NavigateBack("FrameContent");

            return OK;
        }
    }
}

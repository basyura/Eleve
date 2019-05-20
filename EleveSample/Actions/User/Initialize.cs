using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.User
{
    public class Initialize : UserActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            return OK;
        }
    }
}

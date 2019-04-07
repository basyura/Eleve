using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Eleve;

namespace $safeprojectname$.Actions.$safeprojectname$
{
    public class Initialize : $safeprojectname$ActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object parameter)
        {
            return SuccessTask;
        }
    }
}

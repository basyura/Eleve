using System;
using System.Threading.Tasks;
using Eleve;

namespace $safeprojectname$.Actions.$safeprojectname$
{
    public class Hello : $safeprojectname$ActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs e, object obj)
        {
            ViewModel.Message = "World";

            return SuccessTask;
        }
    }
}
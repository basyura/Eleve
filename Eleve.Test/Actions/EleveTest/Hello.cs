using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;
using EleveTest.ViewModels;

namespace EleveTest.Actions.EleveTest
{
    public class Hello : ActionBase<EleveTestViewModel>
    {
        public override Task<ActionResult> Execute(object sender, EventArgs e, object obj)
        {
            return OK;
        }
    }
}

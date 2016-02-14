using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve.ProjectTemplate.Models;

namespace Eleve.ProjectTemplate.Actions.ToolName
{
    public class Initialize : ToolNameActionBase
    {
        public override void Execute(object sender, EventArgs evnt, object parameter)
        {
            ViewModel.SampleMessage = new SampleMessage()
            {
                Message = "Hello Eleve !!!"
            };
        }
    }
}

using System;
using System.Threading.Tasks;
using Eleve;
using EleveSample.Models;

namespace EleveSample.Actions.EleveSample
{
    public class Delete : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            Person person = obj as Person;

            ViewModel.Persons.Remove(person);

            return SuccessTask;
        }
    }
}

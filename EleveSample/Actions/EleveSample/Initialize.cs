using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Eleve;
using EleveSample.Models;

namespace EleveSample.Actions.EleveSample
{
    public class Initialize : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs evnt, object parameter)
        {
            ViewModel.Message = "Initialized";

            ViewModel.Persons = new ObservableCollection<Person>(Enumerable.Range(1, 50).Select(i => 
            {
                return new Person {
                    ID = i,
                    Name = "なまえ " + i.ToString().PadLeft(3, '0'),
                };
            }));

            return SuccessTask;
        }
    }
}

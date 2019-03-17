using System;
using System.Threading.Tasks;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EleveSample.Models;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class SelectPerson : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs evnt, object parameter)
        {
            SelectionChangedEventArgs args = evnt as SelectionChangedEventArgs;
            // 取れない場合は終了
            if (args.AddedItems == null || args.AddedItems.Count == 0)
            {
                return SuccessTask;
            }
            Person person = args.AddedItems[0] as Person;
            // 取れない場合がある
            if (person == null)
            {
                return SuccessTask;
            }

            ViewModel.PersonVisibility   = Visibility.Visible;
            ViewModel.SelectedPersonID   = person.ID;
            ViewModel.SelectedPersonName = person.Name;

            return SuccessTask;
        }
    }
}

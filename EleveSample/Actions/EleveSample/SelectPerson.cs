﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Eleve;
using EleveSample.Models;

namespace EleveSample.Actions.EleveSample
{
    public class SelectPerson : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object parameter)
        {
            SelectionChangedEventArgs evnt = args as SelectionChangedEventArgs;
            // 取れない場合は終了
            if (evnt.AddedItems == null || evnt.AddedItems.Count == 0)
            {
                return OK;
            }
            Person person = evnt.AddedItems[0] as Person;
            // 取れない場合がある
            if (person == null)
            {
                return OK;
            }

            ViewModel.PersonVisibility   = Visibility.Visible;
            ViewModel.SelectedPersonID   = person.ID;
            ViewModel.SelectedPersonName = person.Name;

            return OK;
        }
    }
}

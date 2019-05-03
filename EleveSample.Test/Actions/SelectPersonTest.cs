using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Eleve;
using EleveSample.Actions.EleveSample;
using EleveSample.Models;
using EleveSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class SelectPersonTest : ActionTestBase<EleveSampleViewModel>
    {
        [TestMethod]
        public void ExecuteSelectPerson()
        {
            var args = new SelectionChangedEventArgs(
                DataGrid.SelectionChangedEvent,
                new List<Person>(),
                new List<Person> { new Person { ID = 100, Name = "Hoge" } }
            );

            Invoke<SelectPerson>(args, (ret, vm) =>
            {
                Assert.AreEqual(ret.Status, ActionStatus.Success);
                Assert.AreEqual(vm.PersonVisibility, Visibility.Visible);
                Assert.AreEqual(vm.SelectedPersonID, 100);
                Assert.AreEqual(vm.SelectedPersonName, "Hoge");
            });
        }
    }
}

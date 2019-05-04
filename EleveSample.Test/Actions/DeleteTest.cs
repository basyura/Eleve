using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EleveSample.Actions.EleveSample;
using EleveSample.Models;
using EleveSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class DeleteTest : ActionTestBase<EleveSampleViewModel>
    {
        [TestMethod]
        public void ExecuteDelete()
        {
            var person1 = new Person() { ID = 1, Name = "001" };
            var person2 = new Person() { ID = 2, Name = "002" };

            var persons = new List<Person> { person1, person2 };

            var vm = new EleveSampleViewModel
            {
                Persons = new ObservableCollection<Person>(persons)
            };

            Invoke<Delete>(vm, null, null, person2, (res, _) =>
            {
                Assert.AreEqual(vm.Persons.Count, 1);
                Assert.AreEqual(vm.Persons.First().ID, 1);
                Assert.AreEqual(vm.Persons.First().Name, "001");
            });
        }
    }
}

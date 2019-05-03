using Eleve;
using EleveSample.Actions.EleveSample;
using EleveSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class InitializeTest : ActionTestBase
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Invoke<Initialize, EleveSampleViewModel>((ret, vm) => {
                Assert.AreEqual(ret.Status, ActionStatus.Success);
                Assert.AreEqual(vm.Persons.Count, 50);
            });
        }
    }
}

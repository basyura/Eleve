using Eleve;
using EleveSample.Actions.EleveSample;
using EleveSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class InitializeTest : ActionTestBase<EleveSampleViewModel>
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Invoke<Initialize>((ret, vm) => {
                Assert.AreEqual(ret.Status, ActionStatus.OK);
                Assert.AreEqual(vm.Persons.Count, 50);
            });
        }
    }
}

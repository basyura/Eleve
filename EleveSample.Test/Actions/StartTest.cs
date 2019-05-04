using EleveSample.Actions.EleveSample;
using EleveSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class StartTest : ActionTestBase<EleveSampleViewModel>
    {
        [TestMethod]
        public void ExecuteStart()
        {
            var vm = new EleveSampleViewModel()
            {
                Counter = 100
            };
            Invoke<Start>(vm, (res, _) => {
                Assert.AreEqual(0, vm.Counter);
            });
        }
    }
}

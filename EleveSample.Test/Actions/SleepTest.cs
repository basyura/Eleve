using EleveSample.Actions.EleveSample;
using EleveSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class SleepTest : ActionTestBase<EleveSampleViewModel>
    {
        [TestMethod]
        public void ExecuteSleep()
        {
            Invoke<Sleep>((res, vm) =>
            {
                Assert.AreEqual(vm.Message, "BG Sleep end");
            });
        }
    }
}

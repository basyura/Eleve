using System.Threading.Tasks;
using EleveSample.Actions.EleveSample;
using EleveSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class HelloTest : ActionTestBase<EleveSampleViewModel>
    {
        [TestMethod]
        public async Task ExecuteTest()
        {
            await InvokeAsync<Hello>((ret, vm) => {
                Assert.AreEqual(vm.Message, "Hello Wait World");
            });
        }
    }
}

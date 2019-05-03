using System.Threading.Tasks;
using EleveSample.Actions.EleveSample;
using EleveSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class HelloTest : ActionTestBase
    {
        [TestMethod]
        public async Task ExecuteTest()
        {
            await InvokeAsync<Hello, EleveSampleViewModel>((ret, vm) => {
                Assert.AreEqual(vm.Message, "Hello Wait World");
            });
        }
    }
}

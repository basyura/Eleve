using System.Windows.Controls;
using EleveSample.Actions.EleveSample;
using EleveSample.ViewModels;
using EleveSample.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class ComputeTest : ActionTestBase<EleveSampleViewModel>
    {
        [TestMethod]
        public void ExecuteTest()
        {
            var vm = new EleveSampleViewModel
            {
                View = new EleveSampleView()
            };

            vm.GetElement<TextBox>("ComputeA").Text = "10";
            vm.GetElement<TextBox>("ComputeB").Text = "20";

            Invoke<Compute>(vm, (res, _) =>
            {
                var total = vm.GetElement<TextBlock>("ComputeResult").Text;
                Assert.AreEqual("30", total);
            });
        }
    }
}

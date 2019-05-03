using System;
using System.ComponentModel;
using System.Threading.Tasks;
using EleveSample.Actions.EleveSample;
using EleveSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class ClosingTest : ActionTestBase<EleveSampleViewModel>
    {
        [TestMethod]
        public async Task ExecuteTest()
        {
            var args = new CancelEventArgs();

            await InvokeAsync<ClosingExt>(args, (res, vm) => {
                Assert.AreEqual(args.Cancel, true);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ExecuteTest2()
        {
            var vm = new EleveSampleViewModel()
            {
                IsTerminating = true
            };

            await InvokeAsync<ClosingRaiseIfShutDown>(vm, null, (res, _) => {
                Assert.AreEqual(vm.IsTerminating, true);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        public class ClosingExt : Closing
        {
            protected override void ShutDown()
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public class ClosingRaiseIfShutDown: Closing
        {
            protected override void ShutDown()
            {
                throw new Exception("error");
            }
        }
    }
}

using System.Windows;
using EleveSample.Actions.EleveSample;
using EleveSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class ShowMessageTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            var a = new ShowMessageOK();
            a.Initialize(new EleveSampleViewModel());
            a.Execute(null, null, null);
            Assert.AreEqual(a.ViewModel.Message, "OK");
        }
        /// <summary>
        /// 
        /// </summary>
        public class ShowMessageOK : ShowMessage
        {
            protected override MessageBoxResult ShowMessageBox()
            {
                return MessageBoxResult.OK;
            }
        }
    }
}

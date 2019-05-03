﻿using System.Windows;
using EleveSample.Actions.EleveSample;
using EleveSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class ShowMessageTest : ActionTestBase
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Invoke<ShowMessageOK, EleveSampleViewModel>((ret, vm) =>
            {
                Assert.AreEqual(vm.Message, "OK");
            });
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

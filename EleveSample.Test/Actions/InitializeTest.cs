using System;
using Eleve;
using EleveSample.Actions.EleveSample;
using EleveSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EleveSample.Test.Actions
{
    [TestClass]
    public class InitializeTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Invoke<Initialize, EleveSampleViewModel>((ret, vm) => {
                Assert.AreEqual(ret.Status, ActionStatus.Success);
                Assert.AreEqual(vm.Persons.Count, 50);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="assert"></param>
        private void Invoke<A, V>(Action<ActionResult, V> assert) where A : ActionBase<V> , new() where V : ViewModelBase, new ()
        {
            var a = new A();
            a.Initialize(new V());
            var ret = a.Execute(null, null, null);
            assert(ret.Result, a.ViewModel);
        }
    }
}

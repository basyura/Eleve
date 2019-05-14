using System;
using System.Threading.Tasks;
using EleveTest.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eleve.Test
{
    [TestClass]
    public class ExecuteTest
    {
        [TestMethod]
        public void ActionInvokeTest()
        {
            Invoke(new EleveTestViewModel(), "Hello", (result) => 
            {
                if (result.Status != ActionStatus.OK)
                {
                    Assert.Fail();
                }

                if (!string.IsNullOrEmpty(result.Message))
                {
                    Assert.Fail();
                }
            });
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ViewModelNotFoundTest()
        {
            Invoke(null, "Hello", (result) =>
            {
                if (result.Status != ActionStatus.ViewModelNotFound)
                {
                    Assert.Fail();
                }

                if (result.Message != "ViewModel not found.")
                {
                    Assert.Fail();
                }
            });
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ActionNotFoundTest()
        {
            Invoke(new EleveTestViewModel(), "Hello2", (result) =>
            {
                if (result.Status != ActionStatus.ActionNotFound)
                {
                    Assert.Fail();
                }

                if (result.Message != "EleveTest.Actions.EleveTest.Hello2 not found.")
                {
                    Assert.Fail();
                }
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="action"></param>
        /// <param name="assert"></param>
        private void Invoke(ViewModelBase vm, string action, Action<ActionResult> assert)
        {
            TaskCompletionSource<ActionResult> source = new TaskCompletionSource<ActionResult>();

            new TaskFactory().StartNew(async () =>
            {
                Execute execute = new Execute()
                {
                    ViewModel = vm,
                    Action = action,
                };
                source.SetResult(await execute.__InvokeAsync__(null));
            });

            assert(source.Task.Result);
        }
    }
}

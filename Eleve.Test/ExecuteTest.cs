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
            TaskCompletionSource<ActionResult> source = new TaskCompletionSource<ActionResult>();

            new TaskFactory().StartNew(async () =>
            {
                Execute execute = new Execute()
                {
                    ViewModel = new EleveTestViewModel(),
                    Action = "Hello",
                };
                source.SetResult(await execute.__InvokeAsync__(null));
            });

            ActionResult ret = source.Task.Result;

            if (ret.Status != ActionStatus.Success)
            {
                Assert.Fail();
            }
        }
    }
}

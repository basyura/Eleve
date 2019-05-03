using System;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Test.Actions
{
    public class ActionTestBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="assert"></param>
        protected void Invoke<A, V>(Action<ActionResult, V> assert) where A : ActionBase<V> , new() where V : ViewModelBase, new ()
        {
            var a = new A();
            a.Initialize(new V());
            var ret = a.Execute(null, null, null);
            assert(ret.Result, a.ViewModel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="assert"></param>
        protected void Invoke<A, V>(EventArgs args, Action<ActionResult, V> assert) where A : ActionBase<V> , new() where V : ViewModelBase, new ()
        {
            var a = new A();
            a.Initialize(new V());
            var ret = a.Execute(null, args, null);
            assert(ret.Result, a.ViewModel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="assert"></param>
        protected async Task InvokeAsync<A, V>(Action<ActionResult, V> assert) where A : ActionBase<V> , new() where V : ViewModelBase, new ()
        {
            var a = new A();
            a.Initialize(new V());
            var ret = await a.Execute(null, null, null);
            assert(ret, a.ViewModel);
        }
    }
}

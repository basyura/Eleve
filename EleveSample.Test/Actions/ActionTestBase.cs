using System;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Test.Actions
{
    public class ActionTestBase<V> where V : ViewModelBase, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="assert"></param>
        protected void Invoke<A>(Action<ActionResult, V> assert) where A : ActionBase<V> , new()
        {
            Invoke<A>(new V(), null, null, null, assert);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="assert"></param>
        protected void Invoke<A>(EventArgs args, Action<ActionResult, V> assert) where A : ActionBase<V> , new()
        {
            Invoke<A>(new V(), null, args, null, assert);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="obj"></param>
        /// <param name="assert"></param>
        protected void Invoke<A>(object sender, EventArgs args, object obj, Action<ActionResult, V> assert) where A : ActionBase<V> , new()
        {
            Invoke<A>(new V(), sender, args, obj, assert);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="vm"></param>
        /// <param name="args"></param>
        /// <param name="assert"></param>
        protected void Invoke<A>(V vm, Action<ActionResult, V> assert) where A : ActionBase<V> , new()
        {
            Invoke<A>(vm, null, null, null, assert);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="vm"></param>
        /// <param name="args"></param>
        /// <param name="assert"></param>
        protected void Invoke<A>(V vm, EventArgs args, Action<ActionResult, V> assert) where A : ActionBase<V> , new()
        {
            Invoke<A>(vm, null, args, null, assert);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="vm"></param>
        /// <param name="args"></param>
        /// <param name="assert"></param>
        protected void Invoke<A>(V vm, object sender, EventArgs args, object obj, Action<ActionResult, V> assert) where A : ActionBase<V> , new()
        {
            var a = new A();
            a.Initialize(vm);
            var ret = a.Execute(sender, args, obj);
            assert(ret.Result, a.ViewModel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="assert"></param>
        protected async Task InvokeAsync<A>(Action<ActionResult, V> assert) where A : ActionBase<V> , new()
        {
            await InvokeAsync<A>(new V(), null, assert);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="args"></param>
        /// <param name="assert"></param>
        /// <returns></returns>
        protected async Task InvokeAsync<A>(EventArgs args, Action<ActionResult, V> assert) where A : ActionBase<V> , new()
        {
            await InvokeAsync<A>(new V(), args, assert);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="vm"></param>
        /// <param name="args"></param>
        /// <param name="assert"></param>
        /// <returns></returns>
        protected async Task InvokeAsync<A>(V vm, EventArgs args, Action<ActionResult, V> assert) where A : ActionBase<V> , new()
        {
            var a = new A();
            a.Initialize(vm);
            var ret = await a.Execute(null, args, null);
            assert(ret, a.ViewModel);
        }
    }
}

using System;
using System.Windows;
using System.Windows.Threading;

namespace Eleve
{
    /// <summary>
    /// ViewModelの基底クラスです。
    /// </summary>
    [Serializable]
    public abstract class ViewModelBase : NotificationObject,IDisposable
    {
        [NonSerialized]
        private bool _disposed;
        /// <summary></summary>
        public Window   View { get; set; }
        /// <summary></summary>
        internal Action<WindowCloseType, object> CloseWindowAction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        /// <param name="IsTool"></param>
        internal void Initialize(ViewBase view)
        {
            View = view;
            View.Closed += view_Closed;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetElement<T>(string name)
        {
            object obj = View.FindName(name);
            return (T)obj;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="param"></param>
        public void ExecuteCommand(string name, object param = null)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => {
                Execute command = new Execute(name) {
                    ViewModel       = this,
                    ActionParameter = param,
                };
                command.__Invoke__(new EventArgs());
            }));
        }
        /// <summary>
        /// ウインドウ起動時に x ボタンを押された場合はここが呼ばれる
        /// ActionBase#CloseWindow → view_Closed の順に呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_Closed(object sender, EventArgs e)
        {
            View.Closed -= view_Closed;
            // 明示的に ActionBase#CloseWindow した場合は null クリアされる
            if (CloseWindowAction != null)
            {
                CloseWindowAction(WindowCloseType.Close , null);
            }
            Dispose();
        }
        /// <summary>
        /// このインスタンスによって使用されているすべてのリソースを解放します。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                View = null;
                CloseWindowAction = null;
            }
            _disposed = true;
        }
    }
}
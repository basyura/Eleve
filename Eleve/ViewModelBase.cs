using System;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Serialization;

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
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetControl<T>(string name)
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
                    MethodParameter = param,
                };
                command.__Invoke__(new EventArgs());
            }));
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
            }
            _disposed = true;
        }
    }
}
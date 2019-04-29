using System;
using System.Threading.Tasks;
using System.Windows;
using Eleve.Log;

namespace Eleve
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public abstract class ActionBase<TViewModel> : IActionCommand where TViewModel : ViewModelBase
    {
        /// <summary></summary>
        public TViewModel ViewModel { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vm"></param>
        public void Initialize(ViewModelBase vm)
        {
            ViewModel = (TViewModel)vm;
        }
        /// <summary>
        /// 
        /// </summary>
        public abstract Task<ActionResult> Execute(object sender, EventArgs args, object obj);
        /// <summary>
        /// 
        /// </summary>
        protected Task<ActionResult> SuccessTask
        {
            get {  return Task.Run(() => new ActionResult(ActionStatus.Success)); }
        }
        /// <summary>
        /// 
        /// </summary>
        protected ActionResult Success
        {
            get {  return new ActionResult(ActionStatus.Success); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        protected void BeginInvoke(Action action)
        {
            Application.Current.Dispatcher.BeginInvoke(action);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected T GetElement<T>(string name, Action<T> action = null)
        {
            T control = ViewModel.GetElement<T>(name);
            if (action != null)
            {
                action(control);
            }
            return control;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        protected void ExecuteCommand(string name, object param = null)
        {
            ViewModel.ExecuteCommand(name, param);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        protected void ExecuteCommand<T>(object param = null) where T : IActionCommand
        {
            string name = typeof(T).Name;
            ExecuteCommand(name, param);
        }
        /// <summary>
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        protected void OpenDialogWindow<T>(object parameter = null, Action<WindowCloseType, object> callBack = null) where T : ViewBase, new()
        {
            OpenWindow<T>(parameter, callBack, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        protected Task<WindowCloseResult> OpenDialogWindowAsync<T>(object parameter = null) where T : ViewBase, new()
        {
            return OpenAsync<T>(parameter, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        /// <param name="callBack"></param>
        protected void OpenWindow<T>(object parameter = null, Action<WindowCloseType, object> callBack = null) where T : ViewBase, new()
        {
            OpenWindow<T>(parameter, callBack, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected Task<WindowCloseResult> OpenWindowAsync<T>(object parameter = null) where T : ViewBase, new()
        {
            return OpenAsync<T>(parameter, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        /// <param name="isDialog"></param>
        /// <returns></returns>
        private Task<WindowCloseResult> OpenAsync<T>(object parameter, bool isDialog) where T : ViewBase, new()
        {
            TaskCompletionSource<WindowCloseResult> source = new TaskCompletionSource<WindowCloseResult>();

            OpenWindow<T>(parameter, (type, obj) => {
                source.SetResult(new WindowCloseResult(type, obj));
            } , isDialog);

            return source.Task;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        /// <param name="callBack"></param>
        private void OpenWindow<T>(object parameter, Action<WindowCloseType, object> callBack, bool isDialog) where T : ViewBase, new()
        {
            if (!Application.Current.Dispatcher.CheckAccess())
            {
                throw new Exception("You must add class attribute [ThreadMode(ThreadMode.Foreground)] to " + this.GetType().Name);
            }

            T view = new T()
            {
                Owner = ViewModel.View
            };

            ViewModelBase vm = ((ViewModelBase)view.DataContext);

            vm.CloseWindowAction = callBack;
            // 呼び出し
            vm.ExecuteCommand("Initialize", parameter);
            // 表示
            if (isDialog)
            {
                view.ShowDialog();
            }
            else
            {
                view.Show();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected void CloseWindow(WindowCloseType type, object param = null)
        {
            // 非表示にしたほうが速く感じる？
            ViewModel.View.Visibility = Visibility.Collapsed;

            BeginInvoke(() =>
            {
                if (ViewModel.CloseWindowAction != null)
                {
                    ViewModel.CloseWindowAction(type, param);
                    ViewModel.CloseWindowAction = null;
                }
                ViewModel.View.Close();
            });
        }
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="param"></param>
        protected void Debug(string message, params object[] param)
        {
            Logger.Deubg(message, param);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="param"></param>
        protected void Info(string message, params object[] param)
        {
            Logger.Info(message, param);
        }
    }
}

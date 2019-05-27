using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        protected Task<ActionResult> OK
        {
            get {  return Task.Run(() => new ActionResult(ActionStatus.OK)); }
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
        /// <typeparam name="FrameworkElement"></typeparam>
        /// <param name="content"></param>
        protected void NavigateTo<T>(string containerContentName, object param = null) where T : FrameworkElement, new()
        {
            T view = new T();

            ContentControl content = GetElement<ContentControl>(containerContentName);

            if (content.Content != null)
            {
                // Content's ViewModel
                if (((ViewModelBase)((FrameworkElement)content.Content).DataContext).IsCacheViewOnNavigate)
                {
                    // Window's ViewModel
                    ((ViewModelBase)(ViewModel.View.DataContext)).NavigationCache.Add(content.Content);
                }
            }

            content.Content = view;

            ViewModelBase vm = ((ViewModelBase)view.DataContext);
            vm.View = ViewModel.View;

            // 呼び出し
            vm.ExecuteCommand("Initialize", param);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="containerContentName"></param>
        /// <param name="param"></param>
        protected void NavigateToCacheOrDefault<T>(string containerContentName, object param = null) where T : FrameworkElement, new()
        {
            ViewModelBase vm = ViewModel.View.DataContext as ViewModelBase;
            T view = vm.NavigationCache.OfType<T>().FirstOrDefault();

            if (view == null)
            {
                NavigateTo<T>(containerContentName, param);
                return;
            }


            ContentControl content = GetElement<ContentControl>(containerContentName);

            if (content.Content != null)
            {
                // Content's ViewModel
                if (((ViewModelBase)((FrameworkElement)content.Content).DataContext).IsCacheViewOnNavigate)
                {
                    // Window's ViewModel
                    ((ViewModelBase)(ViewModel.View.DataContext)).NavigationCache.Add(content.Content);
                }
            }


            content.Content = view;
            ((ViewModelBase)(view.DataContext)).ExecuteCommand("Restore", param);
        }
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerContentName"></param>
        /// <returns></returns>
        protected bool NavigateBack(string containerContentName)
        {
            var rootVM = (ViewModelBase)ViewModel.View.DataContext;
            var frames = rootVM.Frames[containerContentName];

            if (frames == null || frames.Count == 0)
            {
                return false;
            }

            FrameworkElement ele = frames.Pop();
            ContentControl content = GetElement<ContentControl>(containerContentName);
            content.Content = ele;

            return true;
        }
        */
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

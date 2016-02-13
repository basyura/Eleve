using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
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
        public virtual void Execute(object sender, EventArgs evnt, object parameter)
        {
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
        /// <param name="messageId"></param>
        /// <returns></returns>
        protected MessageBoxResult ShowMessage(string messageId, MessageBoxButton button, MessageBoxImage icon)
        {
            // MDB からメッセージを取得する
            return MessageBox.Show("", "", button, icon);
        }
        /// <summary>
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

using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Eleve;
using TweetWPF.ViewModels;

namespace TweetWPF.Actions.TweetWPF
{
    public abstract class TweetWPFActionBase : ActionBase<TweetWPFViewModel>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        protected bool HasParent<T>(EventArgs args) where T : DependencyObject
        {
            MouseEventArgs ev = args as MouseEventArgs;
            if (ev == null)
            {
                throw new NotSupportedException();
            }

            return HasParent<T>(ev.OriginalSource as DependencyObject);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ele"></param>
        /// <returns></returns>
        protected bool HasParent<T>(DependencyObject ele) where T : DependencyObject
        {
            while (ele != null)
            {
                ele = VisualTreeHelper.GetParent(ele);
                if (ele is T)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TweetWPF.Extensions
{
    public static class DependencyObjectExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool HasParent<T>(this EventArgs args) where T : DependencyObject
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
        public static bool HasParent<T>(this DependencyObject ele) where T : DependencyObject
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

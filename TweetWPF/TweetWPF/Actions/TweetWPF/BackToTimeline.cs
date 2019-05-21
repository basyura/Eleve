using System;
using System.Threading.Tasks;
using System.Windows;
using Eleve;
using TweetWPF.Controls;

namespace TweetWPF.Actions.TweetWPF
{
    [ThreadMode(ThreadMode.Foreground)]
    public class BackToTimeline : TweetWPFActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            DetailView detail = obj as DetailView;

            FrameworkElement ele = sender as FrameworkElement;
            while (!(ele is TimelineView))
            {
                ele = ele.Parent as FrameworkElement;
            }

            if (ele != null)
            {
                TimelineView view = ele as TimelineView;
                view.Remove(detail);
            }

            return OK;
        }
    }
}

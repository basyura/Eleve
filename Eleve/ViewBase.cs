using System.Windows;

namespace Eleve
{
    public class ViewBase : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public ViewBase()
        {
        }
        /// <summary>
        /// </summary>
        public override void OnApplyTemplate()
        {
            ((ViewModelBase)this.DataContext).View = this;
            base.OnApplyTemplate();
        }
    }
}

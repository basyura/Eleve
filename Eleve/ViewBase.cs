using System.Windows;

namespace Eleve
{
    public class ViewBase : Window
    {
        /// <summary></summary>
        private bool _isInitialized = false;
        /// <summary>
        /// 
        /// </summary>
        public ViewBase()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            if (!_isInitialized)
            {
                ((ViewModelBase)this.DataContext).Initialize(this);
                _isInitialized = true;
            }
            base.OnApplyTemplate();
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace TweetWPF.Controls.Behaviors
{
    public class TextBoxLinesBehavior : Behavior<TextBox>
    {
        /// <summary></summary>
        private double? InitialHeight { get; set; }
        /// <summary></summary>
        private double? FocusedtHeight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += AssociatedObject_GotFocus;
            AssociatedObject.LostFocus += AssociatedObject_LostFocus;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Loaded -= AssociatedObject_GotFocus;
            AssociatedObject.LostFocus -= AssociatedObject_LostFocus;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox text = sender as TextBox;
            if (FocusedtHeight == null)
            {
                InitialHeight = text.ActualHeight;
                // don't work
                text.MinLines = 3;
            }
            else
            {
                text.Height = FocusedtHeight.Value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox text = sender as TextBox;
            if (FocusedtHeight == null)
            {
                FocusedtHeight = text.ActualHeight;
            }
            text.Height = InitialHeight.Value;
            // don't work
            text.MinLines = 1;
        }
    }
}

using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace TweetWPF.Views
{
    /// <summary>
    /// TimelineView.xaml の相互作用ロジック
    /// </summary>
    public partial class TweetlineView : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public TweetlineView()
        {
            InitializeComponent();

            // todo
            Timeline.SelectionChanged += Timeline_SelectionChanged;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timeline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count == 0)
            {
                return;
            }

            SelectedItem = e.AddedItems[0];
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof(IEnumerable), typeof(TweetlineView), new PropertyMetadata(null, (d, e) => {
                TweetlineView view = d as TweetlineView;
                view.Timeline.ItemsSource = e.NewValue as IEnumerable;
            }));
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof(object), typeof(TweetlineView), new PropertyMetadata(null, (d, e) => {
                TweetlineView view = d as TweetlineView;
                view.Timeline.SelectedItem = e.NewValue;
            }));
        /// <summary>
        /// 
        /// </summary>
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
    }
}

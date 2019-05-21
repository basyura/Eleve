using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace TweetWPF.Controls
{
    /// <summary>
    /// TimelineView.xaml の相互作用ロジック
    /// </summary>
    public partial class TimelineView : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public TimelineView()
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
            "ItemsSource", typeof(IEnumerable), typeof(TimelineView), new PropertyMetadata(null, (d, e) => {
                TimelineView view = d as TimelineView;
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
            "SelectedItem", typeof(object), typeof(TimelineView), new PropertyMetadata(null, (d, e) => {
                TimelineView view = d as TimelineView;
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

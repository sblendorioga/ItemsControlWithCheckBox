using ItemsControlWithCheckBox.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItemsControlWithCheckBox.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MyItemsControl : UserControl
    {
        public MyItemsControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<ISelectableItem> Items
        {
            get { return (ObservableCollection<ISelectableItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for People.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(nameof(Items), typeof(ObservableCollection<ISelectableItem>), typeof(MyItemsControl), new PropertyMetadata(null, OnItemsPropertyChanged));

        
        private static void OnItemsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Called once when the Items property is bound
            var mySelf = (MyItemsControl)d;

            // Add a "SelectionChenged" event handler for each item
            foreach (var item in mySelf.Items)
            {
                item.SelectionChanged += (s, evt) => CheckSelection(mySelf.Items);
            }
        }

        /// <summary>
        /// Handle the selection items behavior. No items selected is not permitted.
        /// </summary>
        /// <param name="items"></param>
        private static void CheckSelection(ObservableCollection<ISelectableItem> items)
        {
            // Enable all items
            foreach (var item in items)
            {
                item.IsEnabled = true;
            }

            // Gets the count of selected items
            var selectionCount = items.Count(item => item.IsSelected);
            if(selectionCount == 1)
            {
                // If a single item is selected becomes reaod only (disabled)
                items.Single(item => item.IsSelected).IsEnabled = false;
            }
        }
    }
}

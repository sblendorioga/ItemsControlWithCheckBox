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
            DependencyProperty.Register(nameof(Items), typeof(ObservableCollection<ISelectableItem>), typeof(MyItemsControl), new PropertyMetadata(null, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var mySelf = (MyItemsControl)d;

            foreach (var item in mySelf.Items)
            {
                item.SelectionChanged += (s, evt) => CheckSelection(mySelf.Items);
            }
        }

        private static void CheckSelection(ObservableCollection<ISelectableItem> items)
        {
            foreach (var item in items)
            {
                item.IsEnabled = true;
            }

            var selectionCount = items.Count(p => p.IsSelected);
            if(selectionCount == 1)
            {
                items.Single(p => p.IsSelected).IsEnabled = false;
            }
        }
    }
}

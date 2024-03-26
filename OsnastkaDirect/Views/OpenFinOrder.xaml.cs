using OsnastkaDirect.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OsnastkaDirect.Views
{
    /// <summary>
    /// Логика взаимодействия для OpenFinOrder.xaml
    /// </summary>
    public partial class OpenFinOrder : Window
    {
        public OpenFinOrder()
        {
            InitializeComponent();
        }
        public void TreeViewSelectedItemChanged2()
        {
            //TreeViewItem item = TreeView.SelectedItem as TreeViewItem;
            //if (item != null)
            //{
            //    var j = new System.Windows.Controls.TreeViewItem();
            //    j.Header = OsnastkaDirect.Data.TreeViewDraft;
            //    item.BringIntoView();
            //    //e.Handled = true;
            //}
            //{ System.Windows.Controls.TreeViewItem Header:OsnastkaDirect.Data.TreeViewDraft Items.Count: 6}
            //{System.Windows.Controls.TreeViewItem Header:OsnastkaDirect.Data.TreeViewDraft Items.Count:1}
        }
        private void TreeViewSelectedItemChanged(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            if (item != null)
            {
                item.BringIntoView();
                e.Handled = true;
            }

        }
    }
}

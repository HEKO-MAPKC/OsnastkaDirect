﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;

namespace OsnastkaDirect.Data
{
    public static class perTreeViewItemHelper
    {
        public static bool GetBringSelectedItemIntoView(TreeViewItem treeViewItem)
        {
            return (bool)treeViewItem.GetValue(BringSelectedItemIntoViewProperty);
        }

        public static void SetBringSelectedItemIntoView(TreeViewItem treeViewItem, bool value)
        {
            treeViewItem.SetValue(BringSelectedItemIntoViewProperty, value);
        }

        public static readonly DependencyProperty BringSelectedItemIntoViewProperty =
            DependencyProperty.RegisterAttached(
                "BringSelectedItemIntoView",
                typeof(bool),
                typeof(perTreeViewItemHelper),
                new UIPropertyMetadata(false, BringSelectedItemIntoViewChanged));

        private static void BringSelectedItemIntoViewChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (!(args.NewValue is bool))
                return;

            if (!(obj is TreeViewItem item))
                return;

            if ((bool)args.NewValue)
                item.Selected += OnTreeViewItemSelected;
            else
                item.Selected -= OnTreeViewItemSelected;
        }

        private static void OnTreeViewItemSelected(object sender, RoutedEventArgs e)
        {
            // prevent this event bubbling up to any parent nodes
            e.Handled = true;

            if (sender is TreeViewItem item)
            {
                // use DispatcherPriority.ApplicationIdle so this occurs after all operations related to tree item expansion
                //perDispatcherHelper.AddToQueue(() => item.BringIntoView(), DispatcherPriority.ApplicationIdle);
            }
        }

        public static bool GetBringExpandedChildrenIntoView(TreeViewItem treeViewItem)
        {
            return (bool)treeViewItem.GetValue(BringExpandedChildrenIntoViewProperty);
        }

        public static void SetBringExpandedChildrenIntoView(TreeViewItem treeViewItem, bool value)
        {
            treeViewItem.SetValue(BringExpandedChildrenIntoViewProperty, value);
        }

        public static readonly DependencyProperty BringExpandedChildrenIntoViewProperty =
            DependencyProperty.RegisterAttached(
                "BringExpandedChildrenIntoView",
                typeof(bool),
                typeof(perTreeViewItemHelper),
                new UIPropertyMetadata(false, BringExpandedChildrenIntoViewChanged));

        private static void BringExpandedChildrenIntoViewChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (!(args.NewValue is bool))
                return;

            if (!(obj is TreeViewItem item))
                return;

            if ((bool)args.NewValue)
                item.Expanded += OnTreeViewItemExpanded;
            else
                item.Expanded -= OnTreeViewItemExpanded;
        }

        private static void OnTreeViewItemExpanded(object sender, RoutedEventArgs e)
        {
            // prevent this event bubbling up to any parent nodes
            e.Handled = true;

            if (!(sender is TreeViewItem item))
                return;

            // use DispatcherPriority.ContextIdle for all actions related to tree item expansion
            // this ensures that all UI elements for any newly visible children are created before any selection operation

            // first bring the last child into view
            Action action = () =>
            {
                var lastChild = item.ItemContainerGenerator.ContainerFromIndex(item.Items.Count - 1) as TreeViewItem;
                lastChild?.BringIntoView();
            };

            //perDispatcherHelper.AddToQueue(action, DispatcherPriority.ContextIdle);

            // then bring the expanded item (back) into view
            action = () => { item.BringIntoView(); };

            //perDispatcherHelper.AddToQueue(action, DispatcherPriority.ContextIdle);
        }
    }
}

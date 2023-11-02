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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Metrology.EmbedResources.Controls
{
    /// <summary>
    /// Логика взаимодействия для PlaceholderBox.xaml
    /// </summary>
    public partial class PlaceholderBox : TextBox
    {

        public bool focused;
        private Grid grid;

        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register
                                                     ("Placeholder", typeof(string), typeof(PlaceholderBox)
                                                         , new FrameworkPropertyMetadata
                                                             ("",
                                                              FrameworkPropertyMetadataOptions.AffectsMeasure |
                                                              FrameworkPropertyMetadataOptions.AffectsRender |
                                                              FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                                                     );


        public static readonly DependencyProperty PlaceholderColorProperty = DependencyProperty.Register
                                                     ("PlaceholderColor", typeof(Brush), typeof(PlaceholderBox)
                                                         , new FrameworkPropertyMetadata
                                                             (Brushes.Gray,
                                                              FrameworkPropertyMetadataOptions.AffectsMeasure |
                                                              FrameworkPropertyMetadataOptions.AffectsRender |
                                                              FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                                                     );

        public static readonly DependencyProperty PlaceholderAlignmentProperty = DependencyProperty.Register
                                                     ("PlaceholderAlignment", typeof(TextAlignment), typeof(PlaceholderBox)
                                                         , new FrameworkPropertyMetadata
                                                             (TextAlignment.Left,
                                                              FrameworkPropertyMetadataOptions.AffectsMeasure |
                                                              FrameworkPropertyMetadataOptions.AffectsRender |
                                                              FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                                                     );
        public TextAlignment PlaceholderAlignment
        {
            get { return (TextAlignment)GetValue(PlaceholderAlignmentProperty); }
            set { SetValue(PlaceholderAlignmentProperty, value); }
        }
        public Brush PlaceholderColor
        {
            get { return (Brush)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public PlaceholderBox()
        {
            InitializeComponent();
            Loaded += PlaceholderBox_Loaded;

        }

        void PlaceholderBox_GotFocus(object sender, RoutedEventArgs e)
        {
            focused = true;
            ChangePlaceholderVisibility();
            if (TB.IsFocused)
            {
                TextBox Box = (TextBox)grid.Children[0];
                Box.Focus();
            }


        }
        void PlaceholderBox_LostFocus(object sender, RoutedEventArgs e)
        {
            focused = false;
            ChangePlaceholderVisibility();
        }
        void PlaceholderBox_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                grid = (Grid)VisualTreeHelper.GetChild(this, 0);
                TextBox Box = (TextBox)grid.Children[0];
                Box.GotFocus += PlaceholderBox_GotFocus;
                Box.LostFocus += PlaceholderBox_LostFocus;
                Box.TextChanged += (s, t) => ChangePlaceholderVisibility();
                ChangePlaceholderVisibility();
            }
            catch (ArgumentOutOfRangeException) { }

        }


        private void ChangePlaceholderVisibility()
        {
            TextBlock Block = (TextBlock)grid.Children[1];
            if (!string.IsNullOrWhiteSpace(Text))
            {
                Block.Visibility = Visibility.Collapsed;
            }
            else Block.Visibility = Visibility.Visible;
        }

    }
}

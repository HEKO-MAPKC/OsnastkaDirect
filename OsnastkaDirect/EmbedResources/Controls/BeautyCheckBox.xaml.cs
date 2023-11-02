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
    /// Логика взаимодействия для BeautyCheckBox.xaml
    /// </summary>
    public partial class BeautyCheckBox : UserControl
    {
         object findBasis;
        Brush StartStroke = new SolidColorBrush();

        public BeautyCheckBox()
        {
            InitializeComponent();

            Control.Loaded += new RoutedEventHandler(Control_Loaded);
            Switcher.Click += new RoutedEventHandler(Switcher_Click);
            Switcher.MouseEnter += new MouseEventHandler(Switcher_MouseEnter);
            Switcher.MouseLeave += new MouseEventHandler(Switcher_MouseLeave);
            Switcher.Checked += new RoutedEventHandler(Switcher_Checked);
            Switcher.Unchecked += new RoutedEventHandler(Switcher_Unchecked);
        }

        
        public static readonly DependencyProperty FocusStrokeProperty = DependencyProperty.Register
                                                     ("FocusStroke", typeof(Brush), typeof(BeautyCheckBox)
                                                         , new FrameworkPropertyMetadata
                                                             (new SolidColorBrush(Color.FromRgb(255,0,0)),
                                                              FrameworkPropertyMetadataOptions.AffectsMeasure |
                                                              FrameworkPropertyMetadataOptions.AffectsRender |
                                                              FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                                                     );
    
        public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register
                                                     ("Stroke", typeof(Brush), typeof(BeautyCheckBox)
                                                         , new FrameworkPropertyMetadata
                                                             (new SolidColorBrush(Color.FromRgb(95,95,95)),
                                                              FrameworkPropertyMetadataOptions.AffectsMeasure |
                                                              FrameworkPropertyMetadataOptions.AffectsRender |
                                                              FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                                                     );
     
        public static readonly DependencyProperty OffSliderColorProperty = DependencyProperty.Register
                                                     ("OffSliderColor", typeof(Brush), typeof(BeautyCheckBox)
                                                         , new FrameworkPropertyMetadata
                                                             (new SolidColorBrush(Color.FromRgb(95, 95, 95)),
                                                              FrameworkPropertyMetadataOptions.AffectsMeasure |
                                                              FrameworkPropertyMetadataOptions.AffectsRender |
                                                              FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                                                     );

        public static readonly DependencyProperty OffBackgroundProperty = DependencyProperty.Register
                                                             ("OffBackground", typeof(Brush), typeof(BeautyCheckBox)
                                                                 , new FrameworkPropertyMetadata
                                                                    (new SolidColorBrush(Color.FromRgb(240, 240, 240)),
                                                                      FrameworkPropertyMetadataOptions.AffectsMeasure |
                                                                      FrameworkPropertyMetadataOptions.AffectsRender |
                                                                      FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                                                             );

        public static readonly DependencyProperty OnSliderColorProperty = DependencyProperty.Register
                                                 ("OnSliderColor", typeof(Brush), typeof(BeautyCheckBox)
                                                     , new FrameworkPropertyMetadata
                                                         (Brushes.White,
                                                          FrameworkPropertyMetadataOptions.AffectsMeasure |
                                                          FrameworkPropertyMetadataOptions.AffectsRender |
                                                          FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                                                 );

        public static readonly DependencyProperty OnBackgroundProperty = DependencyProperty.Register
                                                     ("OnBackground", typeof(Brush), typeof(BeautyCheckBox)
                                                         , new FrameworkPropertyMetadata
                                                             (new SolidColorBrush(Color.FromRgb(0, 103, 192)),
                                                              FrameworkPropertyMetadataOptions.AffectsMeasure |
                                                              FrameworkPropertyMetadataOptions.AffectsRender |
                                                              FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                                                     );

        public static readonly DependencyProperty CheckLabelProperty = DependencyProperty.Register
                                                    ("CheckLabel", typeof(string), typeof(BeautyCheckBox)
                                                        , new FrameworkPropertyMetadata
                                                            ("On",
                                                             FrameworkPropertyMetadataOptions.AffectsMeasure |
                                                             FrameworkPropertyMetadataOptions.AffectsRender |
                                                             FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                                                    );

        public static readonly DependencyProperty UncheckLabelProperty = DependencyProperty.Register
                                                     ("UncheckLabel", typeof(string), typeof(BeautyCheckBox)
                                                         , new FrameworkPropertyMetadata
                                                             ("Off",
                                                              FrameworkPropertyMetadataOptions.AffectsMeasure |
                                                              FrameworkPropertyMetadataOptions.AffectsRender |
                                                              FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                                                     );

        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register
                                                     ("IsChecked", typeof(bool), typeof(BeautyCheckBox)
                                                         , new FrameworkPropertyMetadata
                                                             (false,
                                                              FrameworkPropertyMetadataOptions.AffectsMeasure |
                                                              FrameworkPropertyMetadataOptions.AffectsRender |
                                                              FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                                                     );
        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public Brush FocusStroke
        {
            get { return (Brush)GetValue(FocusStrokeProperty); }
            set { SetValue(FocusStrokeProperty, value); }
        }

        public Brush OffBackground
        {
            get { return (Brush)GetValue(OffBackgroundProperty); }
            set { SetValue(OffBackgroundProperty, value); }
        }

        public Brush OffSliderColor
        {
            get { return (Brush)GetValue(OffSliderColorProperty); }
            set { SetValue(OffSliderColorProperty, value); }
        }

        public Brush OnBackground
        {
            get { return (Brush)GetValue(OnBackgroundProperty); }
            set { SetValue(OnBackgroundProperty, value); }
        }

        public Brush OnSliderColor
        {
            get { return (Brush)GetValue(OnSliderColorProperty); }
            set { SetValue(OnSliderColorProperty, value); }
        }

        public string CheckLabel
        {
            get { return (string)GetValue(CheckLabelProperty); }
            set { SetValue(CheckLabelProperty, value); }
        }

        public string UncheckLabel
        {
            get { return (string)GetValue(UncheckLabelProperty); }
            set { SetValue(UncheckLabelProperty, value); }
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        void Control_Loaded(object sender, RoutedEventArgs e)
        {
            if (Switcher.IsChecked == true)
                Info.Text = CheckLabel;
            else Info.Text = UncheckLabel;

        }
        void Switcher_Click(object sender, RoutedEventArgs e)
        {
            if (Switcher.IsChecked == true)
                Info.Text = CheckLabel;
            else Info.Text = UncheckLabel;
        }

        void Switcher_MouseEnter(object sender, MouseEventArgs e)
        {
            findBasis = Switcher.Template.FindName("Basis", Switcher);

            Path child = findBasis as Path;
            StartStroke = child.Stroke;
            child.Stroke = FocusStroke;


        }
        void Switcher_MouseLeave(object sender, MouseEventArgs e)
        {
            findBasis = Switcher.Template.FindName("Basis", Switcher);

            Path child = findBasis as Path;
            child.Stroke = StartStroke;

        }
        void Switcher_Unchecked(object sender, RoutedEventArgs e)
        {
            Info.Text = UncheckLabel;
        }
        void Switcher_Checked(object sender, RoutedEventArgs e)
        {
            Info.Text = CheckLabel;
        }
    }
}

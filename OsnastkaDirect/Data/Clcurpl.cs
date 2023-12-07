using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
//using System.Net.Mail;
using Fox;
using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Globalization;
//using Microsoft.Office.Interop.Excel;

namespace OsnastkaDirect.Data
{
    class AgeToWeightFontConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Все проверки для краткости выкинул
            FontWeight fontWt;
            if (value != null)
            {
                switch (value.ToString())
                {
                    case "**":
                        fontWt = FontWeights.Bold;
                        break;
                    case "!!":
                        fontWt = FontWeights.Bold;
                        break;
                    case "":
                        fontWt = FontWeights.Normal;
                        break;

                    default:
                        fontWt = FontWeights.Normal;
                        break;
                }
            }
            else
                fontWt = FontWeights.Normal;
            return fontWt;
            //return (string)value == "**" ?
            //   (FontWeight) new FontWeights.Bold()
            //    :(FontWeight) new FontWeights.Normal;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FontWeight fontWt = (FontWeight)value;
            return fontWt.ToString();
        }
    }
    class AgeToFontColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Все проверки для краткости выкинул

            if (value != null)
            {
                switch (value.ToString())
                {
                    case "**":
                        return new SolidColorBrush(Colors.Red);

                    case "!!":
                        return new SolidColorBrush(Colors.Black);


                    default:
                        return new SolidColorBrush(Colors.Black);

                }
            }
            else
                return new SolidColorBrush(Colors.Black);

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
    public class gr_dost
    {
        public static Visibility b_vis;
        //static IEnumerable<string> GetGroupUsers(string groupName)
        //{
        //    using (var ctx = new PrincipalContext(ContextType.Domain))
        //    using (var groupPrincipal = GroupPrincipal.FindByIdentity(ctx, groupName))
        //    {
        //        if (groupPrincipal != null)
        //            return groupPrincipal.Members.Select(d => d.SamAccountName).Where(p => p == (SystemInformation.ComputerName) + "$").ToList();
        //        else
        //            return null;
        //    }
        //}
        public static bool ocon;
        public static bool gr_;
        
    }
    class AgeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Все проверки для краткости выкинул
            return (bool)value != true ?
                new SolidColorBrush(Colors.Orange)
                : new SolidColorBrush(Colors.White);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
    class DE
    {
      
        public static void ShowExeption(Exception ex, string metod, string dop)
        {
           
            CheckStartUp.WriteErr(ex, metod, dop);
            System.Windows.MessageBox.Show("Произошла ошибка,\n информация передана разработчику");
            //var btmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //var graph = Graphics.FromImage(btmp);
            //graph.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            //File.Delete(Path.GetTempPath() + @"scr.png");
            //btmp.Save(Path.GetTempPath() + @"scr.png");
            //string inex = "";
            //if (ex.InnerException != null)
            //    inex = " \n Внутренее исключение \n" + ex.InnerException.Message + "\n" + ex.InnerException.Source + "\n" + ex.InnerException.StackTrace;
            //string exex = ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + inex;
            //System.Windows.MessageBox.Show(exex, metod);
          
            //MailToClient.mailTO(exex+" "+dop, metod, Path.GetTempPath() + @"\scr.png", MailToClient._GetEmailAdress(MailToClient._autor()));
        }
        public static void ShowExeption(Exception ex, string metod)
        {
           
            CheckStartUp.WriteErr(ex, metod);
            System.Windows.MessageBox.Show("Произошла ошибка,\n информация передана разработчику");
            //var btmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //var graph = Graphics.FromImage(btmp);
            //graph.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            //File.Delete(Path.GetTempPath() + @"scr.png");
            //btmp.Save(Path.GetTempPath() + @"scr.png");
            //string inex = "";
            //if (ex.InnerException != null)
            //    inex = " \n Внутренее исключение \n" + ex.InnerException.Message + "\n" + ex.InnerException.Source + "\n" + ex.InnerException.StackTrace;
            //string exex = ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + inex;
            //System.Windows.MessageBox.Show(exex, metod);

            //MailToClient.mailTO(exex, metod, Path.GetTempPath() + @"\scr.png", MailToClient._GetEmailAdress(MailToClient._autor()));
        }
    }
    public class Clcurpl
    {
        public decimal zakaz { get; set; }
        public decimal nom { get; set; }
        public string name { get; set; }
        public decimal? mes { get; set; }
        public DateTime? data { get; set; }
        public decimal? draft { get; set; }
        public decimal? m_otgr { get; set; }
        public decimal? g_otgr { get; set; }
        public decimal? tip { get; set; }
        public decimal? nv { get; set; }
        public decimal? zp { get; set; }
        public decimal? mt { get; set; }
        public DateTime? dvippl { get; set; }
        public string zakaz_doc { get; set; }
        public decimal? zak_os { get; set; }
        public decimal? nom_os { get; set; }
        public DateTime? dtform { get; set; }
        public bool? setok { get; set; }
        public bool? nar { get; set; }
    }
    public class Clnarss
    {
        public decimal zakaz { get; set; }
        public decimal num { get; set; }
        public decimal koln { get; set; }
    }
    public class Cloutpromy
    {
        public decimal zakaz { get; set; }
        public decimal nom { get; set; }
        public decimal? posit { get; set; }
        public decimal? draft { get; set; }
        public decimal? quant { get; set; }
        public decimal? across { get; set; }
        public decimal? knk { get; set; }
        public decimal? ksi { get; set; }
        public decimal? spec { get; set; }
        public decimal? rung { get; set; }
        public decimal? summ { get; set; }
        public string path { get; set; }
        public decimal? km { get; set; }
        public decimal? norm { get; set; }
        public decimal? kz { get; set; }
        public DateTime? p_nm { get; set; }
        public DateTime? p_obm { get; set; }
        public DateTime? p_tr { get; set; }
        public DateTime? p_neo { get; set; }
        public decimal? mg_pl { get; set; }
        public DateTime? p_pec { get; set; }
        public DateTime? mg_vd { get; set; }
        public DateTime? mg_sp { get; set; }
        public decimal? imcom { get; set; }
        public decimal? nom_nar { get; set; }
        public DateTime? p_cex { get; set; }
        public decimal? ro { get; set; }
        public DateTime? d_dok { get; set; }
        public string blok { get; set; }
        public decimal? numr { get; set; }
        public decimal? numrod { get; set; }
        public string okvc { get; set; }
        public string nm { get; set; }
        public decimal? kp { get; set; }
        public string hm { get; set; }
        public string pl { get; set; }
        public string gst { get; set; }
        public string gsts { get; set; }
        public string fio { get; set; }
        public int? pid { get; set; }
        public int? cid { get; set; }
        public string ei { get; set; }
    }

    public class FileDBF
    {
        private OleDbConnection _connection = null;
         public string putFileName = @"h:\bas1\trud"; // сюда пишите ПОЛНЫЙ ПУТЬ к ПАПКЕ.
   //     private const string putFileName = @"h:\bas1\trud"; // сюда пишите ПОЛНЫЙ ПУТЬ к ПАПКЕ.

        public DataTable Execute(string command)
        {
            DataTable dt = null;
            if (_connection != null)
            {
                try
                {
                    _connection.Open();
                    dt = new DataTable();
                    System.Data.OleDb.OleDbCommand oCmd = _connection.CreateCommand();
                    oCmd.CommandText = command;
                    dt.Load(oCmd.ExecuteReader());
                    _connection.Close();
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message + e.StackTrace);
                }
            }
            return dt;
        }

        public DataTable GetAll(string dbpath)
        {
            return Execute("SELECT * FROM " + dbpath);
        }

        public FileDBF()
        {
        }
        public void  FileDBF_con()
        {
            this._connection = new System.Data.OleDb.OleDbConnection();
            _connection.ConnectionString = @"Provider=vfpoledb;Data Source=" + putFileName + "; " ;
//_connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + putFileName + "; Extended Properties=dBASE IV;"; ;
        }
    }

    public class ClTexn_op
    {
        public decimal okv { get; set; }
        public decimal oper { get; set; }
 public decimal n_rab { get; set; }
 public decimal nop { get; set; }
        public string tex1 { get; set; }
        public string tex2 { get; set; }
        public string tex3 { get; set; }

        public string osnast { get; set; }

        public string ucex { get; set; }



    }
    public class nar
    {
        public decimal zakaz { get; set; }
        public decimal num { get; set; }
        public decimal nz { get; set; }
        public decimal? prov { get; set; }
        public decimal? nop { get; set; }
        public string cex { get; set; }
        public string pass { get; set; }
        public decimal? del { get; set; }
        public decimal? kol { get; set; }
        public decimal? draft { get; set; }
        public decimal? oper { get; set; }
        public decimal nnar { get; set; }
        public DateTime? datav { get; set; }
        public decimal? br { get; set; }
        public decimal? tabn { get; set; }
        public decimal? rasv { get; set; }
        public DateTime? ds { get; set; }
        public decimal? km { get; set; }
        public decimal? norn { get; set; }
        public decimal? ed { get; set; }
        public decimal? rasrab { get; set; }
        public decimal? rm { get; set; }
        public decimal? numsm { get; set; }
        public string opera { get; set; }
        public string fio { get; set; }
        public string provs { get; set; }
        public string tip_ob { get; set; }
        public string nm_ob { get; set; }
        public DateTime? datat { get; set; }
        public DateTime? dfio { get; set; }
        public string hard_fio { get; set; }
    }
    public class ClNoM
    {

        public decimal? km { get; set; }
        public decimal? norm { get; set; }

        public decimal? nom_nar { get; set; }

        public string hm { get; set; }

    }
    public class ClNoT
    {
        public string cex { get; set; }

        public decimal? zax { get; set; }
        public decimal? draft { get; set; }
        public decimal? kz { get; set; }
        public decimal? nom_nar { get; set; }

        public string nm { get; set; }

    }
    public class ClNoObe
    {
        public decimal? numr { get; set; }
        public decimal? numrod { get; set; }
        public decimal? km { get; set; }
        public decimal? norm { get; set; }
        public decimal? nom_nar { get; set; }
        public string hm { get; set; }
        public decimal? draft { get; set; }
        public string path { get; set; }
        public string pl { get; set; }
        public decimal? across { get; set; }
        public string nm { get; set; }
        public string nmus { get; set; }
        public string gst { get; set; }
        public string gsts { get; set; }
        public string fio { get; set; }
        public string ei { get; set; }
    }
    public class Cluser
    {
        public string fio { get; set; }
        public string kod { get; set; }

    }
    public class ClSma
    {

        public decimal? km { get; set; }
        public decimal? norm { get; set; }
        public string hm { get; set; }
        public string pl { get; set; }
        public string gst { get; set; }
        public string gsts { get; set; }
        public string prt { get; set; }
    }
    public class ClNoiz
    {
        public decimal zakaz { get; set; }
        public decimal nom { get; set; }
        public decimal? draft { get; set; }
        public decimal? knk { get; set; }
        public string path { get; set; }
        public DateTime? p_obm { get; set; }
        public DateTime? p_pec { get; set; }
        public DateTime? mg_vd { get; set; }
        public decimal? nom_nar { get; set; }
        public string nm { get; set; }
        public decimal? imcom { get; set; }
    }
    public class ClNonar
    {
        public decimal zakaz { get; set; }
        public decimal nom { get; set; }
        public decimal? draft { get; set; }
        public decimal? knk { get; set; }
        public string path { get; set; }
        public DateTime? p_obm { get; set; }
        public DateTime? p_nm { get; set; }
        public DateTime? p_tr { get; set; }
        public decimal? nom_nar { get; set; }
        public string nm { get; set; }
        public decimal? km { get; set; }
        public decimal? norm { get; set; }
        public decimal? kz { get; set; }
    }
    public class spisok
    {

        public string cex { get; set; }


    }
    public class ToolkPoint
    {
        public decimal? Value { get; set; }
        public string etap { get; set; }

    }
    public class ClBn1
    {
        public decimal id { get; set; }
        public decimal zak { get; set; }
        public decimal nom { get; set; }
        public decimal? km { get; set; }
        public string cexp { get; set; }
        public string name { get; set; }
        public DateTime? srok { get; set; }
        public string ei { get; set; }
        public DateTime? obes { get; set; }
        public decimal? cena { get; set; }
        public decimal? norm { get; set; }
        public decimal? kol { get; set; }
        public decimal? summ { get; set; }

    }
    public class protd
    {
        public decimal zakaz { get; set; }
        public decimal nom { get; set; }
        public string cex { get; set; }
        public decimal? km { get; set; }
        public decimal? nnar { get; set; }
        public decimal? kol { get; set; }
        public DateTime? datasz { get; set; }
        public DateTime? d_opl { get; set; }
        public DateTime? dzap { get; set; }
        public DateTime? dtov { get; set; }
        public DateTime? datasol { get; set; }
        public DateTime? d_obm { get; set; }
        public string prim1 { get; set; }
        public string name { get; set; }
        public string pr { get; set; }

    }
    public class anz
    {
        public decimal zakaz { get; set; }
        public decimal nom { get; set; }
        public decimal? nom_nar { get; set; }
        public decimal? kz { get; set; }
        public DateTime? p_m { get; set; }
        public DateTime? p_obm { get; set; }
        public DateTime? p_tr { get; set; }
        public DateTime? p_pec { get; set; }
        public DateTime? mg_sp { get; set; }

    }
    public class anzi
    {
        public decimal zakaz { get; set; }
        public decimal nom { get; set; }
        public string name { get; set; }
        public int? kz { get; set; }
        public int? p_m { get; set; }

        public int? p_obm { get; set; }
        public decimal? rp_obm { get; set; }
        public int? np_obm { get; set; }
        public decimal? rnp_obm { get; set; }
        public int? p_pec { get; set; }
        public decimal? rp_pec { get; set; }
        public int? np_pec { get; set; }
        public decimal? rnp_pec { get; set; }
        public int? mg_sp { get; set; }
        public decimal? rmg_sp { get; set; }
        public int? nmg_sp { get; set; }
        public decimal? rnmg_sp { get; set; }
        public DateTime? dtpl { get; set; }

    }
        

    
    public class rpathdim
    {
        public string mpath { get; set; }
        public decimal? mzax { get; set; }
        public int? msbor { get; set; }
    }
    public class Cldr
    {
        public decimal? draft { get; set; }
    }
    public class modProt : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DateTime? ldatasz;
        public DateTime? ld_opl;

        public decimal zakaz { get; set; }
        public decimal nom { get; set; }
        public string cex { get; set; }
        public decimal nnar { get; set; }
        public decimal? kol { get; set; }
        public DateTime? datasz
        {
            get { return ldatasz; }
            set
            {
                ldatasz = value;
                OnPropertyChanged("datasz");
            }
        }
        public DateTime? d_opl
        {
            get { return ld_opl; }
            set
            {
                ld_opl = value;
                OnPropertyChanged("d_opl");
            }
        }

        public DateTime? dzap { get; set; }
        public DateTime? dtov { get; set; }
        public DateTime? datasol { get; set; }
        public string hm { get; set; }
        public DateTime? d_obm { get; set; }
        public decimal? be { get; set; }
        public DateTime? d_zakaz { get; set; }
        public decimal? bl { get; set; }
        public decimal? g_otgr { get; set; }
        public string pr { get; set; }
        public string pl { get; set; }
        public string prim1 { get; set; }
        public decimal km { get; set; }
        public string name { get; set; }
        /// <summary>
        /// При изменении свойства
        /// </summary>
        /// <param name="_propertyName"></param>
        protected void OnPropertyChanged(string _propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(_propertyName));
        }
    }
    public class TreeViewLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TreeViewItem item = (TreeViewItem)value;
            ItemsControl ic = ItemsControl.ItemsControlFromItemContainer(item);
            return ic.ItemContainerGenerator.IndexFromContainer(item) == ic.Items.Count - 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return false;
        }
    }
    public class DataM : INotifyPropertyChanged
    {
        public string Nam { get; set; }
        string _pth;
        public string pth
        {
            get { return _pth; }
            set
            {
                _pth = value;
                OnPropertyChanged("pth");
            }
        }
        public ObservableCollection<DataM> Items { get; set; }
        string _pColor;
        
        public string pColor
        {
            get { return _pColor; }
            set
            {
                _pColor = value;
                OnPropertyChanged("pColor");
            }
        }
        string _pBColor;

        public string pBColor
        {
            get { return _pBColor; }
            set
            {
                _pBColor = value;
                OnPropertyChanged("pBColor");
            }
        }
        Boolean _isExpanded;
        public Boolean IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;
                OnPropertyChanged("IsExpanded");
            }
        }
        Boolean _isSelected;
        public Boolean IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string _propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(_propertyName));
        }
    }
    public class BringSelectedItemIntoViewBehavior
    {
        public static readonly DependencyProperty IsBringSelectedIntoViewProperty = DependencyProperty.RegisterAttached(
            "IsBringSelectedIntoView", typeof(bool), typeof(BringSelectedItemIntoViewBehavior), new PropertyMetadata(default(bool), PropertyChangedCallback));

        public static void SetIsBringSelectedIntoView(DependencyObject element, bool value)
        {
            element.SetValue(IsBringSelectedIntoViewProperty, value);
        }

        public static bool GetIsBringSelectedIntoView(DependencyObject element)
        {
            return (bool)element.GetValue(IsBringSelectedIntoViewProperty);
        }

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var treeViewItem = dependencyObject as TreeViewItem;
            if (treeViewItem == null)
            {
                return;
            }

            if (!((bool)dependencyPropertyChangedEventArgs.OldValue) &&
                ((bool)dependencyPropertyChangedEventArgs.NewValue))
            {
                treeViewItem.Unloaded += TreeViewItemOnUnloaded;
                treeViewItem.Selected += TreeViewItemOnSelected;
            }
        }

        private static void TreeViewItemOnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var treeViewItem = sender as TreeViewItem;
            if (treeViewItem == null)
            {
                return;
            }

            treeViewItem.Unloaded -= TreeViewItemOnUnloaded;
            treeViewItem.Selected -= TreeViewItemOnSelected;
        }

        private static void TreeViewItemOnSelected(object sender, RoutedEventArgs routedEventArgs)
        {
            var treeViewItem = sender as TreeViewItem;
            treeViewItem.BringIntoView();
        }
    }
}

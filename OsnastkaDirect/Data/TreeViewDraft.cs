using Fluent.Localization.Languages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OsnastkaDirect.Data
{
    public class TreeViewDraft
    {
        public TreeViewDraft()
        {
            children = new ObservableCollection<TreeViewDraft>();
            draftNameTree = draft.ToString() + " " + draftName;
        }
        public TreeViewDraft(decimal? _dr, string _st)
        {
            draft = _dr;
            draftName = _st;
            children = new ObservableCollection<TreeViewDraft>();
            draftNameTree = _dr.ToString() + " " + draftName;
        }
        public TreeViewDraft(decimal? _dr, string _st,ObservableCollection<TreeViewDraft> _list)
        {
            draft = _dr;
            draftName = _st;
            children = _list;
            draftNameTree = _dr.ToString() + " " + draftName;
        }
        public decimal? draft { get; set; }
        public decimal? draftAcross { get; set; }
        public string draftName { get; set; }
        public string draftNameTree { get; set; }
        //private string draftNm;
        //public string draftNameTree { 
        //    get 
        //    {
        //        if (draftNm == null)
        //            draftNm = draft.ToString() + " " + draftName;
        //        return draftNm;
        //    }
        //    set 
        //    {
        //        draftNm = value;
        //    } 
        //}
        //public string draftNameNotDraft { get; set; }
        public ObservableCollection<TreeViewDraft> children { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is TreeViewDraft person) return draft == person.draft;
            return false;
        }

        public override int GetHashCode() => draft.GetHashCode();
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
}

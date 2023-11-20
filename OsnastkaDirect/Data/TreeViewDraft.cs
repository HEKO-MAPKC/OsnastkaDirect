using Fluent.Localization.Languages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }
        public TreeViewDraft(decimal? _dr, string _st)
        {
            draft = _dr;
            draftName = _st;
            children = new ObservableCollection<TreeViewDraft>();
        }
        public TreeViewDraft(decimal? _dr, string _st,ObservableCollection<TreeViewDraft> _list)
        {
            draft = _dr;
            draftName = _st;
            children = _list;
        }
        public decimal? draft { get; set; }
        public string draftName { get; set; }
        public ObservableCollection<TreeViewDraft> children { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is TreeViewDraft person) return draft == person.draft;
            return false;
        }
        public override int GetHashCode() => draft.GetHashCode();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Objects.SqlClient;
using System.IO;
using System.Linq;
//
using Fox;
using OsnastkaDirect.Data;
using out_dll;
//
namespace OsnastkaDirect.Models
{
    /// <summary>
    /// Класс mOpenCompoundProduct (Model)
    /// </summary>
    class mOpenCompoundProduct : MBase
    {
        #region Переменные

            /// <summary>
            /// Переменная для работы с базой данных
            /// </summary>
            public FOXEntities db;
        //
        // Переменная для свойства
        //
        //тип name;

        #endregion

        #region Свойства

        // 
        // Свойство
        //
        //public тип pName
        //{
        //    get { return name; }
        //    set
        //    {
        //        name = value;
        //        OnPropertyChanged("pName");
        //    }
        //}    

        List<Ocomplect> ListOcomplect;
        public List<Ocomplect> pListOcomplect
        {
            get { return ListOcomplect; }
            set
            {
                if (ListOcomplect != value)
                {
                    ListOcomplect = value;
                    OnPropertyChanged("pListOcomplect");
                }
            }
        }
        List<TreeViewDraft> ListDraft;
        public List<TreeViewDraft> pListDraft
        {
            get { return ListDraft; }
            set
            {
                if (ListDraft != value)
                {
                    ListDraft = value;
                    OnPropertyChanged("pListDraft");
                }
            }
        }

        ObservableCollection<TreeViewDraft> ListDraftOsn;
        public ObservableCollection<TreeViewDraft> pListDraftOsn
        {
            get { return ListDraftOsn; }
            set
            {
                if (ListDraftOsn != value)
                {
                    ListDraftOsn = value;
                    OnPropertyChanged("pListDraftOsn");
                }
            }
        }

        ObservableCollection<Osnsv> ListDraftPiece;
        public ObservableCollection<Osnsv> pListDraftPiece
        {
            get { return ListDraftPiece; }
            set
            {
                if (ListDraftPiece != value)
                {
                    ListDraftPiece = value;
                    OnPropertyChanged("pListDraftPiece");
                }
            }
        }

        TreeViewDraft SelDraft;
        public TreeViewDraft pSelDraft
        {
            get { return SelDraft; }
            set
            {
                if (SelDraft != value)
                {
                    SelDraft = value;
                    OnPropertyChanged("pSelDraft");
                }
            }
        }

        TreeViewDraft SelDraftOsn;
        public TreeViewDraft pSelDraftOsn
        {
            get { return SelDraftOsn; }
            set
            {
                if (SelDraftOsn != value)
                {
                    SelDraftOsn = value;
                    OnPropertyChanged("pSelDraftOsn");
                }
            }
        }

        Osnsv SelDraftPiece;
        public Osnsv pSelDraftPiece
        {
            get { return SelDraftPiece; }
            set
            {
                if (SelDraftPiece != value)
                {
                    SelDraftPiece = value;
                    OnPropertyChanged("pSelDraftPiece");
                }
            }
        }
        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public mOpenCompoundProduct()
        {
            db = VMLocator.VMs["Main"][VMLocator.mainKey].model.db;
            //
            // Инициализация свойств
            // pName = значение;
            LoadOsnsv();
        }
        public void LoadOsnsv()
        {
            var _list = (from i in db.complect
                         join dbNameFull in db.FullDraftNameList
                             on i.what equals dbNameFull.Draft into gfFull
                         from listDseDraft in gfFull.DefaultIfEmpty()

                         join dbNameSh in db.FullDraftNameList.Where(i => i.IsShortDraft)
                             on (int)(i.what / 1000) equals dbNameSh.Draft into gfSh
                         from listDseDraftSh in gfSh.DefaultIfEmpty()
                         let draftName = listDseDraft.DraftName != null ? listDseDraft.DraftName : listDseDraftSh.DraftName != null ? listDseDraftSh.DraftName : ""
                         select new TreeViewDraft
                          {
                              draft = i.what,
                              draftName = draftName,
                              draftAcross = i.kuda
                          }).ToList();
            pListDraft = _list.Distinct().OrderBy(i => i.draft).ToList();
        }
        public void LoadListDraftOsn()
        {
            pListDraftOsn = new ObservableCollection<TreeViewDraft>((from i in db.complect.Where(j => j.kuda == pSelDraft.draft && j.what != pSelDraft.draft)

                          join db4 in db.FullDraftNameList
                            on i.what equals db4.Draft into gf4
                          from listDseDraft in gf4.DefaultIfEmpty()

                          join db5 in db.FullDraftNameList.Where(i => i.IsShortDraft)
                            on (int)(i.what/1000) equals db5.Draft into gf5
                          from listDseDraftSh in gf5.DefaultIfEmpty()

                          let draftName = listDseDraft.DraftName != null ? listDseDraft.DraftName : listDseDraftSh.DraftName!=null ? listDseDraftSh.DraftName : ""
                             select new TreeViewDraft
                             {
                                 draft = i.what,
                                 draftName = SqlFunctions.StringConvert((double?)i.what,14,2) + " " + draftName,
                                 draftAcross = i.kuda
                             }).ToList());
            for (int i = 0; i < pListDraftOsn.Count; i++)
            {
                if (pListDraftOsn[i].draft != pListDraftOsn[i].draftAcross)
                {
                    var _list = LoadListDraftOsnRec(pListDraftOsn[i].draft, pListDraftOsn[i].children);
                    for (int j = 0; j < _list.Count; j++)
                    {
                        pListDraftOsn[i].children.Add(new TreeViewDraft(_list[j].draft, _list[j].draftName, _list[j].children));
                    }
                }
            }
        }
        public ObservableCollection<TreeViewDraft> LoadListDraftOsnRec(decimal? _draft, ObservableCollection<TreeViewDraft> _children)
        {
            _children = new ObservableCollection<TreeViewDraft>((from i in db.complect.Where(j => j.kuda == _draft)

                          join db4 in db.FullDraftNameList
                            on i.what equals db4.Draft into gf4
                          from listDseDraft in gf4.DefaultIfEmpty()

                          join db5 in db.FullDraftNameList.Where(i => i.IsShortDraft)
                            on (int)(i.what/1000) equals db5.Draft into gf5
                          from listDseDraftSh in gf5.DefaultIfEmpty()

                          let draftName = listDseDraft.DraftName != null ? listDseDraft.DraftName : listDseDraftSh.DraftName!=null ? listDseDraftSh.DraftName : ""
                             select new TreeViewDraft
                             {
                                 draft = i.what,
                                 draftName = SqlFunctions.StringConvert((double?)i.what, 14, 2) + " " + draftName,
                                 draftAcross = i.kuda
                             }).ToList());
            for (int i = 0; i < _children.Count; i++)
            {
                if (_children[i].draft != _children[i].draftAcross)
                {
                    var _list = LoadListDraftOsnRec(_children[i].draft, _children[i].children);
                    for (int j = 0; j < _list.Count; j++)
                    {
                        _children[i].children.Add(new TreeViewDraft(_list[j].draft, _list[j].draftName, _list[j].children));
                    }
                }
            }
            return _children;
        }
        public void LoadListDraftPiece()
        {
            pListDraftPiece = new ObservableCollection<Osnsv>((from i in db.osnsv.Where(j => j.draft == pSelDraftOsn.draft)

                               join db4 in db.FullDraftNameList
                                 on i.draftosn equals db4.Draft into gf4
                               from listDseDraft in gf4.DefaultIfEmpty()

                               join db5 in db.FullDraftNameList.Where(i => i.IsShortDraft)
                                 on (int)(i.draftosn / 1000) equals db5.Draft into gf5
                               from listDseDraftSh in gf5.DefaultIfEmpty()

                               let draftName = listDseDraft.DraftName != null ? listDseDraft.DraftName : listDseDraftSh.DraftName != null ? listDseDraftSh.DraftName : ""
                               select new Osnsv
                               {
                                   draftPiece = i.draftosn,
                                   draftPieceName = i.naimosn,
                               }).ToList());
        }
        #endregion
    }
}


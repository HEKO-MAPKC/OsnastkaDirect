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
//
namespace OsnastkaDirect.Models
{
    /// <summary>
    /// Класс mOpenFinOrder (Model)
    /// </summary>
    class mOpenFinOrder : MBase
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


        ObservableCollection<TreeViewDraft> ListDraftOutpro;
        public ObservableCollection<TreeViewDraft> pListDraftOutpro
        {
            get { return ListDraftOutpro; }
            set
            {
                if (ListDraftOutpro != value)
                {
                    ListDraftOutpro = value;
                    OnPropertyChanged("pListDraftOutpro");
                }
            }
        }

        TreeViewDraft SelDraftOutpro;
        public TreeViewDraft pSelDraftOutpro
        {
            get { return SelDraftOutpro; }
            set
            {
                if (SelDraftOutpro != value)
                {
                    SelDraftOutpro = value;
                    OnPropertyChanged("pSelDraftOutpro");
                }
            }
        }

        ObservableCollection<OrderPlgod> ListOrder;
        public ObservableCollection<OrderPlgod> pListOrder
        {
            get { return ListOrder; }
            set
            {
                if (ListOrder != value)
                {
                    ListOrder = value;
                    OnPropertyChanged("pListOrder");
                }
            }
        }

        OrderPlgod SelOrder;
        public OrderPlgod pSelOrder
        {
            get { return SelOrder; }
            set
            {
                if (SelOrder != value)
                {
                    SelOrder = value;
                    OnPropertyChanged("pSelOrder");
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

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public mOpenFinOrder()
        {
            db = VMLocator.VMs["Main"][VMLocator.mainKey].model.db;
            //
            // Инициализация свойств
            // pName = значение;
            LoadOrder();
        }
        public void LoadOrder()
        {
            var _list = (from i in db.pl_god
                         join db4 in db.FullDraftNameList
                            on i.draft equals db4.Draft into gf4
                         from listDseDraft in gf4.DefaultIfEmpty()

                         join db5 in db.FullDraftNameList.Where(i => i.IsShortDraft)
                           on (int)(i.draft / 1000) equals db5.Draft into gf5
                         from listDseDraftSh in gf5.DefaultIfEmpty()

                         let draftName = listDseDraft.DraftName != null ? listDseDraft.DraftName : listDseDraftSh.DraftName != null ? listDseDraftSh.DraftName : ""
                         select new OrderPlgod
                         {
                             order = i.zakaz,
                             number = i.nom,
                             draftName = draftName,
                             draft = i.draft
                         }).ToList();
            pListOrder = new ObservableCollection<OrderPlgod>(_list);
        }
        public void LoadListDraftOsn()
        {
            pListDraftOutpro = new ObservableCollection<TreeViewDraft>((from i in db.outpro.Where(j => j.zakaz == pSelOrder.order && j.nom == pSelOrder.number && j.rung == 1)

                                                                     join db4 in db.FullDraftNameList
                                                                       on i.draft equals db4.Draft into gf4
                                                                     from listDseDraft in gf4.DefaultIfEmpty()

                                                                     join db5 in db.FullDraftNameList.Where(i => i.IsShortDraft)
                                                                       on (int)(i.draft / 1000) equals db5.Draft into gf5
                                                                     from listDseDraftSh in gf5.DefaultIfEmpty()

                                                                     let draftName = listDseDraft.DraftName != null ? listDseDraft.DraftName : listDseDraftSh.DraftName != null ? listDseDraftSh.DraftName : ""
                                                                     select new TreeViewDraft
                                                                     {
                                                                         draft = i.draft,
                                                                         draftName = SqlFunctions.StringConvert((double?)i.draft, 14, 2) + " " + draftName,
                                                                         draftAcross = i.across
                                                                     }).ToList());
            for (int i = 0; i < pListDraftOutpro.Count; i++)
            {
                if (pListDraftOutpro[i].draft != pListDraftOutpro[i].draftAcross)
                {
                    var lol = LoadListDraftOsnRec(pListDraftOutpro[i].draft, pListDraftOutpro[i].children);
                    for (int j = 0; j < lol.Count; j++)
                    {
                        pListDraftOutpro[i].children.Add(new TreeViewDraft(lol[j].draft, lol[j].draftName, lol[j].children));
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
                                                                   on (int)(i.what / 1000) equals db5.Draft into gf5
                                                                 from listDseDraftSh in gf5.DefaultIfEmpty()

                                                                 let draftName = listDseDraft.DraftName != null ? listDseDraft.DraftName : listDseDraftSh.DraftName != null ? listDseDraftSh.DraftName : ""
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
            pListDraftPiece = new ObservableCollection<Osnsv>((from i in db.osnsv.Where(j => j.draft == pSelDraftOutpro.draft)

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


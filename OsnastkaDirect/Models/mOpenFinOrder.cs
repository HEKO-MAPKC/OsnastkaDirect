using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Objects.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
//
using Fox;
using OsnastkaDirect.Data;
using OsnastkaDirect.ViewModels;
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
        public List<vDraftNameList> DraftNameList;
        public vmMain WindowMain;
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
        string OrderSearch;
        public string pOrderSearch
        {
            get { return OrderSearch; }
            set
            {
                if (OrderSearch != value)
                {
                    OrderSearch = value.Replace('+', ' ');
                    OnPropertyChanged("pOrderSearch");
                }
            }
        }

        string DraftSearch;
        public string pDraftSearch
        {
            get { return DraftSearch; }
            set
            {
                if (DraftSearch != value)
                {
                    DraftSearch = value;
                    OnPropertyChanged("pDraftSearch");
                }
            }
        }
        string OsnastSearch;
        public string pOsnastSearch
        {
            get { return OsnastSearch; }
            set
            {
                if (OsnastSearch != value)
                {
                    OsnastSearch = value;
                    OnPropertyChanged("pOsnastSearch");
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
            DraftNameList = db.vDraftNameList.ToList();
            //
            // Инициализация свойств
            // pName = значение;
            LoadOrder();
        }
        public void LoadOrder()
        {
            var _list = (from i in db.pl_god
                         select new OrderPlgod
                         {
                             order = i.zakaz,
                             number = i.nom,
                             draftName = i.name,
                             draft = i.draft
                         }).ToList();
            pListOrder = new ObservableCollection<OrderPlgod>(_list);
        }
        public void LoadListDraftOsn()
        {
            pListDraftOutpro = new ObservableCollection<TreeViewDraft>((from i in db.outpro.Where(j => j.zakaz == pSelOrder.order && j.nom == pSelOrder.number && j.rung == 1 && j.draft != 0)

                                                                            //join dbNameFull in db.vDraftNameList
                                                                            //on i.draft equals dbNameFull.Draft into gfFull
                                                                            //from listDseDraft in gfFull.DefaultIfEmpty()
                                                                            //let draftName = listDseDraft.Name
                                                                        orderby i.draft
                                                                        select new TreeViewDraft
                                                                     {
                                                                         draft = i.draft,
                                                                         //draftName = /*SqlFunctions.StringConvert((double?)i.draft, 14, 2) + " " +*/ draftName,
                                                                         //draftNameTree = SqlFunctions.StringConvert((double?)i.draft, 14, 2) + " " + draftName,
                                                                         draftAcross = i.across
                                                                     }).ToList());
            foreach (var item in pListDraftOutpro)
            {
                item.draftName = DraftNameList.FirstOrDefault(i => i.Draft == item.draft).Name;
                item.draftNameTree = item.draft.ToString() + " " + item.draftName;
            }
            for (int i = 0; i < pListDraftOutpro.Count; i++)
            {
                if (pListDraftOutpro[i].draft != pListDraftOutpro[i].draftAcross)
                {
                    var _list = LoadListDraftOsnRec(pListDraftOutpro[i].draft, pListDraftOutpro[i].children);
                    for (int j = 0; j < _list.Count; j++)
                    {
                        pListDraftOutpro[i].children.Add(new TreeViewDraft(_list[j].draft, _list[j].draftName, _list[j].children));
                    }
                }
            }
        }
        public ObservableCollection<TreeViewDraft> LoadListDraftOsnRec(decimal? _draft, ObservableCollection<TreeViewDraft> _children)
        {
            _children = new ObservableCollection<TreeViewDraft>((from i in db.vComplectWithNames.Where(j => j.across == _draft && j.draft != _draft)

                                                                     //join dbNameFull in db.vDraftNameList
                                                                     //   on i.what equals dbNameFull.Draft into gfFull
                                                                     //from listDseDraft in gfFull.DefaultIfEmpty()
                                                                     //let draftName = listDseDraft.Name
                                                                 orderby i.draft
                                                                 select new TreeViewDraft
                                                                 {
                                                                     draft = i.draft,
                                                                     draftAcross = i.across,
                                                                     draftName = i.draftName,
                                                                 }).ToList());
            //foreach (var item in _children)
            //{
            //    item.draftName = DraftNameList.FirstOrDefault(i => i.Draft == item.draft).Name;//db.vDraftNameList.FirstOrDefault(i => i.Draft == item.draft).Name;
            //}
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
            //pListDraftPiece = new ObservableCollection<Osnsv>((from i in db.vResPart.Where(j => j.Draft == pSelDraftOutpro.draft)

            //                                                   //join dbNameFull in db.vDraftNameList
            //                                                   //on i.draftosn equals dbNameFull.Draft into gfFull
            //                                                   //from listDseDraft in gfFull.DefaultIfEmpty()
            //                                                   //let draftName = listDseDraft.Name

            //                                                   select new Osnsv
            //                                                   {
            //                                                       draftPiece = i.Osnast,
            //                                                       draftPieceName = i.OsnastName,
            //                                                   }).ToList());
            pSelDraftPiece = null;
            pListDraftPiece = new ObservableCollection<Osnsv>((from i in db.osnsv.Where(j => j.draft == pSelDraftOutpro.draft)

                                                               join dbNameFull in db.vDraftNameList
                                                               on i.draftosn equals dbNameFull.Draft into gfFull
                                                               from listDseDraft in gfFull.DefaultIfEmpty()
                                                               let draftName = listDseDraft.Name

                                                               orderby i.draftosn
                                                               select new Osnsv
                                                               {
                                                                   draft = i.draftosn,
                                                                   draftName = i.naimosn,
                                                                   codeOperation = i.kodop,
                                                                   workPlace = i.rab_m
                                                               }).ToList());
        }
        public void FindOsnast()
        {
            OnPropertyChanged("pSelDraftOutpro");
            OnPropertyChanged("pListDraftOutpro");
        }
        #endregion
    }
}


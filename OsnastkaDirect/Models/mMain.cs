using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//
using Fox;
using OsnastkaDirect.Data;
using System.Collections.ObjectModel;
using ElsibServices.Components;
using ElsibServices;
using System.Data.Objects.SqlClient;
using System.Reflection;
using System.Windows;
using Fluent.Localization.Languages;
using System.Windows.Media.Media3D;
using System.Windows.Data;
using System.Security.Cryptography;
using System.Diagnostics;
//
namespace OsnastkaDirect.Models
{
    /// <summary>
    /// Класс mMain (Model)
    /// </summary>
    class mMain : MBase
    {
        #region Переменные

        /// <summary>
        /// Переменная для работы с базой данных
        /// </summary>
        public FOXEntities db;
        //
        //Переменные
        //
        //тип name;

        #endregion

        #region Свойства
        // Переменная для свойства
        //
        //тип name;
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
        ObservableCollection<Osn> ListOsnLoaded;
        public ObservableCollection<Osn> pListOsnLoaded
        {
            get { return ListOsnLoaded; }
            set
            {
                if (ListOsnLoaded != value)
                {
                    ListOsnLoaded = value;
                    OnPropertyChanged("pListOsnLoaded");
                }
            }
        }
        ObservableCollection<Osn> ListOsn;
        public ObservableCollection<Osn> pListOsn
        {
            get { return ListOsn; }
            set
            {
                if (ListOsn != value)
                {
                    ListOsn = value;
                    OnPropertyChanged("pListOsn");
                }
            }
        }
        Osn SelOsn;
        public Osn pSelOsn
        {
            get { return SelOsn; }
            set
            {
                if (SelOsn != value)
                {
                    SelOsn = value;
                    OnPropertyChanged("pSelOsn");
                }
            }
        }

        List<string> Filter = new List<string>{"Всё", "Неопределенно", "Возврат", "Направлено в КО", "Возврат из КО", "Аннулировано", "На рассмотрении"};
        public List<string> pFilter
        {
            get { return Filter; }
            set
            {
                if (Filter != value)
                {
                    Filter = value;
                    OnPropertyChanged("pFilter");
                }
            }
        }

        string SelFilter = "Всё";
        public string pSelFilter
        {
            get { return SelFilter; }
            set
            {
                if (SelFilter != value)
                {
                    SelFilter = value;
                    OnPropertyChanged("pSelFilter");
                }
            }
        }

        string SearchOsn;
        public string pSearchOsn
        {
            get { return SearchOsn; }
            set
            {
                if (SearchOsn != value)
                {
                    SearchOsn = value;
                    OnPropertyChanged("pSearchOsn");
                }
            }
        }

        string SelFilterSearch = "предварительный № т/з";
        public string pSelFilterSearch
        {
            get { return SelFilterSearch; }
            set
            {
                if (SelFilterSearch != value)
                {
                    SelFilterSearch = value;
                    OnPropertyChanged("pSelFilterSearch");
                }
            }
        }

        List<string> ListFilterSearch = new List<string> {"предварительный № т/з", "№ техзаказа", "исполнитель", "чертеж оснастки", "наименование оснастки","заказ номер" };
        public List<string> pListFilterSearch
        {
            get { return ListFilterSearch; }
            set
            {
                if (ListFilterSearch != value)
                {
                    ListFilterSearch = value;
                    OnPropertyChanged("pListFilterSearch");
                }
            }
        }

        DateTime? dateSearchAfter = null;
        public DateTime? pdateSearchAfter
        {
            get { return dateSearchAfter; }
            set
            {
                if (dateSearchAfter != value)
                {
                    dateSearchAfter = value;
                    OnPropertyChanged("pdateSearchAfter");
                }
            }
        }
        DateTime dateSearchBefore = DateTime.Now;
        public DateTime pdateSearchBefore
        {
            get { return dateSearchBefore; }
            set
            {
                if (dateSearchBefore != value)
                {
                    dateSearchBefore = value;
                    OnPropertyChanged("pdateSearchBefore");
                }
            }
        }

        string ReasonBack;
        public string pReasonBack
        {
            get { return ReasonBack; }
            set
            {
                if (ReasonBack != value)
                {
                    ReasonBack = value;
                    OnPropertyChanged("pReasonBack");
                }
            }
        }

        bool CreateTabOpen = true;
        public bool pCreateTabOpen
        {
            get { return CreateTabOpen; }
            set
            {
                if (CreateTabOpen != value)
                {
                    CreateTabOpen = value;
                    OnPropertyChanged("pCreateTabOpen");
                }
            }
        }

        bool ApproveTabOpen = false;
        public bool pApproveTabOpen
        {
            get { return ApproveTabOpen; }
            set
            {
                if (ApproveTabOpen != value)
                {
                    ApproveTabOpen = value;
                    OnPropertyChanged("pApproveTabOpen");
                }
            }
        }
        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public mMain()
        {
            db = new FOXEntities();

            db.Connection.Open();
            //db.CommandTimeout(600);
            db.CommandTimeout = 600;
            //
            // Инициализация свойств
            // pName = значение;
            LoadListOsn();
            //OnChangeSelFilter();
        }
        public void LoadListOsn()
        {
            pListOsn = null;
            pListOsnLoaded = null;
            var _var1 = (from i in db.proos
                              let _draftneed = i.draftzap==0 || i.draftzap == null ? i.draftosn : i.draftzap
                              join db1 in db.listdse on
                                   (int)(_draftneed / 1000) equals db1.DRAFT into gf1
                              from listDse in gf1.DefaultIfEmpty().Take(1)

                              join db2 in db.LIST_FR on
                                   _draftneed equals db2.WHAT into gf
                              from listFr in gf.DefaultIfEmpty().Take(1)

                         join db3 in db.olistdse on
                                   _draftneed equals db3.draft into gf2
                              from listDse2 in gf2.DefaultIfEmpty().Take(1)

                         join db5 in db.prodact on
                              _draftneed equals db5.draft into gf5
                         from listDse5 in gf5.DefaultIfEmpty().Take(1)

                         join db4 in db.m_cennik on
                              /*SqlFunctions.StringConvert(_draftneed, 14, 2)*/SqlFunctions.StringConvert(_draftneed, 14, 2) equals db4.ocen into gf4
                         from listDse4 in gf4.DefaultIfEmpty().Take(1)

                         join db6 in db.os_pro on
                                  /*SqlFunctions.Equals(i.zak_1,null) ? "0" :*/ i.os_pro_id equals db6.id /*!= null ? db6.zak_1 : "0"*/  into gf6
                              from list6 in gf6.DefaultIfEmpty().Take(1)
                                  //where i.zak_1 != null 

                         join db7 in db.prod on
                                 /*SqlFunctions.Equals(i.zak_1, null) ? "0" :*/ i.prod_id equals db7.id /*!= null ? db7.zak_1 : "0"*/ into gf7
                              from list7 in gf7.DefaultIfEmpty().Take(1)
                                  //where i.zak_1 != null

                         join db8 in db.pl_god on
                              new
                              {
                                  _pr1 = list7.zakaz.Value,
                                  _pr2 = list7.nom.Value
                              } equals new
                              {
                                  _pr1 = db8.zakaz,
                                  _pr2 = db8.nom
                                  
                              }
                              into gf8
                              from list8 in gf8.DefaultIfEmpty()
                                  //oborud
                                  //s_oper list6.rab_m
                                  // list6.oper,
                              join db9 in db.oborud on
                                  list6.rab_m equals db9.rab_m into gf9
                              from oborudlist in gf9.DefaultIfEmpty()
                              
                              join db10 in db.s_oper on
                                  list6.oper equals db10.code into gf10
                              from s_operlist in gf10.DefaultIfEmpty()

                              orderby i.tzakpred descending
                              select new Osn
                              {
                                  draftOsn = i.draftosn,
                                  workshop = i.cex.Trim(),
                                  nOrdPrev = i.tzakpred,
                                  nOrd = i.tzak,
                                  reason = i.prichina.Trim(),
                                  addition = i.dop,
                                  amount = i.kol,
                                  dateWho = i.dt_who,
                                  who = i.who.Trim(),
                                  returnRes = i.why_back.Trim(),
                                  draft = i.draft,
                                  draftRes = i.draftzap,
                                  storeroom = i.klad,
                                  //nameDraft = db.ExecuteFunction<string> ("GetDraftName"),

                                  nameGrid = i.draftzap == null || i.draftzap == 0 ?
                                  listDse2 != null ? listDse2.dse.Trim() :
                                  listDse != null ? listDse.DSE.Trim() :
                                  listFr != null ? listFr.NM.Trim() :
                                  listDse4 != null ? listDse4.hm.Trim() :
                                  listDse5 != null ? listDse5.name.Trim() :
                                  "" 
                                  :
                                  listDse2 != null ? listDse2.dse.Trim() :
                                  listDse != null ? listDse.DSE.Trim() :
                                  listFr != null ? listFr.NM.Trim() :
                                  listDse4 != null ? listDse4.hm.Trim() :
                                  listDse5 != null ? listDse5.name.Trim() :
                                  "",
                                  draftGrid = i.draftzap == null || i.draftzap == 0 ? i.draftosn : i.draftzap,
                                  //nameRes = SqlFunctions.Replicate("0", 14 - SqlFunctions.StringConvert(i.draftzap, 14, 2).Length) + SqlFunctions.StringConvert(i.draftzap, 14, 2),
                                  //nameOsn = listDse2 != null ? listDse2.dse.Trim() :
                                  //listDse != null ? listDse.DSE.Trim() :
                                  //listFr != null ? listFr.NM.Trim() :
                                  //listDse4 != null ? listDse4.hm.Trim() : "",
                                  //nameDraft = listDse != null ? listDse.DSE.Trim() :
                                  //       listDse2 != null ? listDse2.dse.Trim() :
                                  //       listFr != null ? listFr.NM.Trim() : "",
                                  usage = i.izd,
                                  dtSrok = i.srok,
                                  dtIzg = i.dt_izg,
                                  dtOk = i.dt_ok,
                                  atConst = i.toko,
                                  accepted = i.sog,
                                  returned = i.back,
                                  fioConst = i.fioko,

                                  ord700 = list7 != null ? list7.zakaz : 0,
                                  num700 = list7 != null ? list7.nom : 0,
                                  ordOsn = i.zakaz,
                                  numOsn = i.num,
                                  workPlace = list6.rab_m,
                                  operation = list6.oper,
                                  characterOrd = i.rem_izg,
                                  dateNeed = list6.s_vn_11,

                                  date700 = list8.data,
                                  annTab = list6.z_iz_16,
                                  datePlan = list6.s_iz_10,
                                  dateFact = list6.d_iz_13,

                                  workPlaceName = oborudlist.code.Trim() + " " + oborudlist.oborud1.Trim(),
                                  operationName = s_operlist.oper,

                                  zak_1 = i.zak_1,
                                  id_os_pro = i.os_pro_id.Value, //ПОМЕНЯТЬ ПОТОМ НА НЕ NULL
                                  id_prod = i.prod_id.Value,
                                  dateBoss = i.dt_back,
                                  boss = i.boss,
                              })/*.Distinct()*/.ToList();
            ////dtplan WITH os_pro.s_iz_10;
            //dtfact WITH os_pro.d_iz_13;
            //koop WITH os_pro.z_iz_16
            //pListOsnLoaded = _var1;
            pListOsnLoaded = new ObservableCollection<Osn>(_var1);
            //foreach (Osn _osn in pListOsnLoaded)
            //{
            //    //_osn.dateGrid = _osn.dateWho.Value.ToString("g");
            //    //if (_osn.date700!=null)
            //    //_osn.date700Grid = _osn.date700.Value.ToString("d");
            //    if (_osn.draftRes != 0)
            //    {
            //        _osn.draftGrid = _osn.draftRes;
            //        //_osn.nameGrid = _osn.nameRes;
            //    }
            //    else
            //    {
            //        _osn.draftGrid = _osn.draftOsn;
            //        //_osn.nameGrid = _osn.nameOsn;
            //        //_osn.nameGrid = _osn.nameRes;
            //    }
            //    //_osn.nameOsn = ElsibServices.DbService.SeekName(_osn.draftOsn.Value);
            //}
            //pListOsn = new ObservableCollection<Osn>(pListOsnLoaded);
            pListOsn = new ObservableCollection<Osn>(pListOsnLoaded);
            OnChangeSelFilter();
        }
        public void OnClickOsn()
        {
            //pSelOsn.nameOsn = ElsibServices.DbService.SeekName(pSelOsn.draftOsn.Value);
            //pSelOsn.nameRes = ElsibServices.DbService.SeekName(pSelOsn.draftRes.Value);
            //pSelOsn.nameDraft = ElsibServices.DbService.SeekName(pSelOsn.draft.Value);
        }

        public void OnChangeSelFilter()
        {
            SearchAllFilters();
            //if (pListOsn == null || pListOsnLoaded == null) return;
            //switch (pSelFilter)//"Всё", "Неопределенно", "Возврат", "Направлено в КО", "Возврат из КО", "Аннулировано", "На рассмотрении"};
            //{
            //    case "Всё": pListOsn = new ObservableCollection<Osn>(pListOsn);
            //        break;
            //    case "Утверждено":
            //        pListOsn = new ObservableCollection<Osn>(pListOsn.Where(i => i.accepted==true));
            //        break;
            //    case "Неопределенно":
            //        pListOsn = new ObservableCollection<Osn>(pListOsn.Where(i => i.accepted==false && i.returned==false && i.atConst == false && i.backFromConst==false && i.dtSrokIsNull==false && i.dtIzgIsNull==true));
            //        break;
            //    case "Возврат":
            //        pListOsn = new ObservableCollection<Osn>(pListOsn.Where(i =>  i.returned==true));
            //        break;
            //    case "Направлено в КО":
            //        pListOsn = new ObservableCollection<Osn>(pListOsn.Where(i => i.atConst==true));
            //        break;
            //    case "Возврат из КО":
            //        pListOsn = new ObservableCollection<Osn>(pListOsn.Where(i => i.backFromConst==true));
            //        break;
            //    case "Аннулировано":
            //        pListOsn = new ObservableCollection<Osn>(pListOsn.Where(i => i.dtSrokIsNull));
            //        break;
            //    case "На рассмотрении":
            //        pListOsn = new ObservableCollection<Osn>(pListOsn.Where(i => i.dtIzgIsNull==false));
            //        break;
            //    default:
            //        break;
            //}
        }
        public void FindMany(bool _add = false)
        {
            SearchAllFilters();
            //if (pSearchOsn == null || pListOsnLoaded == null) return;
            //var _gridSearch = _add ? pListOsn : pListOsnLoaded;
            //if (_add == false)
            //{
            //    pSelFilter = "Всё";
            //    pdateSearchBefore = DateTime.Now;
            //    pdateSearchAfter = null;
            //}
            //var _search = pSearchOsn.ToLower();
            //switch (pSelFilterSearch)//"предварительный № т/з", "№ техзаказа", "исполнитель", "чертеж оснастки", "наименование оснастки"
            //{
            //    case "предварительный № т/з":
            //        pListOsn = new ObservableCollection<Osn>(_gridSearch.Where(i => i.nOrdPrev.ToString().ToLower().StartsWith(_search)));
            //        break;
            //    case "№ техзаказа":
            //        pListOsn = new ObservableCollection<Osn>(_gridSearch.Where(i => i.nOrd.ToString().ToLower().StartsWith(_search)));
            //        break;
            //    case "исполнитель":
            //        pListOsn = new ObservableCollection<Osn>(_gridSearch.Where(i => i.who.ToLower().StartsWith(_search)));
            //        break;
            //    case "чертеж оснастки":
            //        pListOsn = new ObservableCollection<Osn>(_gridSearch.Where(i => i.draftGrid.ToString().ToLower().StartsWith(_search)));
            //        break;
            //    case "наименование оснастки":
            //        pListOsn = new ObservableCollection<Osn>(_gridSearch.Where(i => i.nameGrid.ToLower().StartsWith(_search)));
            //        break;
            //    case "заказ номер":
            //        pListOsn = new ObservableCollection<Osn>(_gridSearch.Where(i => string.Format("{0:####}{1:#}{2:###}", i.ord700, " ", i.num700)
            //                                    .StartsWith(_search, StringComparison.OrdinalIgnoreCase)));
            //        break;
            //    default:
            //        break;
            //}
        }
        public void ChangeDate()
        {
            SearchAllFilters();
            //pListOsn = new ObservableCollection<Osn>(pListOsnLoaded.Where(i => i.dateWho >= dateSearchAfter && i.dateWho <= dateSearchBefore.AddDays(1).Date));
        }
        public void SearchAllFilters()
        {
            if (pListOsn == null || pListOsnLoaded == null) return;
            var _list = pListOsnLoaded.Where(i => i.dateWho <= dateSearchBefore.AddDays(1).Date);
            if (dateSearchAfter!=null)
            _list = _list.Where(i => i.dateWho >= dateSearchAfter);
            switch (pSelFilter)//"Всё", "Неопределенно", "Возврат", "Направлено в КО", "Возврат из КО", "Аннулировано", "На рассмотрении"};
            {
                case "Всё":
                    //_list = _list;
                    break;
                case "Утверждено":
                    _list = (_list.Where(i => i.accepted == true));
                    break;
                case "Неопределенно":
                    _list = (_list.Where(i => i.accepted == false && i.returned == false && i.atConst == false && i.backFromConst == false && i.dtSrokIsNull == false && i.dtIzgIsNull == true));
                    break;
                case "Возврат":
                    _list = (_list.Where(i => i.returned == true));
                    break;
                case "Направлено в КО":
                    _list = (_list.Where(i => i.atConst == true));
                    break;
                case "Возврат из КО":
                    _list = (_list.Where(i => i.backFromConst == true));
                    break;
                case "Аннулировано":
                    _list = (_list.Where(i => i.dtSrokIsNull));
                    break;
                case "На рассмотрении":
                    _list = (_list.Where(i => i.dtIzgIsNull == false));
                    break;
                default:
                    break;
            }
            if (pSearchOsn == null || pSearchOsn == "")
            {
                pListOsn = new ObservableCollection<Osn>(_list);
            }
            else
            {
                var _search = pSearchOsn.ToLower();
                switch (pSelFilterSearch)//"предварительный № т/з", "№ техзаказа", "исполнитель", "чертеж оснастки", "наименование оснастки"
                {
                    case "предварительный № т/з":
                        pListOsn = new ObservableCollection<Osn>(_list.Where(i => i.nOrdPrev.ToString().ToLower().StartsWith(_search)));
                        break;
                    case "№ техзаказа":
                        pListOsn = new ObservableCollection<Osn>(_list.Where(i => i.nOrd.ToString().ToLower().StartsWith(_search)));
                        break;
                    case "исполнитель":
                        pListOsn = new ObservableCollection<Osn>(_list.Where(i => i.who.ToLower().StartsWith(_search)));
                        break;
                    case "чертеж оснастки":
                        pListOsn = new ObservableCollection<Osn>(_list.Where(i => i.draftGrid.ToString().ToLower().StartsWith(_search)));
                        break;
                    case "наименование оснастки":
                        pListOsn = new ObservableCollection<Osn>(_list.Where(i => i.nameGrid.ToLower().StartsWith(_search)));
                        break;
                    case "заказ номер":
                        pListOsn = new ObservableCollection<Osn>(_list.Where(i => string.Format("{0:####}{1:#}{2:###}", i.ord700, " ", i.num700)
                                                    .StartsWith(_search, StringComparison.OrdinalIgnoreCase)));
                        break;
                    default:
                        break;
                }
            }
        }
        public void SaveChanges()
        {
            db.SaveChanges();
            CollectionViewSource.GetDefaultView(pListOsn).Refresh();
            //CollectionViewSource.GetDefaultView(pListOsnLoaded).Refresh();
        }
        public void DisapproveOrd()
        {
            if (pSelOsn == null) return;
            var _os_pro = db.os_pro.FirstOrDefault(i => i.id == pSelOsn.id_os_pro);
            if (_os_pro != null)
            {
                //return;
                db.os_pro.DeleteObject(_os_pro);
            }
            var _osnLoad = db.proos.FirstOrDefault(i => i.tzakpred==pSelOsn.nOrdPrev);
            if (_osnLoad == null) return;
            pSelOsn.zak_1 = null; //ТУТ ВОПРОС НУЛЛ ИЛИ НЕТ
            pSelOsn.accepted = false;
            pSelOsn.boss = "";
            pSelOsn.dateBoss = null;
            pSelOsn.nOrd = 0;
            _osnLoad.zak_1 = null; //ТУТ ВОПРОС НУЛЛ ИЛИ НЕТ
            _osnLoad.sog = false;
            _osnLoad.boss = "";
            _osnLoad.dt_boss = null;
            _osnLoad.tzak = 0;
            SaveChanges();
            //LoadListOsn();

        }
        public void HoldOrd()
        {
            if (pSelOsn == null) return;
            var _osnLoad = db.proos.FirstOrDefault(i => i.tzakpred == pSelOsn.nOrdPrev);
            if (_osnLoad == null) return;
            if (pSelOsn.dtIzgIsNull)
            {
                pSelOsn.dtIzg = DateTime.Now;
                _osnLoad.dt_izg = DateTime.Now;
            }
            else
            {
                pSelOsn.dtIzg = null;
                _osnLoad.dt_izg = null;
            }
            OnChangeSelFilter();
            SaveChanges();
        }
        public void ReturnBackOrd()
        {
            var _osnLoad = db.proos.FirstOrDefault(i => i.tzakpred == pSelOsn.nOrdPrev);
            if (_osnLoad == null) return;
            _osnLoad.why_back = pSelOsn.returnRes;
            _osnLoad.dt_back = DateTime.Now;
            _osnLoad.back = true;

            pSelOsn.returned = true;
            SaveChanges();
        }
        public void AnnulOrd()
        {
            if (pSelOsn == null) return;
            if (db.os_pro.FirstOrDefault(i => i.id == pSelOsn.id_os_pro)!=null &&
                db.os_pro.FirstOrDefault(i => i.id == pSelOsn.id_os_pro).zak_nar>0)
            {
                MessageBox.Show("Аннулировать нельзя! Техзаказ в состоянии исполнения!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (pSelOsn.nOrd > 0)
            {
                if (true)//тут помощь нужна с ok ПОМОЩЬ, ПО ХОДУ ТИПА БОСС ИЛИ НЕТ
                {
                    if (MessageBox.Show("Техзаказ утвержден! Хотите аннулировать?",
                        "Внимание!",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        var _zayvka = db.zayvka.Where(i => i.tzak == pSelOsn.nOrd && i.dza==pSelOsn.getDate);
                        foreach (zayvka _za in _zayvka)
                        {
                            db.zayvka.DeleteObject(_za);
                        }
                        var _os_pro = db.os_pro.FirstOrDefault(i => i.id == pSelOsn.id_os_pro);
                        if (_os_pro != null)
                        {
                            db.os_pro.DeleteObject(_os_pro);
                        }
                        var _proos = db.proos.FirstOrDefault(i => i.tzakpred == pSelOsn.nOrdPrev);
                        if (_proos != null)
                        {
                            db.proos.DeleteObject(_proos);
                        }
                        pListOsn.Remove(pSelOsn);
                        SaveChanges();
                        //OnChangeSelFilter();
                        //LoadListOsn();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Удалить нельзя! Техзаказ утвержден!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else
            {
                var _proos = db.proos.FirstOrDefault(i => i.tzakpred == pSelOsn.nOrdPrev);
                if (_proos != null)
                {
                    db.proos.DeleteObject(_proos);
                    pListOsn.Remove(pSelOsn);
                }

                SaveChanges();
                //OnChangeSelFilter();
                //LoadListOsn();
            }
        }
        public void FinalApproveOrd()
        {
            if (pSelOsn == null) return;
            var _proos = db.proos.FirstOrDefault(i => i.tzakpred == pSelOsn.nOrdPrev);
            if (_proos != null)
            {
                _proos.dt_ok = DateTime.Now;
            }
            var _os_pro = db.os_pro.FirstOrDefault(i => i.id == pSelOsn.id_os_pro);
            if (_os_pro != null)
            {
                _os_pro.pr ="so";
            }
            var _zayvka = db.zayvka.FirstOrDefault(i => i.tzak == pSelOsn.nOrd && i.draftosn == pSelOsn.draftGrid);
            if (_zayvka != null)
            {
                _zayvka.sog2 = "*";
                _zayvka.nsog2 = "";
                _zayvka.dsog2 = DateTime.Now;
                _zayvka.imyts = pSelOsn.who;
                _zayvka.dop = pSelOsn.addition;
            }
            pSelOsn.dtOk = DateTime.Now;
            SaveChanges();
        }
        public void ApproveOrd()
        {
            if (pSelOsn == null) return;
            var _year = DateTime.Now.Year.ToString().Remove(0, 2);
            decimal _nOrdNew=0;
            //var _proosMAX = db.os_pro.FirstOrDefault(i => i.zak_1 == DateTime.Now.Year.ToString().Remove(0,2) + "-9999");
            var _proosMAX = db.os_pro.Where(i => i.zak_1.Substring(0,2) == _year).Max(j => j.zak_1.Remove(0,3)).ToDecimalOrDefault(-1);
            if (_proosMAX == -1) _nOrdNew = 7000;
            else _nOrdNew = _proosMAX+1;
            if (_nOrdNew == 9999) //до 9998 ?
            {
                MessageBox.Show("Максимум достигнут!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var _newZak1 = _year.ToString() + "-" + _nOrdNew.ToString();
            var _os_proNew = new os_pro
            {
                zak_1 = _newZak1,
                zakf_30 = pSelOsn.ordOsn.ToString()+"/"+pSelOsn.numOsn.ToString(),
                niz_3 = pSelOsn.usage,
                draft_4 = pSelOsn.draft,
                osn_6 = pSelOsn.draftGrid.ToString(),
                osna_7 = pSelOsn.nameGrid,
                z_p_17 = pSelOsn.workshop,
                d_otk_23 = DateTime.Now.Date,
                s_vn_11 = pSelOsn.dateNeed,
                sved_26 = pSelOsn.addition.Remove(pSelOsn.addition.Length - 49),
                klad_36 = pSelOsn.storeroom.ToDecimalOrDefault(),

                oper = pSelOsn.operation,
                rab_m = pSelOsn.workPlace,
                k_pl_32 = pSelOsn.amount,
                fio = pSelOsn.who, //НЕ УВЕРЕН, ПОМЕНЯТЬ кто фио? 
                //n_dra_5 = pSelOsn.nameDraft.Remove(pSelOsn.nameDraft.Length - 14), //слишком длинно

                to_2 = 0,
                ko1_27 = 0,
                z_iz_16="",
                tr_p_24 = 0,
                k_f_33=0,
                tr_f_34=0,
                zak_nar=0,
                nom_nar=0
            };
            pSelOsn.zak_1 = _newZak1;
            pSelOsn.accepted = true;
            db.os_pro.AddObject(_os_proNew);
            var _proos = db.proos.FirstOrDefault(i => i.tzakpred == pSelOsn.nOrdPrev);
            if (_proos != null)
            {
                _proos.dt_boss = DateTime.Now;
                _proos.boss = "я";
                _proos.tzak = _nOrdNew;
                _proos.sog = true;
                _proos.zak_1 = _newZak1;

                pSelOsn.dateBoss = DateTime.Now;
                pSelOsn.boss = "я";
                pSelOsn.nOrd = _nOrdNew;
                pSelOsn.accepted = true;
                pSelOsn.zak_1 = _newZak1;
            }

            SaveChanges();
           // PrintBlancOrd(); //ворк ин прогресс
        }
        public void PrintBlancOrd()
        {
            PrintDoc();
            //if (pSelOsn == null) return;
            //string Zak_1 = pSelOsn.zak_1;
            //if (Zak_1 == null || Zak_1 == "") return;
            //var plz = (from p in db.pl_zak_t where p.zak_1 == Zak_1 select p).ToList();
            //if (plz.Count > 0)
            //{
            //    foreach (var i in plz)
            //    {
            //        if (i.FilePath == null)
            //        {
            //            ZakDocs.ZakDoc.WriteScreenTZ(i.zakaz, i.nom, Zak_1, "C:\\goosn\\teczak.rtf"); //ЭРМ
            //        }
            //    }
            //}
            //else
            //{
            //    var a = ZakDocs.ZakDoc.WriteTexZak(Zak_1, "C:\\goosn\\teczak.rtf");//ЭРМ
            //    if (a == false)
            //    {
            //        MessageBox.Show("Запись не произведена! Разбирайтесь в причинах с привлечением разработчиков");
            //    }
            //}
        }
        public void SentToConstOrd()
        {
            if (pSelOsn == null) return;
            if (pSelOsn.draftOsn != pSelOsn.draftRes || pSelOsn.draftRes==0 || pSelOsn.draftOsn == 0 || pSelOsn.draft == 0 )
            {
                MessageBox.Show("Заказ не подлежит согласованию в КО!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var _zayvkaNew = new zayvka
            {
                dza = pSelOsn.dateWho,
                ndraftiz = pSelOsn.usage,
                draft = pSelOsn.draft,
                prim_an = pSelOsn.draftOsn.Value.ToString(),
                naimosn = pSelOsn.nameOsn,
                naosnsl = pSelOsn.characterOrd,
                prim = pSelOsn.reason,
                cexpol = pSelOsn.workshop,
                ksi = 9,
                kodop = pSelOsn.operation,
                rab_m = pSelOsn.workPlace,
                kladov = pSelOsn.storeroom.ToDecimalOrDefault(),
                kolzak = pSelOsn.amount,
                zakf = pSelOsn.ordOsn.ToString() + "/" + pSelOsn.numOsn.ToString(),
                tzak = pSelOsn.nOrd,
                draftosn = pSelOsn.draftRes,
                dataosn = pSelOsn.dateWho,
                imyt = pSelOsn.who,
                dizmt = pSelOsn.dateWho,
                dop = pSelOsn.addition,
                zak_1 = pSelOsn.zak_1
            };
            db.zayvka.AddObject(_zayvkaNew);
            var _proos = db.proos.FirstOrDefault(i => i.tzakpred == pSelOsn.nOrdPrev);
            if (_proos != null)
            {
                _proos.toko = true;
                _proos.dt_toko = DateTime.Now;

                pSelOsn.atConst = true;
               // pSelOsn.date = DateTime.Now;
            }

            SaveChanges();
        }
        public void WatchScanCopyOrd()
        {
            Process process = new Process();
            {
                process.StartInfo.FileName = @"C:\Fox\t3.exe"; //путь к приложению, которое будем запускать
                //process.StartInfo.WorkingDirectory = @"c:\Fox\"; //путь к рабочей директории приложения
                //process.StartInfo.Arguments = pSelOsn.draftGrid.ToString(); //аргументы командной строки (параметры)
                process.Start();
            };
        }
        public void EditOrd()
        {
            pCreateTabOpen=true;
        }
        public void PrintDoc()
        {
            try
            {
                string filename = @"Reports/report.frx";
                var parameters = new Dictionary<string, object>()
                {
                 { "a_comp", "F"}

                };
                var report = new ReportViewer(filename, true, parameters);
                report.ShowDialog();
            }

            catch (Exception ex)
            {
                //CheckStartUp.WriteErr(ex, @"Print");
                System.Windows.MessageBox.Show("Произошла ошибка");

            }

        }
        #endregion
    }
}


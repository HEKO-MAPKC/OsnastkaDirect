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
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
        public Osn BackupOsn;
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

        ObservableCollection<Osn> ListOsnNonFilters;
        public ObservableCollection<Osn> pListOsnNonFilters
        {
            get { return ListOsnNonFilters; }
            set
            {
                if (ListOsnNonFilters != value)
                {
                    ListOsnNonFilters = value;
                    OnPropertyChanged("pListOsnNonFilters");
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

        List<string> Filter = new List<string>{"Всё", "Утверждено","Неопределенно", "Возврат", "Направлено в КО", "Возврат из КО", "Аннулировано", "На рассмотрении"};
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

        bool CreateTabOpen = false;
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

        bool ApproveTabOpen = true;
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
        //^ утверждение оснастки
        //V открытие оснастки


        ObservableCollection<klados> ListStoreRoom;
        public ObservableCollection<klados> pListStoreRoom
        {
            get { return ListStoreRoom; }
            set
            {
                if (ListStoreRoom != value)
                {
                    ListStoreRoom = value;
                    OnPropertyChanged("pListStoreRoom");
                }
            }
        }

        List<TypeProduct> ListTypeProduct;
        public List<TypeProduct> pListTypeProduct
        {
            get { return ListTypeProduct; }
            set
            {
                if (ListTypeProduct != value)
                {
                    ListTypeProduct = value;
                    OnPropertyChanged("pListTypeProduct");
                }
            }
        }

        List<Product> ListProduct;
        public List<Product> pListProduct
        {
            get { return ListProduct; }
            set
            {
                if (ListProduct != value)
                {
                    ListProduct = value;
                    OnPropertyChanged("pListProduct");
                }
            }
        }

        List<Prod> ListProd;
        public List<Prod> pListProd
        {
            get { return ListProd; }
            set
            {
                if (ListProd != value)
                {
                    ListProd = value;
                    OnPropertyChanged("pListProd");
                }
            }
        }

        Prod SelProd;
        public Prod pSelProd
        {
            get { return SelProd; }
            set
            {
                if (SelProd != value)
                {
                    SelProd = value;
                    OnPropertyChanged("pSelProd");
                }
            }
        }

        bool RedactingModeOpen = false;
        public bool pRedactingModeOpen
        {
            get { return RedactingModeOpen; }
            set
            {
                if (RedactingModeOpen != value)
                {
                    RedactingModeOpen = value;
                    pIsReadOnlyRedacting = !value;
                    OnPropertyChanged("pRedactingModeOpen");
                }
            }
        }

        bool IsReadOnlyRedacting=true;
        public bool pIsReadOnlyRedacting
        {
            get { return IsReadOnlyRedacting; }
            set
            {
                if (IsReadOnlyRedacting != value)
                {
                    IsReadOnlyRedacting = value;
                    OnPropertyChanged("pIsReadOnlyRedacting");
                }
            }
        }
        bool CreateModeOpen = false;
        public bool pCreateModeOpen
        {
            get { return CreateModeOpen; }
            set
            {
                if (CreateModeOpen != value)
                {
                    CreateModeOpen = value;
                    OnPropertyChanged("pCreateModeOpen");
                }
            }
        }

        bool CreatingNewModeOpen = false;
        public bool pCreatingNewModeOpen
        {
            get { return CreatingNewModeOpen; }
            set
            {
                if (CreatingNewModeOpen != value)
                {
                    CreatingNewModeOpen = value;
                    pIsReadOnlyRedacting = !value;
                    OnPropertyChanged("pCreatingNewModeOpen");
                }
            }
        }

        List<string> ListCharacter = new List<string> { "Ремонт","Изготовление" };
        public List<string> pListCharacter
        {
            get { return ListCharacter; }
            set
            {
                if (ListCharacter != value)
                {
                    ListCharacter = value;
                    OnPropertyChanged("pListCharacter");
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
            //LoadListProduct();
            //LoadListTypeProduct();
            //LoadListStoreRoom();
            //OnChangeSelFilter();
        }
        //string GetDraftName(decimal? draft)
        //{
        //    if (draft == null) return string.Empty;
        //    FullDraftNameList list = db.FullDraftNameList.FirstOrDefault(l => l.Draft == draft);
        //    return list != null ? list.DraftName.Trim() : string.Empty;
        //}
        public void LoadListOsn()
        {
            // TODO (Новый)
            // 0. Поменять название 0 чертежа на "чертеж отсутсвует"
            // 1. Тримнуть названия оборуд и похожего
            // 2. Отсортить по т.з/дате
            // 3. Отрубить стрелки для перехода между вкладками 

            pListOsn = null;
            pListOsnLoaded = null;
            var _var1 = (from i in db.vOsnastTechOrder.Where(i => i.IsApplicationFrom.Value==true)

                         //join db6 in db.DraftOsnast on
                         //         /*SqlFunctions.Equals(i.zak_1,null) ? "0" :*/ i.TechOrderID equals db6.TechOrderID /*!= null ? db6.zak_1 : "0"*/  into gf6
                         //from DraftOsnastList in gf6.DefaultIfEmpty()
                                  //where i.zak_1 != null 
                         let _draftneed = i.InterOsnast == 0 || i.InterOsnast == null ? i.Osnast.Value : i.InterOsnast.Value

                         //join db1 in db.FullDraftNameList.Where(i => i.IsShortDraft)
                         //on (int)(i.TechOrder.Draft.Value / 1000) equals db1.Draft into gf1
                         //from listDse in gf1.DefaultIfEmpty().Take(1)

                         //join db2 in db.FullDraftNameList on
                         //i.DraftPiece equals db2.Draft into gf2
                         //from listDsePiece in gf2.DefaultIfEmpty().Take(1)

                         //join db3 in db.FullDraftNameList on
                         //i.DraftOsn equals db3.Draft into gf3
                         //from listDseOsn in gf3.DefaultIfEmpty().Take(1)
                         //let _DseGrid = i.DraftPiece == 0 || i.DraftPiece == null ? listDseOsn.DraftName : listDsePiece.DraftName

                         //join db1 in db.FullDraftList
                         //on i.TechOrder.Draft.Value equals db1.Draft into gf1
                         //from listDse in gf1.DefaultIfEmpty()

                         //join db2 in db.FullDraftList on
                         //i.DraftPiece equals db2.Draft into gf2
                         //from listDsePiece in gf2.DefaultIfEmpty() //TODO из-за этого не работает

                         //join db3 in db.FullDraftList on
                         //i.DraftOsn equals db3.Draft into gf3
                         //from listDseOsn in gf3.DefaultIfEmpty()
                         let _DseGrid = i.InterOsnast == 0 || i.InterOsnast == null ? i.OsnastName : i.InterOsnastName

                         //let draftgrid listDse.DraftPiece == 0 || listDsePiece.DraftPiece == null ?
                         //join db2 in db.LIST_FR on
                         //     _draftneed equals db2.WHAT into gf
                         //from listFr in gf.DefaultIfEmpty().Take(1)

                         //join db3 in db.olistdse on
                         //          _draftneed equals db3.draft into gf2
                         //from listDse2 in gf2.DefaultIfEmpty().Take(1)

                         //join db5 in db.prodact on
                         //     _draftneed equals db5.draft into gf5
                         //from listDse5 in gf5.DefaultIfEmpty().Take(1)

                         //join db4 in db.m_cennik on
                         //     /*SqlFunctions.StringConvert(_draftneed, 14, 2)*/SqlFunctions.StringConvert(_draftneed, 14, 2) equals db4.ocen into gf4
                         //from listDse4 in gf4.DefaultIfEmpty().Take(1)
                         //join db8 in db.pl_god on
                         //     new
                         //     {
                         //         _pr1 = list7.zakaz.Value,
                         //         _pr2 = list7.nom.Value
                         //     } equals new
                         //     {
                         //         _pr1 = db8.zakaz,
                         //         _pr2 = db8.nom

                         //     }
                         //     into gf8
                         //     from list8 in gf8.DefaultIfEmpty()
                         //         //oborud
                         //         //s_oper list6.rab_m
                         //         // list6.oper,
                         //join db9 in db.oborud on
                         //    list6.rab_m equals db9.rab_m into gf9
                         //from oborudlist in gf9.DefaultIfEmpty()

                         //join db10 in db.s_oper on
                         //    list6.oper equals db10.code into gf10
                         //from s_operlist in gf10.DefaultIfEmpty()

                         orderby i.OsnastOrderID descending
                              select new Osn
                              {
                                  draftOsnastID = i.OsnastOrderID,
                                  draftOsn = i.Osnast,
                                  workshop = i.Workshop,
                                  nOrdPrev = i.OsnastOrderID,
                                  nOrd = i.TechOrd,
                                  reason = i.ReasonProduction,
                                  addition = i.AddInformation,
                                  amount = i.AmountEquipmentProducePlan,
                                  dateWho = i.DateCreateApplication,
                                  who = i.AuthorTechnolog,
                                  returnRes = i.ReasonReturnedToTechnolog,
                                  draft = i.Draft,
                                  draftRes = i.InterOsnast,
                                  storeroom = i.StoreroomOsnast,
                                  nameGrid =
                                  _DseGrid != null ? _DseGrid.Trim() :
                                  "",
                                  draftGrid = i.InterOsnast == null || i.InterOsnast == 0 ? i.Osnast : i.InterOsnast,
                                  nameDraft = i.DraftName,
                                  nameOsn = i.OsnastName,
                                  nameRes = i.InterOsnastName,



                                  usage = i.NameDraftProduct,
                                  dtSrok = i.DateLimitation,
                                  dtIzg = i.DateAtApproval,
                                  dtOk = i.DateEmployeeFinalApproved,
                                  atConst = i.IsAtConstructor,
                                  accepted = i.IsStatusEmployeeApproved,
                                  returned = i.IsReturnedToTechnolog,
                                  fioConst = i.AuthorConstructorExecute,

                                 // ord700 = list7 != null ? list7.zakaz : 0,
                                 // num700 = list7 != null ? list7.nom : 0,
                                  ordOsn = i.FactoryOrder,
                                  numOsn = i.FactoryNumberOrder,
                                  workPlace = i.WorkplaceID,
                                  operation = i.OperationCodeID,
                                  characterOrd = i.RepairOrProduction,//i.TechOrder.TypeOsnast,
                                  //i.TechOrder.ReferenceInformation.ReferenceName,
                                  dateNeed = i.DateImplementPlan,

                                //  date700 = list8.data,
                                  annTab = i.ANNTab,
                                  datePlan = i.DateProducePlan,
                                  dateFact = i.DateProduceFact,

                                  workPlaceName = i.WorkplaceCode + " " + i.WorkplaceMachine,
                                  operationName = i.Operation,

                                  zak_1 = i.YearTechOrd,
                                 // id_os_pro = i.os_pro_id.Value, //ПОМЕНЯТЬ ПОТОМ НА НЕ NULL
                                 // id_prod = i.prod_id.Value,
                                  dateBoss = i.DateReturnedToTechnolog,
                                  boss = i.AuthorConstructor,
                                  dateAtConstructor = i.DateAtConstructor,
                                  WorkshopID = i.WorkshopID
                              })/*.Distinct()*/.ToList();
            ////dtplan WITH os_pro.s_iz_10;
            //dtfact WITH os_pro.d_iz_13;
            //koop WITH os_pro.z_iz_16
            //pListOsnLoaded = _var1;

            pListOsnLoaded = new ObservableCollection<Osn>(_var1);
            //foreach (Osn _osn in pListOsnLoaded)
            //{
                //_osn.nameGrid = GetDraftName(_osn.draftGrid);
                //_osn.nameDraft = GetDraftName(_osn.draft);
                //_osn.nameOsn = GetDraftName(_osn.draftOsn);
                //_osn.nameRes = GetDraftName(_osn.draftRes);
                //_osn.dateGrid = _osn.dateWho.Value.ToString("g");
                //if (_osn.date700!=null)
                //_osn.date700Grid = _osn.date700.Value.ToString("d");
                //if (_osn.draftRes != 0)
                //{
                //    _osn.draftGrid = _osn.draftRes;
                //    //_osn.nameGrid = _osn.nameRes;
                //}
                //else
                //{
                //    _osn.draftGrid = _osn.draftOsn;
                //    //_osn.nameGrid = _osn.nameOsn;
                //    //_osn.nameGrid = _osn.nameRes;
                //}
                //_osn.nameOsn = ElsibServices.DbService.SeekName(_osn.draftOsn.Value);
            //}
            pListOsn = new ObservableCollection<Osn>(pListOsnLoaded);
            //OnChangeSelFilter();
        }
        public void LoadProd()
        {
            pListProd = null;
            if (pSelOsn == null) return;
            if (pSelOsn.zak_1 == null || pSelOsn.zak_1 == "") return;
            pListProd = (from i in db.prod.Where(r => r.zak_1 == pSelOsn.zak_1)

                         join db8 in db.pl_god on
                              new
                              {
                                  _pr1 = i.zakaz.Value,
                                  _pr2 = i.nom.Value
                              } equals new
                              {
                                  _pr1 = db8.zakaz,
                                  _pr2 = db8.nom

                              }
                              into gf8
                         from list8 in gf8.DefaultIfEmpty()

                         select new Prod
                            {
                                num = i.nom,
                                ord = i.zakaz,
                                date = list8.data
                         }).ToList();
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
        }
        public void FindMany(bool _add = false)
        {
            SearchByName(_add);
            SearchAllFilters();
        }
        public void ChangeDate()
        {
            SearchAllFilters();
            //pListOsn = new ObservableCollection<Osn>(pListOsnLoaded.Where(i => i.dateWho >= dateSearchAfter && i.dateWho <= dateSearchBefore.AddDays(1).Date));
        }
        public void SearchByName(bool _add=false)
        {
            if (pListOsn == null || pListOsnLoaded == null) return;
            if (pListOsnNonFilters == null) pListOsnNonFilters = pListOsnLoaded;
            if (pSearchOsn == null || pSearchOsn == "")
            {
                return;
            }
            else
            {
                var _list = _add ? pListOsnNonFilters.AsEnumerable() : pListOsnLoaded.AsEnumerable();
                var _search = pSearchOsn.ToLower();
                switch (pSelFilterSearch)//"предварительный № т/з", "№ техзаказа", "исполнитель", "чертеж оснастки", "наименование оснастки"
                {
                    case "предварительный № т/з":
                        pListOsnNonFilters = new ObservableCollection<Osn>(_list.Where(i => i.nOrdPrev.ToString().ToLower().StartsWith(_search)));
                        break;
                    case "№ техзаказа":
                        pListOsnNonFilters = new ObservableCollection<Osn>(_list.Where(i => i.nOrd.ToString().ToLower().StartsWith(_search)));
                        break;
                    case "исполнитель":
                        pListOsnNonFilters = new ObservableCollection<Osn>(_list.Where(i => i.who.ToLower().StartsWith(_search)));
                        break;
                    case "чертеж оснастки":
                        pListOsnNonFilters = new ObservableCollection<Osn>(_list.Where(i => i.draftGrid.ToString().ToLower().StartsWith(_search)));
                        break;
                    case "наименование оснастки":
                        pListOsnNonFilters = new ObservableCollection<Osn>(_list.Where(i => i.nameGrid.ToLower().StartsWith(_search)));
                        break;
                    case "заказ номер":
                        pListOsnNonFilters = new ObservableCollection<Osn>(_list.Where(i => string.Format("{0:####}{1:#}{2:###}", i.ord700, " ", i.num700)
                                                    .StartsWith(_search, StringComparison.OrdinalIgnoreCase)));
                        break;
                    default:
                        break;
                }
            }
        }
        public void SearchAllFilters()
        {
            if (pListOsn == null || pListOsnLoaded == null) return;
            if (pListOsnNonFilters == null) pListOsnNonFilters = pListOsnLoaded;
            var _list = pListOsnNonFilters.AsEnumerable();
            _list = _list.Where(i => i.dateWho <= dateSearchBefore.AddDays(1).Date);
            if (dateSearchAfter != null)
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
                    _list = (_list.Where(i => (i.accepted == null || i.accepted == false) && i.returned == false && i.atConst == false && i.backFromConst == false && i.dtSrokIsNull == false && i.dtIzgIsNull == true));
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
            pListOsn = new ObservableCollection<Osn>(_list);
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
            /*
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
            SaveChanges();*/
            var _draftOsnast = db.OsnastOrder.FirstOrDefault(i => i.OsnastOrderID == pSelOsn.draftOsnastID);
            if (_draftOsnast == null) return;
            pSelOsn.zak_1 = null; //ТУТ ВОПРОС НУЛЛ ИЛИ НЕТ
            pSelOsn.accepted = false;
            pSelOsn.boss = "";
            pSelOsn.dateBoss = null;
            pSelOsn.nOrd = 0;
            _draftOsnast.YearTechOrd = ""; //ТУТ ВОПРОС НУЛЛ ИЛИ НЕТ
            _draftOsnast.TechOrder.YearTechOrd = "";
            _draftOsnast.IsStatusEmployeeApproved = false;
            _draftOsnast.TechOrder.AuthorConstructor = "";
            _draftOsnast.DateEmployeeApproved = null;
            _draftOsnast.TechOrder.TechOrd = 0;
            SaveChanges();
        }
        public void HoldOrd()
        {
            if (pSelOsn == null) return;
            var _draftOsnast = db.OsnastOrder.FirstOrDefault(i => i.OsnastOrderID == pSelOsn.draftOsnastID);
            if (_draftOsnast == null) return;
            if (_draftOsnast.TechOrder.DateAtApproval == null)
            {
                pSelOsn.dtIzg = DateTime.Now;
                _draftOsnast.TechOrder.DateAtApproval = DateTime.Now;
            }
            else
            {
                pSelOsn.dtIzg = null;
                _draftOsnast.TechOrder.DateAtApproval = null;
            }
            OnChangeSelFilter();
            SaveChanges();
        }
        public void ReturnBackOrd()
        {
            /* if (pSelOsn == null) return;
             var _osnLoad = db.proos.FirstOrDefault(i => i.tzakpred == pSelOsn.nOrdPrev);
             if (_osnLoad == null) return;
             _osnLoad.why_back = pSelOsn.returnRes;
             _osnLoad.dt_back = DateTime.Now;
             _osnLoad.back = true;

             pSelOsn.returned = true; */
            if (pSelOsn == null) return;
            var _draftOsnast = db.OsnastOrder.FirstOrDefault(i => i.OsnastOrderID == pSelOsn.draftOsnastID); //TODO возможность вернуть после возврата?
            if (_draftOsnast == null) return;
            _draftOsnast.TechOrder.ReasonReturnedToTechnolog = pSelOsn.returnRes;
            _draftOsnast.TechOrder.DateReturnedToTechnolog = DateTime.Now;
            _draftOsnast.TechOrder.IsReturnedToTechnolog = true;
            pSelOsn.returned = true;
            OnChangeSelFilter();
            SaveChanges();
        }
        public void AnnulOrd()
        {
            if (pSelOsn == null) return;
            //TODO когда нельзя аннулировать?
            if (pSelOsn.nOrd > 0)
            {
                if (true)//TODO босс или нет. тут помощь нужна с ok ПОМОЩЬ, ПО ХОДУ ТИПА БОСС ИЛИ НЕТ
                {
                    if (MessageBox.Show("Техзаказ утвержден! Хотите аннулировать?",
                        "Внимание!",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        var _draftOsnast = db.OsnastOrder.FirstOrDefault(i => i.OsnastOrderID == pSelOsn.draftOsnastID);
                        var _techOrder = _draftOsnast.TechOrder;
                        if (_draftOsnast == null || _techOrder == null) return;
                        db.OsnastOrder.DeleteObject(_draftOsnast);
                        db.TechOrder.DeleteObject(_techOrder);
                        pListOsn.Remove(pSelOsn);
                        SaveChanges();
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
                if (MessageBox.Show("Аннулировать?",
                    "Внимание!",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var _draftOsnast = db.OsnastOrder.FirstOrDefault(i => i.OsnastOrderID == pSelOsn.draftOsnastID); 
                    var _techOrder = _draftOsnast.TechOrder;
                    if (_draftOsnast == null || _techOrder==null) return;
                    db.OsnastOrder.DeleteObject(_draftOsnast);
                    db.TechOrder.DeleteObject(_techOrder);
                    pListOsn.Remove(pSelOsn);
                    SaveChanges();
                }
                else
                {
                    return;
                }
            }
        }
        public void FinalApproveOrd()
        {
            if (pSelOsn == null) return;
            var _draftOsnast = db.OsnastOrder.FirstOrDefault(i => i.OsnastOrderID == pSelOsn.draftOsnastID); 
            if (_draftOsnast == null) return;
            _draftOsnast.DateEmployeeFinalApproved = DateTime.Now;
            _draftOsnast.IsStatusEmployeeFinalApproved = true;
            pSelOsn.dtOk = DateTime.Now;
            SaveChanges();
            SaveOsnDB();
        }
        public void ApproveOrd()
        {
            if (pSelOsn == null) return;
            var _year = DateTime.Now.Year.ToString().Remove(0, 2);
            decimal _nOrdNew=0;
            //var _proosMAX = db.os_pro.FirstOrDefault(i => i.zak_1 == DateTime.Now.Year.ToString().Remove(0,2) + "-9999");
            var _proosMAX = db.OsnastOrder.Where(i => i.YearTechOrd.Substring(0,2) == _year && i.TechOrder.IsApplicationFrom==true).Max(j => j.YearTechOrd.Remove(0,3)).ToDecimalOrDefault(-1); //TODO не работает + а если 24ый год и пусто ни одного
            if (_proosMAX == -1) _nOrdNew = 7000;
            else _nOrdNew = _proosMAX+1;
            if (_nOrdNew > 9999)
            {
                MessageBox.Show("Максимум достигнут! Что делать? Честно, не знаю, ждите следующий год", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var _newZak1 = _year.ToString() + "-" + _nOrdNew.ToString();
            var _draftOsnast = db.OsnastOrder.FirstOrDefault(i => i.OsnastOrderID == pSelOsn.draftOsnastID);
            if (_draftOsnast == null) return;
            _draftOsnast.DateEmployeeApproved = DateTime.Now;
            _draftOsnast.TechOrder.AuthorConstructor = "я"; //TODO Имя босса
            _draftOsnast.TechOrder.TechOrd = (short)(_nOrdNew);
            _draftOsnast.IsStatusEmployeeApproved = true;
            _draftOsnast.TechOrder.YearTechOrd = _newZak1;

            pSelOsn.dateBoss = DateTime.Now;
            pSelOsn.boss = "я";
            pSelOsn.nOrd = _nOrdNew;
            pSelOsn.accepted = true;
            pSelOsn.zak_1 = _newZak1;
            //SaveChanges();
            SaveOsnDB();
           // PrintBlancOrd(); //TODO ворк ин прогресс
        }
        public void PrintBlancOrd()
        {
            if (pSelOsn == null) return;
            MessageBox.Show("Удалить нельзя! Техзаказ утвержден!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            var _draftOsnast = db.OsnastOrder.FirstOrDefault(i => i.OsnastOrderID == pSelOsn.draftOsnastID);
            if (_draftOsnast == null) return;
            //TODO походу, надо сделать как то упоминание что я теперь заявка/или нет
            _draftOsnast.Ksi = 9;
            _draftOsnast.TechOrder.IsAtConstructor = true;
            _draftOsnast.TechOrder.DateAtConstructor = DateTime.Now;
            pSelOsn.atConst = true;
            SaveChanges();
        }
        public void WatchScanCopyOrd()
        {
            if (pSelOsn == null) return;
            Process process = new Process();
            {
                process.StartInfo.FileName = @"C:\Fox\t3.exe"; //путь к приложению, которое будем запускать
                process.StartInfo.WorkingDirectory = @"c:\Fox\"; //путь к рабочей директории приложения
                process.StartInfo.Arguments = pSelOsn.draftGrid.ToString(); //аргументы командной строки (параметры)
                process.Start();

            };
        }
        public void EditOrd()
        {
            if (pSelOsn == null) return;
            Osnsv _osnsv = new Osnsv();
            OpenCreate();
        }
        public void PrintDoc()
        {
            if (pSelOsn == null) return;
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
        #region Открытие заказов
        public void LoadListStoreRoom()
        {
            pListStoreRoom = new ObservableCollection<klados> (db.klados.OrderBy(n => n.klad).ToList());
        }
        public void LoadListTypeProduct()
        {
            pListTypeProduct = (from i in db.iztyp
                                select new TypeProduct
                                {
                                    product = i.izdelie,
                                    type = i.iz,
                                }).ToList();
        }
        public void LoadListProduct()
        {
            pListProduct = (from i in db.prodact
                                select new Product
                                {
                                    product = i.name,
                                    draft = i.draft,
                                }).ToList();
        }
        public void OpenApprove()
        {
            DissableTabs();
            pApproveTabOpen = true;
        }

        public void OpenCreate()
        {
            LoadProd();
            DissableTabs();
            pCreateTabOpen = true;
            pCreateModeOpen = true;
        }
        public void OpenCreateNew(Osnsv _newOsn)
        {
            LoadProd();
            if (_newOsn != null)
            {
                var _oborud = db.oborud.FirstOrDefault(i => i.rab_m == _newOsn.workPlace);
                var _oper = db.s_oper.FirstOrDefault(i => i.code == _newOsn.codeOperation);
                string _workName = _oborud == null ? "" : _oborud.code + " " + _oborud == null ? "" : _oborud.oborud1;
                string _operName = _oper == null ? "" : _oper.oper;
                pSelOsn = new Osn
                {
                    draft = _newOsn.draft,
                    nameDraft = _newOsn.draftName,
                    draftOsn = _newOsn.draftOsn,
                    nameOsn = _newOsn.draftOsnName,
                    draftRes = _newOsn.draftPiece,
                    nameRes = _newOsn.draftPieceName,
                    workPlace = _newOsn.workPlace,
                    operation = _newOsn.codeOperation,
                    workPlaceName = _workName == " " ? "" : _workName,
                    operationName = _operName ?? "",

                };
                OpenCreatingNewMode(); //todo баг, скорее всего потому что view закрывается после вызова этого окна
            }
            else
            {
                return;
            }
        }
        public void ChangeUsage(string st)
        {
            pSelOsn.usage = st;
            OnPropertyChanged("pSelOsn");
        }
        public void ChangeWorkshop(Workshop _w)
        {
            pSelOsn.workshop = _w.Workshop1;
            pSelOsn.storeroom = _w.StoreroomOsnast;
            pSelOsn.WorkshopID = _w.WorkshopID;
            OnPropertyChanged("pSelOsn");
        }
        public void ChangeWorkplace(oborud _wp)
        {
            pSelOsn.workPlace = _wp.rab_m;
            pSelOsn.workPlaceName = _wp.code.Trim()+" "+_wp.oborud1.Trim();
            OnPropertyChanged("pSelOsn");
        }
        public void ChangeOperation(s_oper _op)
        {
            pSelOsn.operation = _op.code;
            pSelOsn.operationName = _op.oper.Trim();
            OnPropertyChanged("pSelOsn");
        }
        public void OpenRedactingMode()
        { 
            DissableTabs();
            pRedactingModeOpen = true;
            pCreateTabOpen = true;
            BackupOsn = new Osn(pSelOsn); 
        }
        public void OpenCreatingNewMode()
        {
            DissableTabs();
            pCreatingNewModeOpen = true;
            pCreateTabOpen = true;
            pSelOsn.dateWho = DateTime.Now;
            pSelOsn.who = "lol";
            pSelOsn.returned = false;
            pSelOsn.atConst = false;
            //pSelOsn.dateAtConstructor = null;
            OnPropertyChanged("pSelOsn");
        }
        public void DissableTabs()
        {
            pCreateTabOpen = false;
            pApproveTabOpen = false;

            pRedactingModeOpen = false;
            pCreateModeOpen = false;
            pCreatingNewModeOpen = false;
        }
        public void LoadBackupOsn()
        {
            pSelOsn.Copy(BackupOsn);
            OnPropertyChanged("pSelOsn");
        }
        public TechOrder GenerateTechOrder()
        {
            var _DraftDB = db.DraftInfoFull.FirstOrDefault(i => i.Draft == pSelOsn.draft);
            
            var _WorkshopDB = db.Workshop.FirstOrDefault(i => i.WorkshopID == pSelOsn.WorkshopID);

            int _DraftID;

            int _WorkshopID;
            if (_DraftDB != null) _DraftID = _DraftDB.DraftID;
            else _DraftID = 0;
            
            if (_WorkshopDB != null) _WorkshopID = _WorkshopDB.WorkshopID;
            else _WorkshopID = 0; //TODO разобраться с null и ?
            TechOrder _TechOrder = new TechOrder
            {
                IsApplicationFrom = true,
                DateCreateApplication = DateTime.Now,
                DraftID = _DraftID,
                WorkshopID = _WorkshopID,
                Workplace = pSelOsn.workPlace,
                OperationCode = pSelOsn.operation,
                ReasonProduction = pSelOsn.reason,
                AuthorBoss = pSelOsn.boss,
                AuthorTechnolog = pSelOsn.who,
                ReasonReturnedToTechnolog = pSelOsn.returnRes,
                NameDraftProduct = pSelOsn.usage,
                DateLimitation = pSelOsn.dtSrok,
                DateAtApproval = pSelOsn.dtIzg,
                IsAtConstructor = pSelOsn.atConst,
                IsReturnedToTechnolog = pSelOsn.returned,
                YearTechOrd = pSelOsn.zak_1 == null ? "0" : pSelOsn.zak_1,
                DateReturnedToTechnolog = pSelOsn.dateBoss,
                AuthorConstructor = pSelOsn.fioConst,
                DateAtConstructor = pSelOsn.dateAtConstructor,
                RepairOrProduction = pSelOsn.characterOrd == "Ремонт" ? 2 : 1,
            };
            return _TechOrder;
        }
        public OsnastOrder GenerateOsnastOrder(TechOrder _TechOrder)
        {
            var _OsnastDB = db.DraftInfoFull.FirstOrDefault(i => i.Draft == pSelOsn.draftOsn);

            DraftInfoFull _DraftInterDB;
            if (pSelOsn.draftRes != null)
                _DraftInterDB = db.DraftInfoFull.FirstOrDefault(i => i.Draft == pSelOsn.draftRes);
            else
                _DraftInterDB = db.DraftInfoFull.FirstOrDefault(i => i.Draft == 0);
            int _OsnastID;
            int _DraftInterID;
            if (_OsnastDB != null) _OsnastID = _OsnastDB.DraftID;
            else _OsnastID = 0;
            if (_DraftInterDB != null) _DraftInterID = _DraftInterDB.DraftID;
            else _DraftInterID = 0;
            OsnastOrder _OsnastOrder = new OsnastOrder
            {
                //OsnastOrderID = pSelOsn.draftOsnastID,
                OsnastID = _OsnastID,
                //Workshop = pSelOsn.workshop,
                //OsnastOrderID = pSelOsn.nOrdPrev,
                TechOrderID = _TechOrder.TechOrderID,
                //ReasonProduction = pSelOsn.reason,
                AddInformation = pSelOsn.addition,
                AmountEquipmentProducePlan = pSelOsn.amount,
                //DateCreateApplication = pSelOsn.dateWho,
                //AuthorTechnolog = p0SelOsn.who,
                //ReasonReturnedToTechnolog = pSelOsn.returnRes,
                //Draft = pSelOsn.draft,
                InterOsnastID = _DraftInterID,
                //StoreroomOsnast = pSelOsn.storeroom,



                //NameDraftProduct = pSelOsn.usage,
                //DateLimitation = pSelOsn.dtSrok,
                //DateAtApproval = pSelOsn.dtIzg,
                DateEmployeeFinalApproved = pSelOsn.dtOk,
                //IsAtConstructor = pSelOsn.atConst,
                IsStatusEmployeeApproved = pSelOsn.accepted,
                //IsReturnedToTechnolog = pSelOsn.returned,
                AuthorConstructorExecute = pSelOsn.fioConst,

                //FactoryOrder = pSelOsn.ordOsn,
                // FactoryNumberOrder = pSelOsn.numOsn,
                //WorkplaceID = pSelOsn.workPlace,
                //OperationCodeID = pSelOsn.operation,


                DateImplementPlan = pSelOsn.dateNeed,

                ANNTab = pSelOsn.annTab,
                DateProducePlan = pSelOsn.datePlan,
                DateProduceFact = pSelOsn.dateFact,
                //workPlaceName = i.WorkplaceCode + " " + i.WorkplaceMachine,
                //operationName = i.Operation,

                YearTechOrd = pSelOsn.zak_1 == null ? "0" : pSelOsn.zak_1,
                //DateReturnedToTechnolog = pSelOsn.dateBoss,
                //AuthorConstructor = pSelOsn.boss,
                //DateAtConstructor = pSelOsn.dateAtConstructor
            };
            return _OsnastOrder;
        }
        public void AddNewOsnDB()
        {
            var _TechOrder = GenerateTechOrder();
            var _OsnastOrder = GenerateOsnastOrder(_TechOrder);
            db.TechOrder.AddObject(_TechOrder); //TODO delat'
            db.OsnastOrder.AddObject(_OsnastOrder); //TODO delat'
            db.SaveChanges();
        }
        public void SaveOsnDB()
        {
            var _OsnastOrderDB = db.OsnastOrder.FirstOrDefault(i => i.OsnastOrderID == pSelOsn.nOrdPrev);
            var _TechOrderDB = db.TechOrder.FirstOrDefault(i => i.TechOrderID == _OsnastOrderDB.TechOrderID);

            var _DraftDB = db.DraftInfoFull.FirstOrDefault(i => i.Draft == pSelOsn.draft);
            var _WorkshopDB = db.Workshop.FirstOrDefault(i => i.WorkshopID == pSelOsn.WorkshopID);
            int _DraftID;
            int _WorkshopID;
            if (_DraftDB != null) _DraftID = _DraftDB.DraftID;
            else _DraftID = 0;
            if (_WorkshopDB != null) _WorkshopID = _WorkshopDB.WorkshopID;
            else _WorkshopID = 0; //TODO разобраться с null и ?

            _TechOrderDB.IsApplicationFrom = true;
            _TechOrderDB.DateCreateApplication = DateTime.Now;
            _TechOrderDB.DraftID = _DraftID;
            _TechOrderDB.WorkshopID = _WorkshopID;
            _TechOrderDB.Workplace = pSelOsn.workPlace;
            _TechOrderDB.OperationCode = pSelOsn.operation;
            _TechOrderDB.ReasonProduction = pSelOsn.reason;
            _TechOrderDB.AuthorBoss = pSelOsn.boss;
            _TechOrderDB.AuthorTechnolog = pSelOsn.who;
            _TechOrderDB.ReasonReturnedToTechnolog = pSelOsn.returnRes;
            _TechOrderDB.NameDraftProduct = pSelOsn.usage;
            _TechOrderDB.DateLimitation = pSelOsn.dtSrok;
            _TechOrderDB.DateAtApproval = pSelOsn.dtIzg;
            _TechOrderDB.IsAtConstructor = pSelOsn.atConst;
            _TechOrderDB.IsReturnedToTechnolog = pSelOsn.returned;
            _TechOrderDB.YearTechOrd = pSelOsn.zak_1 == null ? "0" : pSelOsn.zak_1;
            _TechOrderDB.DateReturnedToTechnolog = pSelOsn.dateBoss;
            _TechOrderDB.AuthorConstructor = pSelOsn.fioConst;
            _TechOrderDB.DateAtConstructor = pSelOsn.dateAtConstructor;
            _TechOrderDB.RepairOrProduction = pSelOsn.characterOrd == "Ремонт" ? 2 : 1;
            //
            var _OsnastDB = db.DraftInfoFull.FirstOrDefault(i => i.Draft == pSelOsn.draftOsn);

            DraftInfoFull _DraftInterDB;
            if (pSelOsn.draftRes != null)
                _DraftInterDB = db.DraftInfoFull.FirstOrDefault(i => i.Draft == pSelOsn.draftRes);
            else
                _DraftInterDB = db.DraftInfoFull.FirstOrDefault(i => i.Draft == 0);
            int _OsnastID;
            int _DraftInterID;
            if (_OsnastDB != null) _OsnastID = _OsnastDB.DraftID;
            else _OsnastID = 0;
            if (_DraftInterDB != null) _DraftInterID = _DraftInterDB.DraftID;
            else _DraftInterID = 0;
                _OsnastOrderDB.OsnastID = _OsnastID;
                _OsnastOrderDB.TechOrderID = _TechOrderDB.TechOrderID;
                _OsnastOrderDB.AddInformation = pSelOsn.addition;
                _OsnastOrderDB.AmountEquipmentProducePlan = pSelOsn.amount;
                _OsnastOrderDB.InterOsnastID = _DraftInterID;
                _OsnastOrderDB.DateEmployeeFinalApproved = pSelOsn.dtOk;
                _OsnastOrderDB.IsStatusEmployeeApproved = pSelOsn.accepted;
                _OsnastOrderDB.AuthorConstructorExecute = pSelOsn.fioConst;
                _OsnastOrderDB.DateImplementPlan = pSelOsn.dateNeed;
                _OsnastOrderDB.ANNTab = pSelOsn.annTab;
                _OsnastOrderDB.DateProducePlan = pSelOsn.datePlan;
                _OsnastOrderDB.DateProduceFact = pSelOsn.dateFact;
                _OsnastOrderDB.YearTechOrd = pSelOsn.zak_1 == null ? "0" : pSelOsn.zak_1;
            db.SaveChanges(); // TODO пофиксить время
        }
        #endregion
    }
}


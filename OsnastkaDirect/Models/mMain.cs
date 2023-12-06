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
            LoadListProduct();
            LoadListTypeProduct();
            LoadListStoreRoom();
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
            // TODO (Журнал разработки, дневник дева)
            // 0.(✔ - теперь знаю) Я не понял как оно само должно присоединяться по ключам, вроде все еще джойнить надо
            // 1. Название таблицы DraftOsnast и поле DraftOsnast(1) путается
            // 2.(✔ - ну поменял) Описания напутаны!!! dop и reason перепутаны, оно влияет на то как расположено в пункте Insert + доп обрезан, надо прописать определенный размер для varchar
            // 3. Прописать каскадное удаление? не удаляется нормально и не транкейтится + при аннулировании через программу удобнее удаление (?)
            // 4. Всё тримнуть, обрезать, типа исполнителя, или как вообще варчар работает, он всегда в программу суёт с дополнительным местом?
            // 5. В TechOrder ссылка на DraftOsnast пустая
            // 6. DraftOsnast IsStatusEmployeeApproved - нулловый где то, поменять просто на false? надо бы еще сравнить на разных таблицах согласования
            // 7. Присоединить таблицу iztyp к TechOrder?
            // 8. Присоединить к oborud таблице таблицу цехов/рабочих мест
            // 9. То что таблица ReferenceCode вне схемы оснастки - это же фича?
            // 10. Драфт нулевой или null в названии пишется то самое "ууууу", удалить с таблицы. Решить вообще что с названиями... - Решено, но нет, не решено
            // 11. Для techorder без техзаказа нужно сделать пустую строчку в DraftOsnast, у меня пустые драфты в таблице, нужно TechOrder не джойнить, а просто оттуда from инсертить. Невозможно соединить techorder proos, ибо заказ нулевой, нужно новое поле для связи с proos - Временно решено тем что объединил по полю t.DateCreateApplication = z.dt_who - тут я чета поменял неактуально
            // 12. Я все еще понимаю как присоединить наименования драфтов ко всем трём драфтам, получается будем заполнять таблицу наименованиями сразу?
            // 13. Почему вообще нельзя сделать truncate для таблицы TechOrder из-за внешних ключей?
            // 14. Легендарная таблица всех драфтов собрана, картинка на миро, решить что-то с форматированием. + сделать представлением или нет, подумать надо
            // 15. Как отсортировать таблицы
            // 16. Что за нулевой 0.0 драфт в 7к заказах outpro?
            // 17. Отрицательные trud в заявке
            // 18. Все даты либо перевести с временем или наоборот? В proos время в некоторых полях есть, в zayvka времени нету
            // 19. (✔ - ну поменял на возможность null) RepairOrProduction TypeOsnast для zayvka нулевые должны быть	 
            // 20. Что делать с оставшимися кладовыми
            // 21. Нужны ли столбцы с названиями в оснаске?
            // 22. В чем смысл записей где zayvka и proos совпадают?
            // 23. В концов концов я не сумел понять где какие связи, один к бесконечности, бесконечность к бесконечности...
            // 24. В итоге DraftOsnastka таблица важнее ибо она бесконечность к 1 TechOrder
            // 25. В итоге запись № 11 была права, надо как то по другому заполнять таблицу DraftOsnast 
            // 26. 353950 строк в draftosnast, я не знаю как джойнить.....
            // 27. Если не добавлять заявку то всё нормально, ибо у меня 1 к 1, но это неправильно так делать, ибо есть одинаковые строчки с зак_1
            // 28. Нужны ли нам os_pro без записей в заявках или проос?
            // 29. Я так понимаю есть в таблице заявка примерно одинаковые поля где отличия лишь в поле draftosnast, но поскольку мы отделяем это поле от заявки в нового поле, то он при соединении с ос_про дублирует строчки
            // 30. Либо верхний шаг неправда
            // 31. zAYVKA и os_pro связаны бесконечностью к бесконечности...
            // 32. Как использовать референс таблицу в коде?
            // 33. Количеству же не нужна дробная часть?
            // 34. Как подсоединить prod таблицу? 

            //Какой воркплейс и раб_м выбирается среди трех драфтов???
            //комплект, окомплект, продакт, оснсв, помойка,м_ценник(?), 
            pListOsn = null;
            pListOsnLoaded = null;
            var _var1 = (from i in db.DraftOsnast.Where(i => i.TechOrder.IsApplicationFrom.Value==true)

                         //join db6 in db.DraftOsnast on
                         //         /*SqlFunctions.Equals(i.zak_1,null) ? "0" :*/ i.TechOrderID equals db6.TechOrderID /*!= null ? db6.zak_1 : "0"*/  into gf6
                         //from DraftOsnastList in gf6.DefaultIfEmpty()
                                  //where i.zak_1 != null 
                         let _draftneed = i.DraftPiece == 0 || i.DraftPiece == null ? i.DraftOsn.Value : i.DraftPiece.Value

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

                         join db1 in db.FullDraftList
                         on i.TechOrder.Draft.Value equals db1.Draft into gf1
                         from listDse in gf1.DefaultIfEmpty().Take(1)

                         join db2 in db.FullDraftList on
                         i.DraftPiece equals db2.Draft into gf2
                         from listDsePiece in gf2.DefaultIfEmpty().Take(1)

                         join db3 in db.FullDraftList on
                         i.DraftOsn equals db3.Draft into gf3
                         from listDseOsn in gf3.DefaultIfEmpty().Take(1)
                         let _DseGrid = i.DraftPiece == 0 || i.DraftPiece == null ? listDseOsn.ReferenceInformation.ReferenceName : listDsePiece.ReferenceInformation.ReferenceName

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

                         orderby i.TechOrderID descending
                              select new Osn
                              {
                                  draftOsnastID = i.DraftOsnastID,
                                  draftOsn = i.DraftOsn,
                                  workshop = i.TechOrder.Workshop.Workshop1,
                                  nOrdPrev = i.TechOrderID.Value,
                                  nOrd = i.TechOrder.TechOrd,
                                  reason = i.TechOrder.ReasonProduction,
                                  addition = i.AddInformation,
                                  amount = i.AmountEquipmentProducePlan,
                                  dateWho = i.TechOrder.DateCreateApplication,
                                  who = i.TechOrder.AuthorTechnolog,
                                  returnRes = i.TechOrder.ReasonReturnedToTechnolog,
                                  draft = i.TechOrder.Draft,
                                  draftRes = i.DraftPiece,
                                  storeroom = i.TechOrder.Workshop.StoreroomOsnast,
                                  nameGrid =
                                  _DseGrid != null ? _DseGrid.Trim() :
                                  "",
                                  draftGrid = i.DraftPiece == null || i.DraftPiece == 0 ? i.DraftOsn : i.DraftPiece,
                                  nameDraft = listDse.ReferenceInformation.ReferenceName,
                                  nameOsn = listDseOsn.ReferenceInformation.ReferenceName,
                                  nameRes = listDsePiece.ReferenceInformation.ReferenceName,



                                  usage = i.TechOrder.NameDraftProduct,
                                  dtSrok = i.TechOrder.DateLimitation,
                                  dtIzg = i.TechOrder.DateAtApproval,
                                  dtOk = i.DateEmployeeFinalApproved,
                                  atConst = i.TechOrder.IsAtConstructor,
                                  accepted = i.IsStatusEmployeeApproved,
                                  returned = i.TechOrder.IsReturnedToTechnolog,
                                  fioConst = i.AuthorConstructorExecute,

                                 // ord700 = list7 != null ? list7.zakaz : 0,
                                 // num700 = list7 != null ? list7.nom : 0,
                                  ordOsn = i.TechOrder.FactoryOrder,
                                  numOsn = i.TechOrder.FactoryNumberOrder,
                                  workPlace = i.TechOrder.Workplace,
                                  operation = i.TechOrder.OperationCode,
                                  characterOrd = i.TechOrder.ReferenceInformation1.ReferenceName,//i.TechOrder.TypeOsnast,
                                  //i.TechOrder.ReferenceInformation.ReferenceName,
                                  dateNeed = i.DateImplementPlan,

                                //  date700 = list8.data,
                                  annTab = i.ANNTab,
                                  datePlan = i.DateProducePlan,
                                  dateFact = i.DateProduceFact,

                                  workPlaceName = i.TechOrder.oborud.code.Trim() + " " + i.TechOrder.oborud.oborud1.Trim(),
                                  operationName = i.TechOrder.s_oper.oper,

                                  zak_1 = i.TechOrder.YearTechOrd,
                                 // id_os_pro = i.os_pro_id.Value, //ПОМЕНЯТЬ ПОТОМ НА НЕ NULL
                                 // id_prod = i.prod_id.Value,
                                  dateBoss = i.TechOrder.DateReturnedToTechnolog,
                                  boss = i.TechOrder.AuthorConstructor,
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
            var _draftOsnast = db.DraftOsnast.FirstOrDefault(i => i.DraftOsnastID == pSelOsn.draftOsnastID);
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
            var _draftOsnast = db.DraftOsnast.FirstOrDefault(i => i.DraftOsnastID == pSelOsn.draftOsnastID);
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
            var _draftOsnast = db.DraftOsnast.FirstOrDefault(i => i.DraftOsnastID == pSelOsn.draftOsnastID); //TODO возможность вернуть после возврата?
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
                        var _draftOsnast = db.DraftOsnast.FirstOrDefault(i => i.DraftOsnastID == pSelOsn.draftOsnastID);
                        var _techOrder = _draftOsnast.TechOrder;
                        if (_draftOsnast == null || _techOrder == null) return;
                        db.DraftOsnast.DeleteObject(_draftOsnast);
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
                    var _draftOsnast = db.DraftOsnast.FirstOrDefault(i => i.DraftOsnastID == pSelOsn.draftOsnastID); 
                    var _techOrder = _draftOsnast.TechOrder;
                    if (_draftOsnast == null || _techOrder==null) return;
                    db.DraftOsnast.DeleteObject(_draftOsnast);
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
            var _draftOsnast = db.DraftOsnast.FirstOrDefault(i => i.DraftOsnastID == pSelOsn.draftOsnastID); 
            if (_draftOsnast == null) return;
            _draftOsnast.DateEmployeeFinalApproved = DateTime.Now;
            _draftOsnast.IsStatusEmployeeFinalApproved = true;
            pSelOsn.dtOk = DateTime.Now;
            SaveChanges();
        }
        public void ApproveOrd()
        {
            if (pSelOsn == null) return;
            var _year = DateTime.Now.Year.ToString().Remove(0, 2);
            decimal _nOrdNew=0;
            //var _proosMAX = db.os_pro.FirstOrDefault(i => i.zak_1 == DateTime.Now.Year.ToString().Remove(0,2) + "-9999");
            var _proosMAX = db.DraftOsnast.Where(i => i.YearTechOrd.Substring(0,2) == _year && i.TechOrder.IsApplicationFrom==true).Max(j => j.YearTechOrd.Remove(0,3)).ToDecimalOrDefault(-1); //TODO не работает + а если 24ый год и пусто ни одного
            if (_proosMAX == -1) _nOrdNew = 7000;
            else _nOrdNew = _proosMAX+1;
            if (_nOrdNew > 9999)
            {
                MessageBox.Show("Максимум достигнут! Что делать? Честно, не знаю, ждите следующий год", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var _newZak1 = _year.ToString() + "-" + _nOrdNew.ToString();
            var _draftOsnast = db.DraftOsnast.FirstOrDefault(i => i.DraftOsnastID == pSelOsn.draftOsnastID);
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
            SaveChanges();
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
            var _draftOsnast = db.DraftOsnast.FirstOrDefault(i => i.DraftOsnastID == pSelOsn.draftOsnastID);
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
            OpenCreate(_osnsv);
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
            pApproveTabOpen = true;
            pCreateTabOpen = false;
        }

        public void OpenCreate(Osnsv _osnast)
        {
            var _oborud = db.oborud.FirstOrDefault(i => i.rab_m == _osnast.workPlace);
            var _oper = db.s_oper.FirstOrDefault(i => i.code == _osnast.codeOperation);
            string _workName = _oborud == null ? "" : _oborud.code + " " + _oborud == null ? "" : _oborud.oborud1;
            string _operName = _oper == null ? "" : _oper.oper;
            pSelOsn = new Osn
            {
                draft = _osnast.draft,
                nameDraft = _osnast.draftName,
                draftOsn = _osnast.draftOsn,
                nameOsn = _osnast.draftOsnName,
                draftRes = _osnast.draftPiece,
                nameRes = _osnast.draftPieceName,
                workPlace = _osnast.workPlace,
                operation = _osnast.codeOperation,
                workPlaceName = _workName == " " ? "" : _workName,
                operationName = _operName ?? "",

            };
            pCreateTabOpen = true;
            pApproveTabOpen = false;
        }
        #endregion
    }
}


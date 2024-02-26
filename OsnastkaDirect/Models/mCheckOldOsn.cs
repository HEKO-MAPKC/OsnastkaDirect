using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
//
using Fox;
using OsnastkaDirect.Data;
using OsnastkaDirect.ViewModels;
//
namespace OsnastkaDirect.Models
{
    /// <summary>
    /// Класс mCheckOldOsn (Model)
    /// </summary>
    class mCheckOldOsn : MBase
    {
        #region Переменные

            /// <summary>
            /// Переменная для работы с базой данных
            /// </summary>
            public FOXEntities db;
        public vmMain WindowMain;
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
        #endregion

        #region Методы

            /// <summary>
            /// Конструктор
            /// </summary>
            public mCheckOldOsn()
            {
                db = VMLocator.VMs["Main"][VMLocator.mainKey].model.db;
            //
            // Инициализация свойств
            // pName = значение;
            }
        public void LoadOsn()
        {
            pListOsn = null;
            var _psel = WindowMain.Model.pSelOsn.draftGrid;//TODO фиксить
            var _var1 = (from i in db.vOsnastTechOrder.Where(i => i.IsApplicationFrom.Value == true)

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
                         let _DseDraft = i.InterOsnast == null || i.InterOsnast == 0 ? i.Osnast : i.InterOsnast
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
                         where _DseDraft == _psel
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
                             dateAtConstructor = i.DateAtConstructor
                         })/*.Distinct()*/.ToList();
            //var _var1 = (from i in db.OsnastOrder 

            //             join db6 in db.OsnastOrder on
            //                      /*SqlFunctions.Equals(i.zak_1,null) ? "0" :*/ i.TechOrderID equals db6.TechOrderID /*!= null ? db6.zak_1 : "0"*/  into gf6
            //             from DraftOsnastList in gf6.DefaultIfEmpty()
            //                 //where i.zak_1 != null 
            //             let _draftneed = DraftOsnastList.DraftPiece == 0 || DraftOsnastList.DraftPiece == null ? DraftOsnastList.DraftOsn.Value : DraftOsnastList.DraftPiece.Value

            //             join db1 in db.FullDraftNameList
            //             on (int)(i.TechOrder.Draft.Value / 1000) equals db1.Draft into gf1
            //             from listDse in gf1.DefaultIfEmpty().Take(1)

            //             join db2 in db.FullDraftNameList on
            //             DraftOsnastList.DraftPiece equals db2.Draft into gf2
            //             from listDsePiece in gf2.DefaultIfEmpty().Take(1)

            //             join db3 in db.FullDraftNameList on
            //             DraftOsnastList.DraftOsn equals db3.Draft into gf3
            //             from listDseOsn in gf3.DefaultIfEmpty().Take(1)
            //             let _DseGrid = DraftOsnastList.DraftPiece == 0 || DraftOsnastList.DraftPiece == null ? listDseOsn.DraftName : listDsePiece.DraftName
            //             let _DseDraft = DraftOsnastList.DraftPiece == null || DraftOsnastList.DraftPiece == 0 ? DraftOsnastList.DraftOsn : DraftOsnastList.DraftPiece
            //             where _DseDraft == _psel
            //             orderby i.TechOrderID descending
            //             select new Osn
            //             {
            //                 draftOsn = DraftOsnastList.DraftOsn,
            //                 // workshop = i.WorkshopID,
            //                 nOrdPrev = i.TechOrder.TechOrderID,
            //                 nOrd = i.TechOrder.TechOrd,
            //                 reason = i.TechOrder.ReasonProduction,
            //                 addition = i.AddInformation,
            //                 amount = i.AmountEquipmentForOper,
            //                 dateWho = i.TechOrder.DateCreateApplication,
            //                 who = i.TechOrder.AuthorTechnolog,
            //                 returnRes = i.TechOrder.ReasonReturnedToTechnolog,
            //                 draft = i.TechOrder.Draft,
            //                 draftRes = DraftOsnastList.DraftPiece,
            //                 // storeroom = DraftOsnastList.,
            //                 //nameDraft = db.ExecuteFunction<string> ("GetDraftName"),
            //                 //nameGrid= GetDraftName(_draftneed),
            //                 //nameDraft = GetDraftName(i.Draft),
            //                 //nameOsn = GetDraftName(DraftOsnastList.DraftOsnast1),
            //                 //nameRes = GetDraftName(DraftOsnastList.DraftPiece),
            //                 nameGrid =
            //                 _DseGrid != null ? _DseGrid.Trim() :
            //                 "",
            //                 draftGrid = DraftOsnastList.DraftPiece == null || DraftOsnastList.DraftPiece == 0 ? DraftOsnastList.DraftOsn : DraftOsnastList.DraftPiece,
            //                 nameDraft = listDse.DraftName,
            //                 nameOsn = listDseOsn.DraftName,
            //                 nameRes = listDsePiece.DraftName,



            //                 usage = i.TechOrder.NameDraftProduct,
            //                 dtSrok = i.TechOrder.DateLimitation,
            //                 dtIzg = i.TechOrder.DateAtApproval,
            //                 dtOk = DraftOsnastList.DateEmployeeFinalApproved,
            //                 atConst = i.TechOrder.IsAtConstructor,
            //                 accepted = DraftOsnastList.IsStatusEmployeeApproved,
            //                 returned = i.TechOrder.IsReturnedToTechnolog,
            //                 fioConst = DraftOsnastList.AuthorConstructorExecute,

            //                 // ord700 = list7 != null ? list7.zakaz : 0,
            //                 // num700 = list7 != null ? list7.nom : 0,
            //                 ordOsn = i.TechOrder.FactoryOrder,
            //                 numOsn = i.TechOrder.FactoryNumberOrder,
            //                 // workPlace = list6.rab_m,
            //                 // operation = list6.oper,
            //                 // characterOrd = i.rem_izg,
            //                 dateNeed = DraftOsnastList.DateImplementPlan,

            //                 //  date700 = list8.data,
            //                 annTab = DraftOsnastList.ANNTab,
            //                 datePlan = DraftOsnastList.DateProducePlan,
            //                 dateFact = DraftOsnastList.DateProduceFact,

            //                 // workPlaceName = oborudlist.code.Trim() + " " + oborudlist.oborud1.Trim(),
            //                 // operationName = s_operlist.oper,

            //                 zak_1 = i.YearTechOrd,
            //                 // id_os_pro = i.os_pro_id.Value, //ПОМЕНЯТЬ ПОТОМ НА НЕ NULL
            //                 // id_prod = i.prod_id.Value,
            //                 dateBoss = i.TechOrder.DateReturnedToTechnolog,
            //                 boss = i.TechOrder.AuthorConstructor,
            //             })/*.Distinct()*/.ToList();
            pListOsn = new ObservableCollection<Osn>( _var1);
        }
        #endregion
    }
}


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
            //pListOsn = new ObservableCollection<Osn>( _var1);
        }
        #endregion
    }
}


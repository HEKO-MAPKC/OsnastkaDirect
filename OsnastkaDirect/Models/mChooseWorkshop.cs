using System;
using System.Collections;
using System.Collections.Generic;
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
    /// Класс mChooseWorkshop (Model)
    /// </summary>
    class mChooseWorkshop : MBase
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
        string SearchDraft;
        public string pSearchDraft
        {
            get { return SearchDraft; }
            set
            {
                if (SearchDraft != value)
                {
                    SearchDraft = value;
                    OnPropertyChanged("pSearchDraft");
                }
            }
        }

        List<Workshop> ListWorkshop;
        public List<Workshop> pListWorkshop
        {
            get { return ListWorkshop; }
            set
            {
                if (ListWorkshop != value)
                {
                    ListWorkshop = value;
                    OnPropertyChanged("pListWorkshop");
                }
            }
        }

        Workshop SelWorkshop;
        public Workshop pSelWorkshop
        {
            get { return SelWorkshop; }
            set
            {
                if (SelWorkshop != value)
                {
                    SelWorkshop = value;
                    OnPropertyChanged("pSelWorkshop");
                }
            }
        }
        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public mChooseWorkshop()
            {
                db = VMLocator.VMs["Main"][VMLocator.mainKey].model.db;
            //
            // Инициализация свойств
            // pName = значение;
            LoadListWorkshop();
            }

        public void LoadListWorkshop()
        {
            pListWorkshop = db.Workshop.ToList();
                //= (from i in db.Workshop
                //            select new Workshop
                //            {
                //                Workshop1 = i.Workshop1,
                //                WorkshopDescription = i.WorkshopDescription
                //            }).ToList();
        }
        #endregion
    }
}


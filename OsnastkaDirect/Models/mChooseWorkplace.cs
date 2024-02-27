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
    /// Класс mChooseWorkplace (Model)
    /// </summary>
    class mChooseWorkplace : MBase
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
        public vmMain WindowMain;
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

        List<oborud> ListWorkplace;
        public List<oborud> pListWorkplace
        {
            get { return ListWorkplace; }
            set
            {
                if (ListWorkplace != value)
                {
                    ListWorkplace = value;
                    OnPropertyChanged("pListWorkplace");
                }
            }
        }

        oborud SelWorkplace;
        public oborud pSelWorkplace
        {
            get { return SelWorkplace; }
            set
            {
                if (SelWorkplace != value)
                {
                    SelWorkplace = value;
                    OnPropertyChanged("pSelWorkplace");
                }
            }
        }
        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public mChooseWorkplace()
            {
                db = VMLocator.VMs["Main"][VMLocator.mainKey].model.db;
            //
            // Инициализация свойств
            // pName = значение;
            LoadListWorkshop();
            }
        public void LoadListWorkshop()
        {
            pListWorkplace = db.oborud.ToList();
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


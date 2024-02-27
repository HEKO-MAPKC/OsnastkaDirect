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
    /// Класс mChooseOperation (Model)
    /// </summary>
    class mChooseOperation : MBase
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

        List<s_oper> ListOperation;
        public List<s_oper> pListOperation
        {
            get { return ListOperation; }
            set
            {
                if (ListOperation != value)
                {
                    ListOperation = value;
                    OnPropertyChanged("pListOperation");
                }
            }
        }

        s_oper SelOperation;
        public s_oper pSelOperation
        {
            get { return SelOperation; }
            set
            {
                if (SelOperation != value)
                {
                    SelOperation = value;
                    OnPropertyChanged("pSelOperation");
                }
            }
        }
        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public mChooseOperation()
            {
                db = VMLocator.VMs["Main"][VMLocator.mainKey].model.db;
            //
            // Инициализация свойств
            // pName = значение;
            LoadListOperation();
            }
        public void LoadListOperation()
        {
            pListOperation = db.s_oper.ToList();
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


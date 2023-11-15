using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//
using Fox;
using OsnastkaDirect.Data;
//
namespace OsnastkaDirect.Models
{
    /// <summary>
    /// Класс mOpenAuxililaryOsnast (Model)
    /// </summary>
    class mOpenAuxililaryOsnast : MBase
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

        List<Osnsv> ListOsnsv;
        public List<Osnsv> pListOsnsv
        {
            get { return ListOsnsv; }
            set
            {
                if (ListOsnsv != value)
                {
                    ListOsnsv = value;
                    OnPropertyChanged("pListOsnsv");
                }
            }
        }
        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public mOpenAuxililaryOsnast()
        {
            db = VMLocator.VMs["Main"][VMLocator.mainKey].model.db;
        //
        // Инициализация свойств
        // pName = значение;
            LoadOsnsv();
        }
        public void LoadOsnsv()
        {
            pListOsnsv = (from i in db.osnsv
                         select new Osnsv
                         {
                             draft=i.draft
                         }).ToList();
        }
        #endregion
    }
}


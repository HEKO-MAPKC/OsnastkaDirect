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
    /// Класс mOpenAuxililaryOsnast (Model)
    /// </summary>
    class mOpenAuxililaryOsnast : MBase
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

        Osnsv SelOsnsv;
        public Osnsv pSelOsnsv
        {
            get { return SelOsnsv; }
            set
            {
                if (SelOsnsv != value)
                {
                    SelOsnsv = value;
                    OnPropertyChanged("pSelOsnsv");
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
            pListOsnsv = (from i in db.osnsv//.Where(j => j.draft)
                         select new Osnsv
                         {
                             draftOsn = i.draftosn,
                             draftOsnName = i.naimosn,
                             workPlace = i.rab_m,
                             codeOperation = i.kodop
                         }).ToList();
        }
        #endregion
    }
}


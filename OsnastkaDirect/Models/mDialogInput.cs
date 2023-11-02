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
    /// Класс mDialogInput (Model)
    /// </summary>
    class mDialogInput : MBase
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

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public mDialogInput()
            {
                db = VMLocator.VMs["Main"][VMLocator.mainKey].model.db;
                //
                // Инициализация свойств
                // pName = значение;
            }

        #endregion
    }
}


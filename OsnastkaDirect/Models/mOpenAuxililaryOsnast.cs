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
            }

        #endregion
    }
}


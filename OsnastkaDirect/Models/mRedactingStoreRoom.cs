using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
//
using Fox;
using OsnastkaDirect.Data;
//
namespace OsnastkaDirect.Models
{
    /// <summary>
    /// Класс mRedactingStoreRoom (Model)
    /// </summary>
    class mRedactingStoreRoom : MBase
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

        klados SelStoreRoom;
        public klados pSelStoreRoom
        {
            get { return SelStoreRoom; }
            set
            {
                if (SelStoreRoom != value)
                {
                    SelStoreRoom = value;
                    OnPropertyChanged("pSelStoreRoom");
                }
            }
        }
        #endregion

        #region Методы

            /// <summary>
            /// Конструктор
            /// </summary>
            public mRedactingStoreRoom()
            {
                db = VMLocator.VMs["Main"][VMLocator.mainKey].model.db;
                //
                // Инициализация свойств
                // pName = значение;

            }

        #endregion
    }
}


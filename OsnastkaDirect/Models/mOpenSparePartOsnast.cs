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
    /// Класс mOpenSparePartOsnast (Model)
    /// </summary>
    class mOpenSparePartOsnast : MBase
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
        List<Osnsv> ListOcomplect;
        public List<Osnsv> pListOcomplect
        {
            get { return ListOcomplect; }
            set
            {
                if (ListOcomplect != value)
                {
                    ListOcomplect = value;
                    OnPropertyChanged("pListOcomplect");
                }
            }
        }

        Osnsv SelDraft;
        public Osnsv pSelDraft
        {
            get { return SelDraft; }
            set
            {
                if (SelDraft != value)
                {
                    SelDraft = value;
                    OnPropertyChanged("pSelDraft");
                }
            }
        }

        string Search;
        public string pSearch
        {
            get { return Search; }
            set
            {
                if (Search != value)
                {
                    Search = value;
                    OnPropertyChanged("pSearch");
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

        string SearchDSE;
        public string pSearchDSE
        {
            get { return SearchDSE; }
            set
            {
                if (SearchDSE != value)
                {
                    SearchDSE = value;
                    OnPropertyChanged("pSearchDSE");
                }
            }
        }
        #endregion

        #region Методы

            /// <summary>
            /// Конструктор
            /// </summary>
        public mOpenSparePartOsnast()
        {
            db = VMLocator.VMs["Main"][VMLocator.mainKey].model.db;
            //
            // Инициализация свойств
            // pName = значение;
            LoadOsnsv();
        }
        public void LoadOsnsv()
        {
            pListOcomplect = (from i in db.vResPart.Where(i => i.ResPart != null || i.ResPart !=0)
                              orderby i.ResPart
                              select new Osnsv
                              {
                                  draftOsn = i.Osnast,
                                  draftOsnName = i.OsnastName,
                                  draftPiece = i.ResPart,
                                  draftPieceName = i.ResPartName,
                                  draft = i.Draft,
                                  draftName = i.DraftName,
                                  workPlace = i.WorkplaceID,
                                  codeOperation = i.OperationCodeID
                              }).ToList();
        }
        #endregion
    }
}


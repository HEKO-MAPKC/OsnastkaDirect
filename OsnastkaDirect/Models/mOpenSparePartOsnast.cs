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
        List<Ocomplect> ListOcomplect;
        public List<Ocomplect> pListOcomplect
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
        List<Osnsv> ListDraft;
        public List<Osnsv> pListDraft
        {
            get { return ListDraft; }
            set
            {
                if (ListDraft != value)
                {
                    ListDraft = value;
                    OnPropertyChanged("pListDraft");
                }
            }
        }

        List<Osnsv> ListDraftOsn;
        public List<Osnsv> pListDraftOsn
        {
            get { return ListDraftOsn; }
            set
            {
                if (ListDraftOsn != value)
                {
                    ListDraftOsn = value;
                    OnPropertyChanged("pListDraftOsn");
                }
            }
        }

        List<Osnsv> ListDraftPiece;
        public List<Osnsv> pListDraftPiece
        {
            get { return ListDraftPiece; }
            set
            {
                if (ListDraftPiece != value)
                {
                    ListDraftPiece = value;
                    OnPropertyChanged("pListDraftPiece");
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

        Osnsv SelDraftOsn;
        public Osnsv pSelDraftOsn
        {
            get { return SelDraftOsn; }
            set
            {
                if (SelDraftOsn != value)
                {
                    SelDraftOsn = value;
                    OnPropertyChanged("pSelDraftOsn");
                }
            }
        }

        Osnsv SelDraftPiece;
        public Osnsv pSelDraftPiece
        {
            get { return SelDraftPiece; }
            set
            {
                if (SelDraftPiece != value)
                {
                    SelDraftPiece = value;
                    OnPropertyChanged("pSelDraftPiece");
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
            pListOcomplect = (from i in db.ocomplect//.Where(j => j.draft)
                              join db1 in db.FullDraftNameList
                                on i.kuda equals db1.Draft into gf1
                              from listDse in gf1.DefaultIfEmpty().Take(1)

                              join db2 in db.FullDraftNameList
                                on i.what equals db2.Draft into gf2
                              from listDsePiece in gf2.DefaultIfEmpty().Take(1)

                              join db3 in db.osnsv
                                on i.kuda equals db3.draftosn into gf3
                              from listOSNSV in gf3.DefaultIfEmpty()

                              join db4 in db.FullDraftNameList
                                on listOSNSV.draft equals db4.Draft into gf4
                              from listDseDraft in gf4.DefaultIfEmpty().Take(1)

                              select new Ocomplect
                              {
                                  draftOsn = i.kuda,
                                  draftOsnName = listDse.DraftName,
                                  draftPiece = i.what,
                                  draftPieceName = listDsePiece.DraftName,
                                  draft = listOSNSV.draft,
                                  draftName = listDseDraft.DraftName
                              }).ToList();
        }
        #endregion
    }
}


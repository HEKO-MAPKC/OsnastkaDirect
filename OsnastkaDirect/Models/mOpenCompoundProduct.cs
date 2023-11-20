using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Objects.SqlClient;
using System.IO;
using System.Linq;
//
using Fox;
using OsnastkaDirect.Data;
using out_dll;
//
namespace OsnastkaDirect.Models
{
    /// <summary>
    /// Класс mOpenCompoundProduct (Model)
    /// </summary>
    class mOpenCompoundProduct : MBase
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

        ObservableCollection<TreeViewDraft> ListDraftOsn;
        public ObservableCollection<TreeViewDraft> pListDraftOsn
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
        public mOpenCompoundProduct()
        {
            db = VMLocator.VMs["Main"][VMLocator.mainKey].model.db;
            //
            // Инициализация свойств
            // pName = значение;
            LoadOsnsv();
        }
        public void LoadOsnsv()
        {
            var _list = (from i in db.osnsv//.Where(j => j.draft)
                                            //join db1 in db.FullDraftNameList
                                            //  on i.kuda equals db1.Draft into gf1
                                            //from listDse in gf1.DefaultIfEmpty().Take(1)

                              //join db2 in db.FullDraftNameList 
                              //  on i.what equals db2.Draft into gf2
                              //from listDsePiece in gf2.DefaultIfEmpty().Take(1)

                              //join db3 in db.osnsv
                              //  on i.kuda equals db3.draftosn into gf3
                              //from listOSNSV in gf3.DefaultIfEmpty().Take(1)

                          join db4 in db.FullDraftNameList
                            on i.draft equals db4.Draft into gf4
                          from listDseDraft in gf4.DefaultIfEmpty().Take(1)

                          join db5 in db.FullDraftNameList
                            on (int)(i.draft/1000) equals db5.Draft into gf5
                          from listDseDraftSh in gf5.DefaultIfEmpty().Take(1)
                          select new Osnsv
                          {

                              //draftOsn = i.kuda,
                              //draftOsnName = listDse.DraftName,
                              //draftPiece= i.what,
                              //draftPieceName =listDsePiece.DraftName,
                              draft = i.draft,
                              draftName = listDseDraft.DraftName == null ? listDseDraftSh.DraftName : listDseDraft.DraftName
                          }).ToList();
            pListDraft = _list.Distinct().ToList();
        }
        public void LoadListDraftOsn()
        {
            pListDraftOsn = new ObservableCollection<TreeViewDraft>((from i in db.osnsv.Where(j => j.draft == pSelDraft.draft)

                                 //join db1 in db.FullDraftNameList
                                 //  on i.draft equals db1.Draft into gf1
                                 //from listDse in gf1.DefaultIfEmpty().Take(1)
                             select new TreeViewDraft
                             {
                                 draft = i.draftosn,
                                 draftName = SqlFunctions.StringConvert((double?)i.draftosn,14,2) + " " + i.naimosn,
                             }).ToList());
            //pListDraftOsn[0].children.Add(new TreeViewDraft ( 312, "fds" ));
            for (int i = 0; i < pListDraftOsn.Count; i++)
            {
                var lol = LoadListDraftOsnRec(pListDraftOsn[i].draft, pListDraftOsn[i].children);
                for (int j = 0; j < lol.Count; j++)
                {
                    pListDraftOsn[i].children.Add(new TreeViewDraft(lol[j].draft, lol[j].draftName, lol[j].children));
                    //pListDraftOsn[i].children.Add(new TreeViewDraft(312, "fds", new ObservableCollection<TreeViewDraft>(new List<TreeViewDraft> { (new TreeViewDraft(312, "fds")) } )));
                }
            }
            //string Err = "";// здесь будут все сообщения об ошибках в информации при разузловании и других режимах
            //List<ClOutT> OutT = new List<ClOutT>();//здесь будет разузлованный состав
            //List<ClTr> Te = new List<ClTr>();// здесь будет пооперационная трудоемкость
            //List<Itog> itm = new List<Itog>();// здесь будет потребность в ТМЦ
            //                                  //Разузлование
            //var re = Rasusl.mRasusl(pSelDraft.draft.Value, false, OutT, out Err);//4АЗМ-2500/6000 Т4  
            ///// Выполнение составило  4344 ms
            //if (Err.Length == 0)// нет ошибок разузлования
            //{
            //    foreach (var v in OutT)
            //    {

            //        //Расчет трудоемкости
            //        Rasusl.GetTe(v.draft, v.path, v.id, v.spec, v.ksi, v.knk, false, Te);
            //        //Rasusl.GetTe(v.draft, v.path, v.id, v.spec, v.ksi, v.knk, false, Te,ref Err); // вариант с контролем наличия ТН
            //        // в Err сообщения об ошибках
            //    }
            //    ///Выполнение составило  11794 ms

            //    //расчет потребности в ТМЦ
            //    itm = Rasusl.GetMaterialsItog(OutT, ref Err);

            //    ///Выполнение составило  12825 ms
            //    if (Err.Length == 0)// нет ошибок при расчете норм ТМЦ
            //        ;//........
            //    else
            //        ;//......
            //}
            //pListDraftOsn = OutT;
                   }
        public ObservableCollection<TreeViewDraft> LoadListDraftOsnRec(decimal? _draft, ObservableCollection<TreeViewDraft> _children)
        {
            _children = new ObservableCollection<TreeViewDraft>((from i in db.outpro.Where(j => j.across == _draft)

                                         join db1 in db.FullDraftNameList
                                           on i.draft equals db1.Draft into gf1
                                         from listDse in gf1.DefaultIfEmpty().Take(1)

                                         select new TreeViewDraft
                                         {
                                             draft = i.draft,
                                             draftName = SqlFunctions.StringConvert((double?)i.draft,14,2) + " " + listDse.DraftName,
                                         }).ToList());
            for (int i = 0; i < _children.Count; i++)
            {
                var _list = LoadListDraftOsnRec(_children[i].draft, _children[i].children);
                for (int j = 0; j < _list.Count; j++)
                {
                    _children[i].children.Add(new TreeViewDraft(_list[j].draft, _list[j].draftName, _list[j].children));
                   // _children[i].children.Add(new TreeViewDraft(312, "fds", new ObservableCollection<TreeViewDraft>(new List<TreeViewDraft> { (new TreeViewDraft(312, "fds")) })));
                }
            }
            //for (int i = 0; i < _children.Count; i++)
            //{
            //    _children[i].children = LoadListDraftOsnRec(_children[i].draft, _children[i].children);
            //}
            return _children;
        }
        public void LoadListDraftPiece()
        {
            pListDraftPiece = (from i in db.ocomplect.Where(j => j.kuda == pSelDraftOsn.draftOsn)

                               join db2 in db.FullDraftNameList
                                 on i.what equals db2.Draft into gf2
                               from listDsePiece in gf2.DefaultIfEmpty().Take(1)

                               select new Osnsv
                               {
                                   draftPiece = i.what,
                                   draftPieceName = listDsePiece.DraftName,
                               }).ToList();
        }
        #endregion
    }
}


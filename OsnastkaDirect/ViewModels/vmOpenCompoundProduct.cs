using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
//
using Fox;
using OsnastkaDirect.Data;
using OsnastkaDirect.Models;
using OsnastkaDirect.Views;
//
namespace OsnastkaDirect.ViewModels
{
    /// <summary>
    /// Класс OpenCompoundProduct (ViewModel)
    /// </summary>
    class vmOpenCompoundProduct : VMBase
    {
        #region Переменные

            /// <summary>
            /// Переменная View
            /// </summary>
            public OpenCompoundProduct View;
            /// <summary>
            /// Переменная Model
            /// </summary>
            public mOpenCompoundProduct Model;
        //
        // Переменная для свойства команды
        //
        CommandBase AcceptOpen;

        public CommandBase pAcceptOpen
        {
            get { return AcceptOpen ?? (AcceptOpen = new CommandBase(mAcceptOpen)); }
        }

        CommandBase NotAcceptOpen;

        public CommandBase pNotAcceptOpen
        {
            get { return NotAcceptOpen ?? (NotAcceptOpen = new CommandBase(mNotAcceptOpen)); }
        }

        CommandBase FindOrd;

        public CommandBase pFindOrd
        {
            get { return FindOrd ?? (FindOrd = new CommandBase(mFindOrd)); }
        }

        CommandBase FindDraft;

        public CommandBase pFindDraft
        {
            get { return FindDraft ?? (FindDraft = new CommandBase(mFindDraft)); }
        }

        CommandBase FindOsnast;

        public CommandBase pFindOsnast
        {
            get { return FindOsnast ?? (FindOsnast = new CommandBase(mFindOsnast)); }
        }
        #endregion

        #region Свойства

        //CommandBase commandName;
        //
        // Свойство команды
        //
        //public CommandBase pCommand
        //{
        //    get { return commandName ?? (commandName = new CommandBase(MethodName)); }
        //}

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public vmOpenCompoundProduct()
            {

            }
            /// <summary>
            /// Обработчик события загрузки View
            /// </summary>
            /// <param name="_sender"></param>
            /// <param name="_routedEventArgs"></param>
            public void viewLoaded(object _sender, RoutedEventArgs _routedEventArgs)
            {
                View = (OpenCompoundProduct)view;
                Model = (mOpenCompoundProduct)model;
                //
                Model.PropertyChanged += modelPropertyChangedHandler;             
            }

        /// <summary>
        /// Обработчик изменения свойств модели
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_eventArgs"></param>
        public void modelPropertyChangedHandler(object _sender, PropertyChangedEventArgs _eventArgs)
        {
            if (_eventArgs.PropertyName == "pSelDraft" && Model.pSelDraft != null)
            {
                Model.pSelDraftOsn = null;
                Model.pSelDraftPiece = null;
                Model.LoadListDraftOsn();
            }
            if (_eventArgs.PropertyName == "pSelDraftOsn" && Model.pSelDraftOsn != null)
            {
                Model.pSelDraftPiece = null;
                Model.LoadListDraftPiece();
            }
                        if (_eventArgs.PropertyName == "pDraftSearch" && Model.pDraftSearch != null)
            {
                mFindDraft();
            }
            if (_eventArgs.PropertyName == "pOsnastSearch" && Model.pOsnastSearch != null)
            {
                mFindOsnast();
            }
        }
        public void mFindOrd()
        {
            if (!string.IsNullOrEmpty(Model.pOrderSearch))
            {
                var i = (Model.pListDraft).FirstOrDefault(r => r.draft.ToString()
                                                .StartsWith(Model.pOrderSearch, StringComparison.OrdinalIgnoreCase)
                                         );
                if (i != null)
                {
                    View.DataGridOrder.ScrollIntoView(i);
                    Model.pSelDraft = i;
                }
            }
        }

        public void mFindDraft()
        {
            //if (Model.pListDraftOutpro == null) return;
            //if (!string.IsNullOrEmpty(Model.pDraftSearch))
            //{
            //    var i = (Model.pListDraftOutpro).FirstOrDefault(r => r.draft.Value.ToString()
            //                                    .StartsWith(Model.pDraftSearch, StringComparison.OrdinalIgnoreCase));
            //    if (i != null)
            //    {
            //        // View.TreeView.//ScrollIntoView(i);
            //        foreach (var item in Model.pListDraftOutpro)
            //        {
            //            item.IsSelected = false;
            //        }
            //        Model.pSelDraftOutpro = i;
            //        Model.pSelDraftOutpro.IsSelected = true;
            //        Model.FindOsnast();
            //        View.TreeViewSelectedItemChanged2();
            //    }
            //}
        }

        public void mFindOsnast()
        {
            //CollectionViewSource.GetDefaultView(Model.pListDraftPiece).Refresh();
            if (Model.pListDraftPiece == null) return;
            if (!string.IsNullOrEmpty(Model.pOsnastSearch))
            {
                var i = (Model.pListDraftPiece).FirstOrDefault(r => r.draftPiece.ToString()
                                                .StartsWith(Model.pOsnastSearch, StringComparison.OrdinalIgnoreCase));
                if (i != null)
                {
                    View.DataGridOrderOsn.ScrollIntoView(i);
                    Model.pSelDraftPiece = i;
                }
            }
        }
        public void mAcceptOpen()
        {
            //if (Model.pSelOsnsv == null) return;
            var _draft = Model.pSelDraft;
            var _draftOsn = Model.pSelDraftPiece;
            //object _draftPiece = null;
            var _draftWorkPlace = Model.pSelDraftPiece;
            var _osnsv = new Osnsv
            {
                draft = _draft == null ? null : _draft.draft,
                draftName = _draft == null ? null : _draft.draftName,
                draftOsn = _draftOsn == null ? null : _draftOsn.draft,
                draftOsnName = _draftOsn == null ? null : _draftOsn.draftName,
                //draftPiece = _draftPiece == null ? null : _draftPiece.draftPiece,
                //draftPieceName = _draftPiece == null ? null : _draftPiece.draftPieceName,
                workPlace = _draftWorkPlace == null ? null : _draftWorkPlace.workPlace,
                codeOperation = _draftWorkPlace == null ? null : _draftWorkPlace.codeOperation
            };
            Model.WindowMain.OpenCreateDraft(_osnsv);
            View.Close();
        }
        public void mNotAcceptOpen()
        {
            View.Close();
        }
        #endregion
    }
}
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
    /// Класс OpenFinOrder (ViewModel)
    /// </summary>
    class vmOpenFinOrder : VMBase
    {
        #region Переменные

            /// <summary>
            /// Переменная View
            /// </summary>
            public OpenFinOrder View;
            /// <summary>
            /// Переменная Model
            /// </summary>
            public mOpenFinOrder Model;
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
        public vmOpenFinOrder()
            {

            }
            /// <summary>
            /// Обработчик события загрузки View
            /// </summary>
            /// <param name="_sender"></param>
            /// <param name="_routedEventArgs"></param>
            public void viewLoaded(object _sender, RoutedEventArgs _routedEventArgs)
            {
                View = (OpenFinOrder)view;
                Model = (mOpenFinOrder)model;
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
            if (_eventArgs.PropertyName == "pSelOrder" && Model.pSelOrder != null)
            {
                Model.pSelDraftOutpro = null;
                Model.pSelDraftPiece = null;
                Model.LoadListDraftOsn();
            }
            if (_eventArgs.PropertyName == "pSelDraftOutpro" && Model.pSelDraftOutpro != null)
            {
                Model.pSelDraftPiece = null;
                Model.LoadListDraftPiece();
            }
        }
        public void mAcceptOpen()
        {
            //if (Model.pSelOsnsv == null) return;
            var _draft = Model.pSelOrder;
            var _draftOsn = Model.pSelDraftOutpro;
            var _draftPiece = Model.pSelDraftPiece;
            var _draftWorkPlace = Model.pSelDraftPiece;
            var _osnsv = new Osnsv
            {
                draft = _draft == null ? null : _draft.draft,
                draftName = _draft == null ? null : _draft.draftName,
                draftOsn = _draftOsn == null ? null : _draftOsn.draft,
                draftOsnName = _draftOsn == null ? null : _draftOsn.draftName,
                draftPiece = _draftPiece == null ? null : _draftPiece.draftPiece,
                draftPieceName = _draftPiece == null ? null : _draftPiece.draftPieceName,
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
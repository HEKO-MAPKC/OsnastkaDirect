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
    /// Класс OpenSparePartOsnast (ViewModel)
    /// </summary>
    class vmOpenSparePartOsnast : VMBase
    {
        #region Переменные

            /// <summary>
            /// Переменная View
            /// </summary>
            public OpenSparePartOsnast View;
            /// <summary>
            /// Переменная Model
            /// </summary>
            public mOpenSparePartOsnast Model;
        //
        // Переменная для свойства команды
        //

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

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public vmOpenSparePartOsnast()
            {

            }
            /// <summary>
            /// Обработчик события загрузки View
            /// </summary>
            /// <param name="_sender"></param>
            /// <param name="_routedEventArgs"></param>
            public void viewLoaded(object _sender, RoutedEventArgs _routedEventArgs)
            {
                View = (OpenSparePartOsnast)view;
                Model = (mOpenSparePartOsnast)model;
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
                ;
            }
        public void mAcceptOpen()
        {
            if (Model.pSelDraft == null) return;
            var _draft = Model.pSelDraft;
            var _draftOsn = Model.pSelDraft;
            var _draftPiece = Model.pSelDraft;
            var _draftWorkPlace = Model.pSelDraft;
            var _osnsv = new Osnsv
            {
                draft = _draft == null ? null : _draft.draft,
                draftName = _draft == null ? null : _draft.draftName,
                draftOsn = _draftOsn == null ? null : _draftOsn.draftOsn,
                draftOsnName = _draftOsn == null ? null : _draftOsn.draftOsnName,
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
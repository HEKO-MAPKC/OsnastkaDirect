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
    /// Класс OpenAuxililaryOsnast (ViewModel)
    /// </summary>
    class vmOpenAuxililaryOsnast : VMBase
    {
        #region Переменные

            /// <summary>
            /// Переменная View
            /// </summary>
            public OpenAuxililaryOsnast View;
            /// <summary>
            /// Переменная Model
            /// </summary>
            public mOpenAuxililaryOsnast Model;
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
        public vmOpenAuxililaryOsnast()
            {

            }
            /// <summary>
            /// Обработчик события загрузки View
            /// </summary>
            /// <param name="_sender"></param>
            /// <param name="_routedEventArgs"></param>
            public void viewLoaded(object _sender, RoutedEventArgs _routedEventArgs)
            {
                View = (OpenAuxililaryOsnast)view;
                Model = (mOpenAuxililaryOsnast)model;
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
            if (_eventArgs.PropertyName == "pSearchOsn" && Model.pSearchOsn != null)
            {
                mFindOsn();
            }
        }
        public void mFindOsn()
        {
            if (!string.IsNullOrEmpty(Model.pSearchOsn))
            {
                var i = (Model.pListOsnsv).FirstOrDefault(r => r.draftOsn.ToString()
                                                .StartsWith(Model.pSearchOsn, StringComparison.OrdinalIgnoreCase));
                if (i != null)
                {
                    View.DataGridOsn.ScrollIntoView(i);
                    Model.pSelOsnsv = i;
                }
            }
        }

        public void mAcceptOpen()
        {
            if (Model.pSelOsnsv == null) return;
            //var _draft = Model.pSelOsnsv;
            var _draftOsn = Model.pSelOsnsv;
            //var _draftPiece = Model.pSelOsnsv;
            var _draftWorkPlace = Model.pSelOsnsv;
            var _osnsv = new Osnsv
            {
                draft = (decimal)(11111111111.22),
                draftName = "Общее применение оснащения",
                draftOsn = _draftOsn == null ? null : _draftOsn.draftOsn,
                draftOsnName = _draftOsn == null ? null : _draftOsn.draftOsnName,
               // draftPiece = _draftPiece == null ? null : _draftPiece.draft,
               // draftPieceName = _draftPiece == null ? null : _draftPiece.draftName,
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
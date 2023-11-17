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
            Model.WindowMain.mOpenCreate();
            View.Close();
        }
        public void mNotAcceptOpen()
        {
            View.Close();
        }
        #endregion
    }
}
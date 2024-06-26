﻿using System;
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
    /// Класс ChooseResPart (ViewModel)
    /// </summary>
    class vmChooseResPart : VMBase
    {
        #region Переменные

            /// <summary>
            /// Переменная View
            /// </summary>
            public ChooseResPart View;
            /// <summary>
            /// Переменная Model
            /// </summary>
            public mChooseResPart Model;
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
        CommandBase Cancel;

        public CommandBase pCancel
        {
            get { return Cancel ?? (Cancel = new CommandBase(mCancel)); }
        }

        CommandBase Confirm;

        public CommandBase pConfirm
        {
            get { return Confirm ?? (Confirm = new CommandBase(mConfirm)); }
        }
        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public vmChooseResPart()
            {

            }
            /// <summary>
            /// Обработчик события загрузки View
            /// </summary>
            /// <param name="_sender"></param>
            /// <param name="_routedEventArgs"></param>
            public void viewLoaded(object _sender, RoutedEventArgs _routedEventArgs)
            {
                View = (ChooseResPart)view;
                Model = (mChooseResPart)model;
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
        public void mCancel()
        {
            View.Close();
        }

        public void mConfirm()
        {
            //if (Model.pSelWorkshop != null)
            //{
            //    if (Model.pSelWorkshop.Workshop1 != null || Model.pSelWorkshop.Workshop1 != "")
            //        Model.WindowMain.Model.ChangeWorkshop(Model.pSelWorkshop);
            //}
            View.Close();
        }
        #endregion
    }
}
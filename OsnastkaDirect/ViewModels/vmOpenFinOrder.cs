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
                ;
            }
            
        #endregion
    }
}
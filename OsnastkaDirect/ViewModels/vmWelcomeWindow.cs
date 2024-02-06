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
    /// Класс WelcomeWindow (ViewModel)
    /// </summary>
    class vmWelcomeWindow : VMBase
    {
        #region Переменные

            /// <summary>
            /// Переменная View
            /// </summary>
            public WelcomeWindow View;
            /// <summary>
            /// Переменная Model
            /// </summary>
            public mWelcomeWindow Model;
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

        CommandBase OpenOldOsnast;

        public CommandBase pOpenOldOsnast
        {
            get { return OpenOldOsnast ?? (OpenOldOsnast = new CommandBase(mOpenOldOsnast)); }
        }

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public vmWelcomeWindow()
            {

            }
            /// <summary>
            /// Обработчик события загрузки View
            /// </summary>
            /// <param name="_sender"></param>
            /// <param name="_routedEventArgs"></param>
            public void viewLoaded(object _sender, RoutedEventArgs _routedEventArgs)
            {
                View = (WelcomeWindow)view;
                Model = (mWelcomeWindow)model;
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

        public void mOpenOldOsnast()
        {

            string name = typeof(Main).Name;
            int index = VMLocator.CreateViewModel(name);

            ((Main)VMLocator.VMs[name][index].view).Loaded += ((vmMain)VMLocator.VMs[name][index]).viewLoaded;
            ((Main)VMLocator.VMs[name][index].view).Unloaded += (obj, args) => VMLocator.Clean((string)(((dynamic)obj).Uid));
            //
            //VMLocator.VMs[name][index].model.pTmcnet = Model.tmcnet;

            //
            VMLocator.VMs[name][index].view.Owner = View;
            VMLocator.VMs[name][index].view.Show();
            View.Hide();
        }
        #endregion
    }
}
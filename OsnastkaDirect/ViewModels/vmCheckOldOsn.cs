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
    /// Класс CheckOldOsn (ViewModel)
    /// </summary>
    class vmCheckOldOsn : VMBase
    {
        #region Переменные

            /// <summary>
            /// Переменная View
            /// </summary>
            public CheckOldOsn View;
            /// <summary>
            /// Переменная Model
            /// </summary>
            public mCheckOldOsn Model;
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
        CommandBase DoubleClickOsn;

        public CommandBase pDoubleClickOsn
        {
            get { return DoubleClickOsn ?? (DoubleClickOsn = new CommandBase(mDoubleClickOsn)); }
        }
        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public vmCheckOldOsn()
            {

            }
            /// <summary>
            /// Обработчик события загрузки View
            /// </summary>
            /// <param name="_sender"></param>
            /// <param name="_routedEventArgs"></param>
            public void viewLoaded(object _sender, RoutedEventArgs _routedEventArgs)
            {
                View = (CheckOldOsn)view;
                Model = (mCheckOldOsn)model;
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
        public void mDoubleClickOsn()
        {
            var _modelMain = Model.WindowMain.Model;
            if (Model.pSelOsn == null || _modelMain == null) return;
            _modelMain.pSelOsn = _modelMain.pListOsn.FirstOrDefault(i => i.draftOsnastID == Model.pSelOsn.draftOsnastID);
            _modelMain.OpenCreate();
            View.Close();
        }
        #endregion
    }
}
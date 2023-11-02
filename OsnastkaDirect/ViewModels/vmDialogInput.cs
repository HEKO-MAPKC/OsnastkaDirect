using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;
//
using Fox;
using OsnastkaDirect.Data;
using OsnastkaDirect.Models;
using OsnastkaDirect.Views;
//
namespace OsnastkaDirect.ViewModels
{
    /// <summary>
    /// Класс DialogInput (ViewModel)
    /// </summary>
    class vmDialogInput : VMBase
    {
        #region Переменные

            /// <summary>
            /// Переменная View
            /// </summary>
            public DialogInput View;
            /// <summary>
            /// Переменная Model
            /// </summary>
            public mDialogInput Model;
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

        CommandBase Save;

        public CommandBase pSave
        {
            get { return Save ?? (Save = new CommandBase(mSave)); }
        }

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public vmDialogInput()
            {

            }
            /// <summary>
            /// Обработчик события загрузки View
            /// </summary>
            /// <param name="_sender"></param>
            /// <param name="_routedEventArgs"></param>
            public void viewLoaded(object _sender, RoutedEventArgs _routedEventArgs)
            {
                View = (DialogInput)view;
                Model = (mDialogInput)model;
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

        public void mSave()
        {
            if (Model.pSelOsn.returnRes == null || Model.pSelOsn == null)
            {
                MessageBox.Show("Некоторые записи отсутствуют!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                //var _osnLoad = Model.db.proos.FirstOrDefault(i => i.tzakpred == Model.pSelOsn.nOrdPrev);
                //if (_osnLoad == null) return;
                //_osnLoad.why_back = Model.pSelOsn.returnRes;
                //Model.db.SaveChanges();
            }
            catch (Exception ex)
            {
                //CheckStartUp.WriteErr(ex, @"mSavedialoginput");
                System.Windows.MessageBox.Show("Произошла ошибка,\n информация передана разработчику");
            }
            View.Close();
        }
        #endregion
    }
}
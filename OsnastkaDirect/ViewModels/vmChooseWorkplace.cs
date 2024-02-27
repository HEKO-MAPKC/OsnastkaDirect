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
    /// Класс ChooseWorkplace (ViewModel)
    /// </summary>
    class vmChooseWorkplace : VMBase
    {
        #region Переменные

            /// <summary>
            /// Переменная View
            /// </summary>
            public ChooseWorkplace View;
            /// <summary>
            /// Переменная Model
            /// </summary>
            public mChooseWorkplace Model;
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
        public vmChooseWorkplace()
            {

            }
            /// <summary>
            /// Обработчик события загрузки View
            /// </summary>
            /// <param name="_sender"></param>
            /// <param name="_routedEventArgs"></param>
            public void viewLoaded(object _sender, RoutedEventArgs _routedEventArgs)
            {
                View = (ChooseWorkplace)view;
                Model = (mChooseWorkplace)model;
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
            if (_eventArgs.PropertyName == "pSearchDraft" && Model.pSearchDraft != null)
            {
                mFindDraft();
            }
        }
        public void mFindDraft()
        {
            if (Model.pSearchDraft != null)
            {
                oborud i = null;
                i = (Model.pListWorkplace).FirstOrDefault(r => r.rab_m.ToString()
                                                .StartsWith(Model.pSearchDraft, StringComparison.OrdinalIgnoreCase));
                if (i != null)
                {
                    View.DataGridProduct.ScrollIntoView(i);
                    Model.pSelWorkplace = i;
                }
            }
        }

        public void mCancel()
        {
            View.Close();
        }

        public void mConfirm()
        {
            if (Model.pSelWorkplace != null)
            {
                if (Model.pSelWorkplace.rab_m != null)
                    Model.WindowMain.Model.ChangeWorkplace(Model.pSelWorkplace);
            }
            View.Close();
        }
        #endregion
    }
}
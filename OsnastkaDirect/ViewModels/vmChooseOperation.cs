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
    /// Класс ChooseOperation (ViewModel)
    /// </summary>
    class vmChooseOperation : VMBase
    {
        #region Переменные

            /// <summary>
            /// Переменная View
            /// </summary>
            public ChooseOperation View;
            /// <summary>
            /// Переменная Model
            /// </summary>
            public mChooseOperation Model;
        //
        // Переменная для свойства команды
        //
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
        public vmChooseOperation()
            {

            }
            /// <summary>
            /// Обработчик события загрузки View
            /// </summary>
            /// <param name="_sender"></param>
            /// <param name="_routedEventArgs"></param>
            public void viewLoaded(object _sender, RoutedEventArgs _routedEventArgs)
            {
                View = (ChooseOperation)view;
                Model = (mChooseOperation)model;
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
                s_oper i = null;
                i = (Model.pListOperation).FirstOrDefault(r => r.code.ToString()
                                                .StartsWith(Model.pSearchDraft, StringComparison.OrdinalIgnoreCase));
                if (i != null)
                {
                    View.DataGridProduct.ScrollIntoView(i);
                    Model.pSelOperation = i;
                }
            }
        }

        public void mCancel()
        {
            View.Close();
        }

        public void mConfirm()
        {
            if (Model.pSelOperation != null)
            {
                if (Model.pSelOperation.oper != null || Model.pSelOperation.oper != "")
                    Model.WindowMain.Model.ChangeOperation(Model.pSelOperation);
            }
            View.Close();
        }
        #endregion
    }
}
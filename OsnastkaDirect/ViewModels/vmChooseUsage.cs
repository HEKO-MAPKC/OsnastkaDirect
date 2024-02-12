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
    /// Класс ChooseUsage (ViewModel)
    /// </summary>
    class vmChooseUsage : VMBase
    {
        #region Переменные

            /// <summary>
            /// Переменная View
            /// </summary>
            public ChooseUsage View;
            /// <summary>
            /// Переменная Model
            /// </summary>
            public mChooseUsage Model;
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
        public vmChooseUsage()
            {

            }
            /// <summary>
            /// Обработчик события загрузки View
            /// </summary>
            /// <param name="_sender"></param>
            /// <param name="_routedEventArgs"></param>
            public void viewLoaded(object _sender, RoutedEventArgs _routedEventArgs)
            {
                View = (ChooseUsage)view;
                Model = (mChooseUsage)model;
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
            if (Model.pSearchDraft !=null)
            {
                Product i = null;
                i = (Model.pListProduct).FirstOrDefault(r => r.draft.Value.ToString()
                                                .StartsWith(Model.pSearchDraft, StringComparison.OrdinalIgnoreCase));
                if (i != null)
                {
                    View.DataGridProduct.ScrollIntoView(i);
                    Model.pSelProduct = i;
                }
            }
        }

        public void mCancel()
        {
            View.Close();
        }

        public void mConfirm()
        {
            if (Model.pSelProduct != null)
            {
                if (Model.pSelProduct.product != null || Model.pSelProduct.product != "")
                    Model.WindowMain.Model.ChangeUsage(Model.pSelProduct.product);
            }
            else 
            if (Model.pSelTypeProduct != null)
                if (Model.pSelTypeProduct.type != null || Model.pSelTypeProduct.type != "")
                Model.WindowMain.Model.ChangeUsage("Общее применение " + Model.pSelTypeProduct.type);
            View.Close();
        }
        #endregion
    }
}
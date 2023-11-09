using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
//
using System.Drawing;
using System.Windows.Forms;
using Fox;
using OsnastkaDirect.Data;
using OsnastkaDirect.Models;
using OsnastkaDirect.Views;
using System.Collections.ObjectModel;
using System.Windows.Data;
//
namespace OsnastkaDirect.ViewModels
{
    /// <summary>
    /// Класс Main (ViewModel)
    /// </summary>
    class vmMain : VMBase
    {
        #region Переменные

        /// <summary>
        /// Переменная View
        /// </summary>
        public Main View;
        /// <summary>
        /// Переменная Model
        /// </summary>
        public mMain Model;
        //
        // Переменная для свойства команды
        //
        //CommandBase commandName;

        #endregion

        #region Свойства

        //
        // Свойство команды
        //
        //public CommandBase pCommand
        //{
        //    get { return commandName ?? (commandName = new CommandBase(MethodName)); }
        //}

        CommandBase FindOsn;

        public CommandBase pFindOsn
        {
            get { return FindOsn ?? (FindOsn = new CommandBase(mFindOsn)); }
        }

        CommandBase ClearFindOsn;

        public CommandBase pClearFindOsn
        {
            get { return ClearFindOsn ?? (ClearFindOsn = new CommandBase(mClearFindOsn)); }
        }

        CommandBase FindOsnMany;

        public CommandBase pFindOsnMany
        {
            get { return FindOsnMany ?? (FindOsnMany = new CommandBase(mFindOsnMany)); }
        }

        CommandBase FindOsnManyAdd;

        public CommandBase pFindOsnManyAdd
        {
            get { return FindOsnManyAdd ?? (FindOsnManyAdd = new CommandBase(mFindOsnManyAdd)); }
        }

        CommandBase Disapprove;

        public CommandBase pDisapprove
        {
            get { return Disapprove ?? (Disapprove = new CommandBase(mDisapprove)); }
        }

        CommandBase Hold;

        public CommandBase pHold
        {
            get { return Hold ?? (Hold = new CommandBase(mHold)); }
        }

        CommandBase ReturnBack;

        public CommandBase pReturnBack
        {
            get { return ReturnBack ?? (ReturnBack = new CommandBase(mReturnBack)); }
        }

        CommandBase Annul;

        public CommandBase pAnnul
        {
            get { return Annul ?? (Annul = new CommandBase(mAnnul)); }
        }

        CommandBase OpenApprove;

        public CommandBase pOpenApprove
        {
            get { return OpenApprove ?? (OpenApprove = new CommandBase(mOpenApprove)); }
        }

        CommandBase OpenCreate;

        public CommandBase pOpenCreate
        {
            get { return OpenCreate ?? (OpenCreate = new CommandBase(mOpenCreate)); }
        }

        CommandBase FinalApprove;

        public CommandBase pFinalApprove
        {
            get { return FinalApprove ?? (FinalApprove = new CommandBase(mFinalApprove)); }
        }

        CommandBase Approve;

        public CommandBase pApprove
        {
            get { return Approve ?? (Approve = new CommandBase(mApprove)); }
        }

        CommandBase PrintBlanc;

        public CommandBase pPrintBlanc
        {
            get { return PrintBlanc ?? (PrintBlanc = new CommandBase(mPrintBlanc)); }
        }

        CommandBase SentToConst;

        public CommandBase pSentToConst
        {
            get { return SentToConst ?? (SentToConst = new CommandBase(mSentToConst)); }
        }

        CommandBase WatchScanCopy;

        public CommandBase pWatchScanCopy
        {
            get { return WatchScanCopy ?? (WatchScanCopy = new CommandBase(mWatchScanCopy)); }
        }

        CommandBase Edit;

        public CommandBase pEdit
        {
            get { return Edit ?? (Edit = new CommandBase(mEdit)); }
        }

        CommandBase OpenRedactingStoreRoom;

        public CommandBase pOpenRedactingStoreRoom
        {
            get { return OpenRedactingStoreRoom ?? (OpenRedactingStoreRoom = new CommandBase(mOpenRedactingStoreRoom)); }
        }

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public vmMain()
        {

        }
        /// <summary>
        /// Обработчик события загрузки View
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_routedEventArgs"></param>
        public void viewLoaded(object _sender, RoutedEventArgs _routedEventArgs)
        {
            View = (Main)view;
            Model = (mMain)model;
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
            if (_eventArgs.PropertyName == "pSelOsn" && Model.pSelOsn != null)
            {
                Model.OnClickOsn();
            }
            if (_eventArgs.PropertyName == "pSelFilter" && Model.pSelFilter != null)
            {
                Model.OnChangeSelFilter();
            }
            if ((_eventArgs.PropertyName == "pdateSearchAfter" || _eventArgs.PropertyName == "pdateSearchBefore") 
                && (Model.pdateSearchAfter != null || Model.pdateSearchBefore != null))
            {
                Model.ChangeDate();
            }
            //if (_eventArgs.PropertyName == "pSelFilterSearch" && Model.pSelFilterSearch != null)
            //{
            //    mFindOsn();
            //}
        }
        public void mFindOsnMany()
        {
            Model.FindMany();
        }
        public void mFindOsnManyAdd()
        {
            Model.FindMany(true);
        }
        public void mFindOsn()
        {
            if (!string.IsNullOrEmpty(Model.pSearchOsn))
            {
                Osn i=null;
                switch (Model.pSelFilterSearch)//"предварительный № т/з", "№ техзаказа", "исполнитель", "чертеж оснастки", "наименование оснастки"
                {
                    case "предварительный № т/з":
                        i = (Model.pListOsn).FirstOrDefault(r => r.nOrdPrev.ToString()
                                                .StartsWith(Model.pSearchOsn, StringComparison.OrdinalIgnoreCase)
                                         );
                        break;
                    case "№ техзаказа":
                        i = (Model.pListOsn).FirstOrDefault(r => r.nOrd.Value.ToString()
                                                .StartsWith(Model.pSearchOsn, StringComparison.OrdinalIgnoreCase)
                                         );
                        break;
                    case "исполнитель":
                        i = (Model.pListOsn).FirstOrDefault(r => r.who
                                                .StartsWith(Model.pSearchOsn, StringComparison.OrdinalIgnoreCase)
                                         );
                        break;
                    case "чертеж оснастки":
                        i = (Model.pListOsn).FirstOrDefault(r => r.draftRes.Value.ToString()
                                                .StartsWith(Model.pSearchOsn, StringComparison.OrdinalIgnoreCase)
                                         );
                        break;
                    case "наименование оснастки":
                        i = (Model.pListOsn).FirstOrDefault(r => r.nameRes
                                                .StartsWith(Model.pSearchOsn, StringComparison.OrdinalIgnoreCase)
                                         );
                        break;
                    case "заказ номер":
                        i = (Model.pListOsn).FirstOrDefault(r => string.Format("{0:####}{1:#}{2:###}", r.ord700, " ", r.num700)
                                                        .StartsWith(Model.pSearchOsn, StringComparison.OrdinalIgnoreCase)
                                                 );
                        break;
                    default:
                        break;
                }
                if (i != null)
                {
                    View.DataGridOsn.ScrollIntoView(i);
                    Model.pSelOsn = i;
                }
            }
        }

        public void mClearFindOsn()
        {
            Model.pSearchOsn = "";
            Model.pSelFilter = "Всё";
            Model.pdateSearchBefore = DateTime.Now;
            Model.pdateSearchAfter = null;
            Model.pListOsn = new ObservableCollection<Osn>(Model.pListOsnLoaded);

        }

        public void mDisapprove()
        {
            Model.DisapproveOrd();
        }
        public void mHold()
        {
            Model.HoldOrd();
        }

        public void mAnnul()
        {
            Model.AnnulOrd();
        }
        public void mReturnBack()
        {
            if (Model.pSelOsn == null) return;
            string name = typeof(DialogInput).Name;
            int index = VMLocator.CreateViewModel(name);

            ((DialogInput)VMLocator.VMs[name][index].view).Loaded += ((vmDialogInput)VMLocator.VMs[name][index]).viewLoaded;
            ((DialogInput)VMLocator.VMs[name][index].view).Unloaded += (obj, args) => VMLocator.Clean((string)(((dynamic)obj).Uid));
            //
            //VMLocator.VMs[name][index].model.pTmcnet = Model.tmcnet;

            //
            //((DialogInput)VMLocator.VMs[name][index].view).DataContext = this;
            if (Model.pSelOsn != null)
            {
                VMLocator.VMs[name][index].model.pSelOsn = Model.pSelOsn;
            }
            VMLocator.VMs[name][index].view.Owner = View;
            VMLocator.VMs[name][index].view.ShowDialog();
            CollectionViewSource.GetDefaultView(Model.pListOsn).Refresh();
            Model.ReturnBackOrd();
        }

        public void mOpenApprove()
        {
            Model.pApproveTabOpen = true;
            Model.pCreateTabOpen = false;
        }

        public void mOpenCreate()
        {
            Model.pCreateTabOpen = true;
            Model.pApproveTabOpen = false;
        }
        public void mFinalApprove()
        {
            Model.FinalApproveOrd();
        }

        public void mApprove()
        {
            Model.ApproveOrd();
        }
        public void mPrintBlanc()
        {
            Model.PrintBlancOrd();
        }
        public void mSentToConst()
        {
            Model.SentToConstOrd();
        }
        public void mWatchScanCopy()
        {
            Model.WatchScanCopyOrd();
        }
        public void mEdit()
        {
            Model.EditOrd();
        }
        #endregion
        #region Создание техзаказов/редактирование
        public void mOpenRedactingStoreRoom()
        {

            string name = typeof(RedactingStoreRoom).Name;
            int index = VMLocator.CreateViewModel(name);

            ((RedactingStoreRoom)VMLocator.VMs[name][index].view).Loaded += ((vmRedactingStoreRoom)VMLocator.VMs[name][index]).viewLoaded;
            ((RedactingStoreRoom)VMLocator.VMs[name][index].view).Unloaded += (obj, args) => VMLocator.Clean((string)(((dynamic)obj).Uid));
            
            VMLocator.VMs[name][index].model.pListStoreRoom = Model.pListStoreRoom;

            VMLocator.VMs[name][index].view.Owner = View;
            VMLocator.VMs[name][index].view.ShowDialog();
        }
        #endregion
    }
}
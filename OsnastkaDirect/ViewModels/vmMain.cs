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


        CommandBase OpenAuxililaryOsnastW;

        public CommandBase pOpenAuxililaryOsnastW
        {
            get { return OpenAuxililaryOsnastW ?? (OpenAuxililaryOsnastW = new CommandBase(mOpenAuxililaryOsnastW)); }
        }

        CommandBase OpenSparePartW;

        public CommandBase pOpenSparePartW
        {
            get { return OpenSparePartW ?? (OpenSparePartW = new CommandBase(mOpenSparePartW)); }
        }

        CommandBase OpenCompoundProductW;

        public CommandBase pOpenCompoundProductW
        {
            get { return OpenCompoundProductW ?? (OpenCompoundProductW = new CommandBase(mOpenCompoundProductW)); }
        }

        CommandBase OpenFinOrderW;

        public CommandBase pOpenFinOrderW
        {
            get { return OpenFinOrderW ?? (OpenFinOrderW = new CommandBase(mOpenFinOrderW)); }
        }

        CommandBase OpenCheckOldOsn;

        public CommandBase pOpenCheckOldOsn
        {
            get { return OpenCheckOldOsn ?? (OpenCheckOldOsn = new CommandBase(mOpenCheckOldOsn)); }
        }

        CommandBase DoubleClickOsn;

        public CommandBase pDoubleClickOsn
        {
            get { return DoubleClickOsn ?? (DoubleClickOsn = new CommandBase(mDoubleClickOsn)); }
        }

        CommandBase BackTechOrd;

        public CommandBase pBackTechOrd
        {
            get { return BackTechOrd ?? (BackTechOrd = new CommandBase(mBackTechOrd)); }
        }

        CommandBase NextTechOrd;

        public CommandBase pNextTechOrd
        {
            get { return NextTechOrd ?? (NextTechOrd = new CommandBase(mNextTechOrd)); }
        }

        CommandBase OpenChooseUsage;

        public CommandBase pOpenChooseUsage
        {
            get { return OpenChooseUsage ?? (OpenChooseUsage = new CommandBase(mOpenChooseUsage)); }
        }


        CommandBase SetUsageGeneral;

        public CommandBase pSetUsageGeneral
        {
            get { return SetUsageGeneral ?? (SetUsageGeneral = new CommandBase(mSetUsageGeneral)); }
        }

        CommandBase SetUsage;

        public CommandBase pSetUsage
        {
            get { return SetUsage ?? (SetUsage = new CommandBase(mSetUsage)); }
        }

        CommandBase SetUsageGeneralType;

        public CommandBase pSetUsageGeneralType
        {
            get { return SetUsageGeneralType ?? (SetUsageGeneralType = new CommandBase(mSetUsageGeneralType)); }
        }

        CommandBase OpenRedactingMode;

        public CommandBase pOpenRedactingMode
        {
            get { return OpenRedactingMode ?? (OpenRedactingMode = new CommandBase(mOpenRedactingMode)); }
        }


        CommandBase CancelRedacting;

        public CommandBase pCancelRedacting
        {
            get { return CancelRedacting ?? (CancelRedacting = new CommandBase(mCancelRedacting)); }
        }

        CommandBase SaveRedacting;

        public CommandBase pSaveRedacting
        {
            get { return SaveRedacting ?? (SaveRedacting = new CommandBase(mSaveRedacting)); }
        }

        CommandBase SaveCreatingNew;

        public CommandBase pSaveCreatingNew
        {
            get { return SaveCreatingNew ?? (SaveCreatingNew = new CommandBase(mSaveCreatingNew)); }
        }

        CommandBase CancelCreatingNew;

        public CommandBase pCancelCreatingNew
        {
            get { return CancelCreatingNew ?? (CancelCreatingNew = new CommandBase(mCancelCreatingNew)); }
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
        public void mBackTechOrd()
        {
            if (Model.pSelOsn!=null)
            {
                Osn i = null;
                int k = Model.pListOsn.IndexOf(Model.pListOsn.FirstOrDefault(r => r.draftOsnastID == Model.pSelOsn.draftOsnastID)) - 1;
                if (k > Model.pListOsn.Count || k < 0) return;
                i = Model.pListOsn[k];
                if (i != null)
                {
                    //View.DataGridOsn.ScrollIntoView(i);
                    Model.pSelOsn = i;
                }
                Model.LoadProd();
            }
        }
        public void mNextTechOrd()
        {
            if (Model.pSelOsn != null)
            {
                Osn i = null;
                int k = Model.pListOsn.IndexOf(Model.pListOsn.FirstOrDefault(r => r.draftOsnastID == Model.pSelOsn.draftOsnastID)) + 1;
                if (k > Model.pListOsn.Count || k < 0) return;
                i = Model.pListOsn[k];
                if (i != null)
                {
                    //View.DataGridOsn.ScrollIntoView(i);
                    Model.pSelOsn = i;
                }
                Model.LoadProd();
            }
        }
        public void mClearFindOsn()
        {
            Model.pSearchOsn = "";
            Model.pSelFilter = "Всё";
            Model.pdateSearchBefore = DateTime.Now;
            Model.pdateSearchAfter = null;
            Model.pListOsnNonFilters = Model.pListOsnLoaded;
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
            if (model.pSelOsn != null)
                View.DataGridOsn.ScrollIntoView(model.pSelOsn);
            Model.OpenApprove();
        }
        public void OpenCreateDraft(Osnsv _osn)
        {
            Model.OpenCreateNew(_osn);
        }
        public void mOpenCreate()
        {
            Model.OpenCreate();
        }
        public void mFinalApprove()
        {
            Model.FinalApproveOrd();
        }
        public void mOpenRedactingMode()
        {
            Model.OpenRedactingMode();
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

        public void mOpenAuxililaryOsnastW()
        {

            string name = typeof(OpenAuxililaryOsnast).Name;
            int index = VMLocator.CreateViewModel(name);

            ((OpenAuxililaryOsnast)VMLocator.VMs[name][index].view).Loaded += ((vmOpenAuxililaryOsnast)VMLocator.VMs[name][index]).viewLoaded;
            ((OpenAuxililaryOsnast)VMLocator.VMs[name][index].view).Unloaded += (obj, args) => VMLocator.Clean((string)(((dynamic)obj).Uid));
            VMLocator.VMs[name][index].model.WindowMain = this;

            VMLocator.VMs[name][index].view.Owner = View;
            VMLocator.VMs[name][index].view.ShowDialog();
        }

        public void mOpenSparePartW()
        {

            string name = typeof(OpenSparePartOsnast).Name;
            int index = VMLocator.CreateViewModel(name);

            ((OpenSparePartOsnast)VMLocator.VMs[name][index].view).Loaded += ((vmOpenSparePartOsnast)VMLocator.VMs[name][index]).viewLoaded;
            ((OpenSparePartOsnast)VMLocator.VMs[name][index].view).Unloaded += (obj, args) => VMLocator.Clean((string)(((dynamic)obj).Uid));
            VMLocator.VMs[name][index].model.WindowMain = this;
            VMLocator.VMs[name][index].view.Owner = View;
            VMLocator.VMs[name][index].view.ShowDialog();
        }

        public void mOpenCompoundProductW()
        {

            string name = typeof(OpenCompoundProduct).Name;
            int index = VMLocator.CreateViewModel(name);

            ((OpenCompoundProduct)VMLocator.VMs[name][index].view).Loaded += ((vmOpenCompoundProduct)VMLocator.VMs[name][index]).viewLoaded;
            ((OpenCompoundProduct)VMLocator.VMs[name][index].view).Unloaded += (obj, args) => VMLocator.Clean((string)(((dynamic)obj).Uid));
            VMLocator.VMs[name][index].model.WindowMain = this;
            VMLocator.VMs[name][index].view.Owner = View;
            VMLocator.VMs[name][index].view.ShowDialog();
        }

        public void mOpenFinOrderW()
        {

            string name = typeof(OpenFinOrder).Name;
            int index = VMLocator.CreateViewModel(name);

            ((OpenFinOrder)VMLocator.VMs[name][index].view).Loaded += ((vmOpenFinOrder)VMLocator.VMs[name][index]).viewLoaded;
            ((OpenFinOrder)VMLocator.VMs[name][index].view).Unloaded += (obj, args) => VMLocator.Clean((string)(((dynamic)obj).Uid));
            VMLocator.VMs[name][index].model.WindowMain = this;
            VMLocator.VMs[name][index].view.Owner = View;
            VMLocator.VMs[name][index].view.ShowDialog();
        }

        public void mOpenCheckOldOsn()
        {
            if (Model.pSelOsn == null) return;
            string name = typeof(CheckOldOsn).Name;
            int index = VMLocator.CreateViewModel(name);

            ((CheckOldOsn)VMLocator.VMs[name][index].view).Loaded += ((vmCheckOldOsn)VMLocator.VMs[name][index]).viewLoaded;
            ((CheckOldOsn)VMLocator.VMs[name][index].view).Unloaded += (obj, args) => VMLocator.Clean((string)(((dynamic)obj).Uid));

            VMLocator.VMs[name][index].model.WindowMain = this;

            VMLocator.VMs[name][index].view.Owner = View;
            VMLocator.VMs[name][index].model.LoadOsn();
            VMLocator.VMs[name][index].view.ShowDialog();
        }

        public void mDoubleClickOsn()
        {
            Model.OpenCreate();
        }

        public void mOpenChooseUsage()
        {

            string name = typeof(ChooseUsage).Name;
            int index = VMLocator.CreateViewModel(name);

            ((ChooseUsage)VMLocator.VMs[name][index].view).Loaded += ((vmChooseUsage)VMLocator.VMs[name][index]).viewLoaded;
            ((ChooseUsage)VMLocator.VMs[name][index].view).Unloaded += (obj, args) => VMLocator.Clean((string)(((dynamic)obj).Uid));
            VMLocator.VMs[name][index].view.Owner = View;
            VMLocator.VMs[name][index].view.ShowDialog();
        }
        public void mSetUsageGeneral()
        {
            if (Model.pSelOsn != null)
            {
                Model.ChangeUsage("Общее применение");
            }
        }
        public void mSetUsageGeneralType()
        {
            string name = typeof(ChooseUsage).Name;
            int index = VMLocator.CreateViewModel(name);

            ((ChooseUsage)VMLocator.VMs[name][index].view).Loaded += ((vmChooseUsage)VMLocator.VMs[name][index]).viewLoaded;
            ((ChooseUsage)VMLocator.VMs[name][index].view).Unloaded += (obj, args) => VMLocator.Clean((string)(((dynamic)obj).Uid));
            VMLocator.VMs[name][index].model.pIsOpenUsageGeneral = true;
            VMLocator.VMs[name][index].model.WindowMain = this;
            //VMLocator.VMs[name][index].model.LoadListTypeProduct();
            VMLocator.VMs[name][index].view.Owner = View;
            VMLocator.VMs[name][index].view.ShowDialog();
            //mOpenChooseUsage(0);
        }
        public void mSetUsage()
        {
            string name = typeof(ChooseUsage).Name;
            int index = VMLocator.CreateViewModel(name);

            ((ChooseUsage)VMLocator.VMs[name][index].view).Loaded += ((vmChooseUsage)VMLocator.VMs[name][index]).viewLoaded;
            ((ChooseUsage)VMLocator.VMs[name][index].view).Unloaded += (obj, args) => VMLocator.Clean((string)(((dynamic)obj).Uid));
            VMLocator.VMs[name][index].model.pIsOpenUsageProduct = true;
            VMLocator.VMs[name][index].model.WindowMain = this;
            //VMLocator.VMs[name][index].model.LoadListProduct();
            VMLocator.VMs[name][index].view.Owner = View;
            VMLocator.VMs[name][index].view.ShowDialog();
            //mOpenChooseUsage(1);
        }

        public void mSaveRedacting()
        {
            Model.db.SaveChanges();
            Model.OpenCreate();
        }
        public void mCancelRedacting()
        {
            Model.LoadBackupOsn();
            Model.OpenCreate();
        }
        public void mSaveCreatingNew()
        {
            Model.AddNewOsnDB();
            Model.OpenApprove();
        }
        public void mCancelCreatingNew()
        {
            Model.OpenApprove();
        }
        #endregion
    }
} 
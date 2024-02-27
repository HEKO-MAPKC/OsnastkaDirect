using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OsnastkaDirect.Models
{
    class Osn
    {
        public int draftOsnastID { get; set; }
        public decimal? draftOsn { get; set; }

        public string nameOsn { get; set; }
        public decimal? draftGrid { get; set; }
        public string nameGrid { get; set; }
        public string nameDraft { get; set; }
        public string nameRes { get; set; }

        public string workshop { get; set; }
        public decimal nOrdPrev { get; set; }
        public decimal? nOrd { get; set; }
        public string reason { get; set; }
        public string addition { get; set; }
        public decimal? amount { get; set; }
        public DateTime? dateWho { get; set; }
        public DateTime? dateFact { get; set; }
        public DateTime? datePlan { get; set; }
        public string who { get; set; }
        public string returnRes { get; set; }
        public decimal? draft { get; set; }
        public decimal? draftRes { get; set; }
        public string storeroom { get; set; }
        public string usage { get; set; }
        public decimal? ord700 { get; set; }
        public decimal? num700 { get; set; }
        public decimal? ordOsn { get; set; }
        public decimal? numOsn { get; set; }
        public decimal? workPlace { get; set; }
        public decimal? operation { get; set; }
        public int id_os_pro { get; set; }
        public int id_prod { get; set; }
        public string characterOrd { get; set; }
        public DateTime? date700 { get; set; }
        public DateTime? dateNeed { get; set; }
        public string annTab { get; set; }
        public string operationName { get; set; }
        public string workPlaceName { get; set; }
        public string zak_1 { get; set; }
        public DateTime? dateBoss { get; set; }
        public string boss { get; set; }

        public DateTime? dtSrok { get; set; }
        public DateTime? dtIzg { get; set; }
        public DateTime? dtOk { get; set; }

        public bool? atConst { get; set; }
        public bool? accepted { get; set; }
        public bool? returned { get; set; }
        public string fioConst { get; set; }
        public DateTime? dateAtConstructor { get; set; }
        //l
        public int  WorkshopID { get; set; }
        public bool dtSrokIsNull
        {
            get {
                if (dtSrok.Equals(null))
                    return true;
                else
                    return false;
            }
        }
        public bool dtIzgIsNull
        {
            get
            {
                if (dtIzg.Equals(null))
                    return true;
                else
                    return false;
            }
        }
        public bool backFromConst
        {
            get
            {
                if (dtOk.Equals(null) && fioConst != "" && fioConst != null && fioConst[0] != ' ')
                    return true;
                else
                    return false;
            }
        }
        public DateTime? getDate
        {
            get 
            {
                return dateWho.Value.Date;
            }
        }
        public bool IsButtonReturnBackVis
        {
            get
            {
                if (dtIzgIsNull == true && returned == false && atConst == false && (nOrd == null || nOrd == 0 || (dtOk == null && fioConst != null && fioConst != "" && fioConst != " ")))
                    return true;
                else
                    return false;
            }
        }
        public bool IsButtonSendToKOVis
        {
            get
            {
                if (dtIzgIsNull== true && (returned == null || returned==false) && (atConst == null || atConst ==false) && dateAtConstructor==null && dtSrok !=null)
                    return true;
                else
                    return false;
            }
        }
        public bool IsButtonApprovalVis
        {
            get
            {
                if (returned == false && atConst == false && (nOrd == null || nOrd == 0))
                    return true;
                else
                    return false;
            }
        }
        public bool IsButtonApproveVis
        {
            get
            {
                //if (returned == null || atConst==null) return false;//TODO фиксить
                if (dtIzgIsNull == true && (returned == null || returned == false) && (atConst == null || atConst == false) && (nOrd==null|| nOrd == 0)) 
                    return true;
                else
                    return false;
            }
        }
        public bool IsButtonFinalApproveVis
        {
            get
            {
                if ((nOrd == null || nOrd == 0 || (dtOk == null && fioConst != null && fioConst != "" && fioConst != " ")))
                    return true;
                else
                    return false;
            }
        }
        public bool IsButtonDissApproveVis
        {
            get
            {
                //if (atConst == null) return true; //TODO фиксить
                if (dtIzgIsNull == true && (atConst == null || atConst == false))
                    return true;
                else
                    return false;
            }
        }
        public bool IsButtonRedacteVis
        {
            get
            {
                if (dtIzgIsNull == true && atConst == false && (nOrd == null || nOrd == 0 || (dtOk==null && fioConst!=null && fioConst != "" && fioConst != " ")))
                    return true;
                else
                    return false;
            }
        }
        public bool IsButtonAnnulVis
        {
            get
            {
                if (dtIzgIsNull == true)
                    return true;
                else
                    return false;
            }
        }
        public Osn ()
        {
        }
        public void Copy(Osn i)
        {
            draftOsnastID = i.draftOsnastID;
            draftOsn = i.draftOsn;
            workshop = i.workshop;
            nOrdPrev = i.nOrdPrev;
            nOrd = i.nOrd;
            reason = i.reason;
            addition = i.addition;
            amount = i.amount;
            dateWho = i.dateWho;
            who = i.who;
            returnRes = i.returnRes;
            draft = i.draft;
            draftRes = i.draftRes;
            storeroom = i.storeroom;
            nameGrid = nameGrid;
            draftGrid = i.draftGrid;
            nameDraft = i.nameDraft;
            nameOsn = i.nameOsn;
            nameRes = i.nameRes;



            usage = i.usage;
            dtSrok = i.dtSrok;
            dtIzg = i.dtIzg;
            dtOk = i.dtOk;
            atConst = i.atConst;
            accepted = i.accepted;
            returned = i.returned;
            fioConst = i.fioConst;

            // ord700 = list7 != null ? list7.zakaz : 0,
            // num700 = list7 != null ? list7.nom : 0,
            ordOsn = i.ordOsn;
            numOsn = i.numOsn;
            workPlace = i.workPlace;
            operation = i.operation;
            characterOrd = i.characterOrd;//i.TechOrder.TypeOsnast,
                                          //i.TechOrder.ReferenceInformation.ReferenceName,
            dateNeed = i.dateNeed;

            //  date700 = list8.data,
            annTab = i.annTab;
            datePlan = i.datePlan;
            dateFact = i.dateFact;

            workPlaceName = i.workPlaceName;
            operationName = i.operationName;

            zak_1 = i.zak_1;
            // id_os_pro = i.os_pro_id.Value, //ПОМЕНЯТЬ ПОТОМ НА НЕ NULL
            // id_prod = i.prod_id.Value,
            dateBoss = i.dateBoss;
            boss = i.boss;
            dateAtConstructor = i.dateAtConstructor;
        }
        public Osn(Osn i)
        {
            Copy(i);
        }
        //public bool IsDraftOsnastIDNull()
        //{
        //    if (draftOsnastID == null)
        //    return false;
        //}
    }
}

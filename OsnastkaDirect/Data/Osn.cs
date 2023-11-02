using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OsnastkaDirect.Models
{
    class Osn
    {
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
                if (dtOk.Equals(null) && fioConst != " " && fioConst[0] != ' ' && fioConst != null)
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
    }
}

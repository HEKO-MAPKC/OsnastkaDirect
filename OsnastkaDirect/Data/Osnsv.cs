using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OsnastkaDirect.Data
{
    internal class Osnsv
    {
        public decimal? draftOsn { get; set; }
        public string draftOsnName { get; set; }
        public decimal? draftPiece { get; set; }
        public string draftPieceName { get; set; }
        public decimal? draft { get; set; }
        public string draftName { get; set; }
        public decimal? workPlace { get; set; }
        public decimal? codeOperation { get; set; }
        //public override bool Equals(object obj) //TODO 
        //{
        //    if (obj is Osnsv person) return draft == person.draft;
        //    return false;
        //}
        //public override int GetHashCode() => draft.GetHashCode();
    }
}

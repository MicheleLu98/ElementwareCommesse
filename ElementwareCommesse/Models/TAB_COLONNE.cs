//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElementwareCommesse.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TAB_COLONNE
    {
        public int IDSez { get; set; }
        public int IDColonna { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
    
        public virtual TAB_SEZ TAB_SEZ { get; set; }
    }
}
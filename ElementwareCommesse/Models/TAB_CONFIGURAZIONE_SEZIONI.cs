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
    
    public partial class TAB_CONFIGURAZIONE_SEZIONI
    {
        public int IDConfigurazione { get; set; }
        public int IDSez { get; set; }
        public string NomeSezione { get; set; }
    
        public virtual TAB_CONFIGURAZIONE TAB_CONFIGURAZIONE { get; set; }
        public virtual TAB_SEZ TAB_SEZ { get; set; }
    }
}

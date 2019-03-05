using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElementwareCommesse.Models
{



    [MetadataType(typeof(MetaDataColonne))]
    public partial class TAB_COLONNE
    {

        public virtual string IDSezioneProp { get; set; }

        public virtual SelectList IDlist { get; set; }


    }



    public class MetaDataColonne
    {
        [DataType("int")]
        [Display(Name = "Sezione")]
        public int IDSez { get; set; }

        public int IDColonna { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "è richiesto un nome")]
        [Display(Name = "Nome Colonna")]
        public string Nome { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "è richiesto un tipo")]
        [Display(Name = "Tipo Dato Colonna")]
        public string Tipo { get; set; }

        public virtual TAB_SEZ TAB_SEZ { get; set; }
    }
}
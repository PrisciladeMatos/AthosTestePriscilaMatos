using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AthosTestePriscilaMatos.Models
{
    public class Condominio
    {

        public int Id { get; set; }
        [Required]
        public string Nome_Condominio { get; set; }
        public string Administradora { get; set; }
        public string Tp_Usuario { get; set; }

    }
}
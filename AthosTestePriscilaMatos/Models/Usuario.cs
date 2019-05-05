using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AthosTestePriscilaMatos.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Condominio { get; set; }
        public string Tp_Usuario { get; set; }

    }
}
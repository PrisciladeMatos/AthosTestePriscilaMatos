using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AthosTestePriscilaMatos.Models
{
    public class Administradora
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        
    }
}
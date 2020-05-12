using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarlinAPI.Models
{
    public partial class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
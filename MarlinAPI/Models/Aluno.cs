using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarlinAPI.Models
{
    public partial class Aluno
    {
        public int Matricula { get; set; }
        public string numTurma { get; set; }
        public string Nome { get; set; }
    }
}
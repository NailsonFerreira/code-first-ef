using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstEF.Models
{
    public class Faculdade
    {
        public int FaculdadeID { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
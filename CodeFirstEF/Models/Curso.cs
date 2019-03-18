using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstEF.Models
{
    public class Curso
    {
        public int CursoID { get; set; }
        public string Nome { get; set; }
        public int FaculdadeID { get; set; }
        [ForeignKey("FaculdadeID")]

        public virtual Faculdade Faculdade { get; set; }
    }
}
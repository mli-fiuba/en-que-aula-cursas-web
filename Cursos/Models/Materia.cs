using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cursos.Models
{
    public class Materia
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string CodigoDepartamento
        {
            get
            {
                if (Codigo.StartsWith("8"))
                {
                    return ("6" + Codigo.Substring(1,1));
                }
                else if (Codigo.StartsWith("9"))
                {
                    return ("7" + Codigo.Substring(1,1));
                }
                else
                    return Codigo.Substring(0, 2);
            }
        }
    }
}
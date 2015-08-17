using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cursos.Models
{
    public class Curso
    {
        public string Codigo { get; set; }
        public string CodigoMateria { get; set; }
        public string CodigoDepartamento
        {
            get
            {
                if (CodigoMateria.StartsWith("8"))
                {
                    return ("6" + CodigoMateria.Substring(1, 1));
                }
                else if (CodigoMateria.StartsWith("9"))
                {
                    return ("7" + CodigoMateria.Substring(1, 1));
                }
                else
                    return CodigoMateria.Substring(0, 2);
            }
        }
        public string Docentes { get; set; }
        public string Vacantes { get; set; }
        public string Carreras { get; set; }
        public List<Horario> Horarios { get; set; }
    }
}
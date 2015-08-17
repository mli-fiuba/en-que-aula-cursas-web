using Cursos.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cursos.Controllers
{
    public class CursosController : Controller
    {
        DataContext db = new DataContext();

        public ActionResult Lista(string codigoMateria)
        {
            var cursos = db.Cursos(codigoMateria);
            var materia = db.Materias(codigoMateria).First();
            var departamento = db.Departamentos().Where( x => x.Codigo == materia.CodigoDepartamento).Single();

            ViewBag.Materia = materia;
            ViewBag.Departamento = departamento;

            return PartialView("_Cursos", cursos);
        }

        public ActionResult Detalle(string codigoMateria, string codigoCurso)
        {
            var curso = db.Cursos(codigoMateria).Where(x => x.Codigo == codigoCurso).Single();
            var materia = db.Materias(codigoMateria).First();
            var departamento = db.Departamentos().Where(x => x.Codigo == materia.CodigoDepartamento).Single();

            ViewBag.Materia = materia;
            ViewBag.Departamento = departamento;

            return PartialView("_Curso", curso);
        }
	}
}
using Cursos.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cursos.Controllers
{
    public class APIController : Controller
    {
        DataContext db = new DataContext();

        public JsonResult Departamentos()
        {
            return Json(db.Departamentos(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Materias(string departamento)
        {
            return Json(db.Materias(departamento), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Cursos(string departamento, string materia)
        {
            return Json(db.Cursos(departamento + materia), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Curso(string departamento, string materia, string curso)
        {
            return Json(db.Cursos(departamento + materia).Where( x => x.Codigo.ToUpper()==curso.ToUpper()).First(), JsonRequestBehavior.AllowGet);
        }
	}
}
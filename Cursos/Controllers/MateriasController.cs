using Cursos.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cursos.Controllers
{
    public class MateriasController : Controller
    {
        DataContext db = new DataContext();

        public ActionResult Lista(string codigoDepartamento)
        {
            var departamento = db.Departamentos().Where(x => x.Codigo == codigoDepartamento).Single();

            ViewBag.Departamento = departamento; 
            
            return PartialView("_Materias", db.Materias(codigoDepartamento));
        }
	}
}
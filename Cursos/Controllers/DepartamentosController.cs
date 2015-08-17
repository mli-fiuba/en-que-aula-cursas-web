using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cursos.DataAccessLayer;

namespace Cursos.Controllers
{
    public class DepartamentosController : Controller
    {
        DataContext db = new DataContext();

        public PartialViewResult Lista()
        {
            return PartialView("_Departamentos", db.Departamentos());
        }
	}
}
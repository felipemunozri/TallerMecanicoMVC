using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using UTIL;
namespace Taller_Mecanico_MVC.UTIL
{
    public class BaseController : Controller
    {
        private Control _control = new Control();

        public Control control()
        {
            return _control;
        }

    }
}
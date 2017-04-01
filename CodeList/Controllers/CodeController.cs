using CodeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeList.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCodeList()
        {
            var repo = new CodeRepo();
            var list = repo.GetAll();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(Code code)
        {
            try
            {
                var repo = new CodeRepo();
                repo.Add(code);

                return Json("ok");
            }
            catch(Exception ex)
            {
                return Json("Error: " + ex.Message);
            }
        }

        
        [HttpPost]
        public JsonResult Delete(string recordID)
        {
            try
            {
                var repo = new CodeRepo();
                repo.Delete(recordID);

                return Json("ok");
            }
            catch (Exception ex)
            {
                return Json("Error: " + ex.Message);
            }
        }



    }
}

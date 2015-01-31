using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Saxo.Flow;

namespace Saxo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetItem(string key)
        {
            var flow = new SaxoFlow();
            var flowResult = (SaxoFlowResult) await flow.Execute(new RequestInfo(key));

            var result = flowResult.IsValidResult ? new JavaScriptSerializer().Serialize(flowResult) : String.Empty;

            return Json(result);
        }

        public JsonResult UpadeItem(string key)
        {

            return Json("updeted");
        }

    }
}
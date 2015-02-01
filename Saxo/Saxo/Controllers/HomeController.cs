using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Saxo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetItems(string[] keys)
        {
            var manager = new Manager();
            var books = await manager.GetBooks((keys));

            var result = new JavaScriptSerializer().Serialize(books);
            return Json(result);
        }

        public async Task<JsonResult> GetItem(string key)
        {
            var manager = new Manager();
            var book = await manager.GetBook((key));

            var result = new JavaScriptSerializer().Serialize(book);
            return Json(result);
        }

        public JsonResult UpadeItem(string key, bool value)
        {
            try
            {
                var manager = new Manager();
                manager.UpdateBookChecked(key, value);
            }
            catch (Exception)
            {
                return Json("Failed");
            }  

            return Json("Updated successfully");
        }


    }
}
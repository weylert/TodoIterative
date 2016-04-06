using System.Web.Mvc;

namespace ToDoListIterative.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
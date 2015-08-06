
namespace Poller.Presentation.Controllers
{
    using System.Web.Mvc;
    using CustomAttributes;

    public class SecretGateController : Controller
    {
        [AuthorizeAccessIfUserHasRole(Role.Admin)]
        public ActionResult Index()
        {
            return View();
        }
    }
}
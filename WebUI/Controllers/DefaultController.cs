using Microsoft.AspNetCore.Mvc;
using WebUI.ChainOfResponsibilityPattern;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class DefaultController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasurer=new Treassurer();
            Employee managerAssistant=new ManagerAssistant();
            Employee manager = new Manager();
            Employee areaDirector=new AreaDirector();

            treasurer.SetNextApprover(managerAssistant);
            managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirector);

            treasurer.ProcessRequest(model);
            return View();
        }
    }
}

using MeetingProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingProject.Controllers
{
    public class MeetingController : Controller
    {
        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult ToplantiForm() 
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

    }
}

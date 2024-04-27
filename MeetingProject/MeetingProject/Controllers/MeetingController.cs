using MeetingProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingProject.Controllers
{
    public class MeetingController : Controller
    {
      
        [HttpGet]
        public IActionResult ToplantiForm() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveForm(UserRepostory _userRepostory)
        {
            if(ModelState.IsValid) { 
            Repository.CreateUser(_userRepostory);
            ViewBag.KatilimSayisi = Repository.AllUser.Where(i => i.Status == true).Count();
            return View("Index" , _userRepostory);
            }
            else
            {
                return View("ToplantiForm" , _userRepostory);
            }
        }

        public IActionResult List()
        {
            var UserList = Repository.AllUser;
            return View(UserList);
        }

        [HttpGet]
        public IActionResult Detail(int Id) 
        { 
            return View(Repository.GetUser(Id));
        }
    }
}

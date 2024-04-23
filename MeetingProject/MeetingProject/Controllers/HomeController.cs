using MeetingProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MeetingProject.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            var MeetingDB = new MeetingDB()
            {
                Id = 1,
                Toplanti_yeri = "Konya",
                KatilimciSayisi = 10,
                Date = new DateTime(2024,02,02,20,30,0)

            };


            return View(MeetingDB);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}

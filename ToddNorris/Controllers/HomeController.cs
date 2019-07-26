using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToddNorris.Models;

namespace ToddNorris.Controllers
{
    public class HomeController : Controller
    {
        private const string SessionFirstName = "_firstName";
        private const string SessionLastName = "_lastName";
        
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public JsonResult Get()
        {
            var firstName = HttpContext.Session.GetString(SessionFirstName);
            var lastName = HttpContext.Session.GetString(SessionLastName);
            
            var jokeObject =  new Models.ToddNorris(firstName, lastName);
            return Json(jokeObject.Get());
        }

        [HttpPost]
        public JsonResult Post()
        {
            string body;
            using (var reader = new StreamReader(Request.Body))
            {
                body = reader.ReadToEnd();
                var nameObject = JsonConvert.DeserializeObject<NameObject>(body);
                HttpContext.Session.SetString(SessionFirstName, nameObject.FirstName);
                HttpContext.Session.SetString(SessionLastName, nameObject.LastName);
            }
            return Json(body);
        }
    }
}
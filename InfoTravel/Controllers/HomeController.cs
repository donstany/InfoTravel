using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InfoTravel.Models;
using InfoTravel.Classes.Application;
using BusDataAccess.Database;
using BusDataAccess;
using FlightDataAccess.Database;
using FlightDataAccess;
using InfoTravel.Classes.Factories;

namespace InfoTravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        PersonManager personManager;
        public HomeController(ILogger<HomeController> logger, 
                              IFactory factory
                              )
        {
            _logger = logger;
             
            personManager = new PersonManager(factory);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(personManager.GetPersons());
        }


        [HttpGet]
        public IActionResult NewPerson()
        { 

            return View();
        }

        [HttpPost]
        public IActionResult NewPerson(PersonVM person)
        {
            personManager.AddNewPerson(person);

            return  RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

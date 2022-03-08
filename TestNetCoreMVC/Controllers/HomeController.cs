using DataAccess.DbContexts;
using DataAccess.Models;
using DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestNetCoreMVC.Models;

namespace TestNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICityRepository _cityRepository;
        private readonly IConfiguration _configuration;

        public HomeController(ICityRepository cityRepository, IConfiguration configuration)
        {
            _cityRepository = cityRepository;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var cities = _cityRepository.GetCities();
            return View(cities);
        }

        public IActionResult DeleteCity(int id)
        {
            if (_cityRepository.DeleteCity(id))
            {
                TempData["message"] = "City was deleted.";
            }
            else
            {
                TempData["message"] = "Error.";
            }
               
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCity(int id, City city)
        {
            if (_cityRepository.UpdateCity(id, city))
            {
                TempData["message"] = "City was updated.";
            }
            else
            {
                TempData["message"] = "Error.";
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddCity(City city)
        {
            if (_cityRepository.AddCity(city)) 
            {
                TempData["message"] = "City was added.";
            }
            else
            {
                TempData["message"] = "Error.";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult[] GetDetailCityWithWeather(int id)
        {
            var city = _cityRepository.GetCity(id);
            var weatherService = new WeatherService(_configuration);
            var weather = weatherService.GetWeatherByCity(city.Name);
            var result = new JsonResult[2];
            result[0] = Json(city);
            result[1] = Json(weather);
            return result;
        }

        [HttpPost]
        public JsonResult GetDetailCity(int id)
        {
            var city = _cityRepository.GetCity(id);
            return Json(city);
        }
    }
}

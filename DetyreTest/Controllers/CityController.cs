using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DetyreTest.Interface;
using DetyreTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DetyreTest.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;
        private readonly IRepository<Country> _countryRepository;

        public CityController(ICityRepository cityRepository,
                              IRepository<Country> countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _cityRepository.GetAllCities();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            var countries = _countryRepository.GetAll().Where(t => t.IsDeleted == false);
            ViewBag.countries = new SelectList(countries, "Id", "Name");
            if (id == 0)
            {
                var model = new City();
                return View(model);
            }
            else
            {
                var model = await _cityRepository.GetCityById(id);
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(City model)
        {
            if (model.Id == 0)
            {
                model.InsertedDate = DateTime.Now;
                _cityRepository.Add(model);
                await _cityRepository.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                model.ModifiedDate = DateTime.Now;
                await _cityRepository.Update(model);

                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _cityRepository.GetById(id);
            _cityRepository.Remove(model);
            await _cityRepository.SaveChanges();
            return RedirectToAction("Index"); ;
        }

    }
}

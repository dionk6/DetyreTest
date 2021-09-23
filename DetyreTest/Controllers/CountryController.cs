using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DetyreTest.Interface;
using DetyreTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetyreTest.Controllers
{
    public class CountryController : Controller
    {
        private readonly IRepository<Country> _countryRepository;

        public CountryController(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public IActionResult Index()
        {
            var model = _countryRepository.GetAll().Where(t => t.IsDeleted == false).ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            if (id == 0)
            {
                var model = new Country();
                return View(model);
            }
            else
            {
                var model = await _countryRepository.GetById(id);
               return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(Country model)
        {
            if (model.Id == 0)
            {
                model.InsertedDate = DateTime.Now;
                model.IsDeleted = false;
                _countryRepository.Add(model);
                await _countryRepository.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                model.ModifiedDate = DateTime.Now;
                await _countryRepository.Update(model);

                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _countryRepository.GetById(id);
            model.IsDeleted = true;
            await _countryRepository.Update(model);
            return RedirectToAction("Index"); ;
        }
    }
}

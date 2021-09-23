using DetyreTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetyreTest.Interface
{
    public interface ICityRepository : IRepository<City>
    {
        public Task<City> GetCityById(int id);
        public Task<List<City>> GetAllCities();
    }
}

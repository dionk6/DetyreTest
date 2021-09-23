using DetyreTest.Interface;
using DetyreTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetyreTest.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private DetyreTestDbContext _dbContext { get { return _context as DetyreTestDbContext; } }
        public CityRepository(DetyreTestDbContext dbContext) : base(dbContext)
        {
        }

        public Task<City> GetCityById(int id)
        {
            var city = _dbContext.Cities.Include(t => t.Country).Where(t => t.Id == id).FirstAsync();
            return city;
        }

        public Task<List<City>> GetAllCities()
        {
            var model = _dbContext.Cities.Include(t => t.Country).ToListAsync();
            return model;
        }
    }
}

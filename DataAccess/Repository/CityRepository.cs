using DataAccess.DbContexts;
using DataAccess.Models;
using DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _dbContext;
        public CityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool DeleteCity(int id)
        {
            var city = _dbContext.Cities.Where(x => x.Id == id).FirstOrDefault();

            if (city == null)
            {
                return false;
            }
            else
            {
                _dbContext.Cities.Remove(city);
                _dbContext.SaveChanges();
                return true;
            }
        }

        public List<City> GetCities()
        {
            var cities = _dbContext.Cities.ToList();
            return cities;
        }

        public City GetCity(int id)
        {
            var city = _dbContext.Cities.Where(x => x.Id == id).FirstOrDefault();
            return city;
        }

        public bool UpdateCity(int id, City city)
        {
            var cityUpdated = _dbContext.Cities.Where(x => x.Id == id).FirstOrDefault();

            if (cityUpdated != null)
            {
                cityUpdated.Name = city.Name;
                cityUpdated.Population = city.Population;
                _dbContext.Cities.Update(cityUpdated);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddCity(City city)
        {
            if (string.IsNullOrEmpty(city.Name) || city.Population == 0)
            {
                return false;
            }

            _dbContext.Add(city);
            _dbContext.SaveChanges();
            return true;
        }

        public bool AddCity(string name, int population)
        {
            var city = new City { Name = name, Population = population };
            return AddCity(city);
        }
    }
}

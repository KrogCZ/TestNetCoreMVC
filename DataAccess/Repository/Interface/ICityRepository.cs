using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interface
{
    public interface ICityRepository
    {
        /// <summary>
        /// get all cities
        /// </summary>
        /// <returns>list of all cities</returns>
        List<City> GetCities();

        /// <summary>
        /// add city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>city added</returns>
        bool AddCity(City city);

        /// <summary>
        /// add city
        /// </summary>
        /// <param name="name"></param>
        /// <param name="population"></param>
        /// <returns>city added</returns>
        bool AddCity(string name, int population);

        /// <summary>
        /// get city by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>city</returns>
        City GetCity(int id);

        /// <summary>
        /// update city by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="city"></param>
        /// <returns>city updated</returns>
        bool UpdateCity(int id, City city);

        /// <summary>
        /// delete city by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>city deleted</returns>
        bool DeleteCity(int id);
    }
}

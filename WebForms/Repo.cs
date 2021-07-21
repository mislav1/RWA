using Microsoft.ApplicationBlocks.Data;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace WebForms
{
    public class Repo
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        internal static IList<User> GetUsers()
        {
            var tblusers = SqlHelper.ExecuteDataset(cs, "GetAllUsers").Tables[0];

            IList<User> users = new List<User>();

            foreach (DataRow row in tblusers.Rows)
            {
                User user = new User
                {
                    Id = (int)row["IDKupac"],
                    FirstName = row["Ime"].ToString(),
                    LastName = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Telefon"].ToString(),
                    CityId = (int)row["GradID"],
                };


                users.Add(user);
            }

            return users;
        }

        internal static IList<Country> GetCountries()
        {
            var tblcountries = SqlHelper.ExecuteDataset(cs, "GetAllCountries").Tables[0];

            IList<Country> countries = new List<Country>();

            foreach (DataRow row in tblcountries.Rows)
            {
                Country country = new Country
                {
                    Id = (int)row["IDDrzava"],
                    Name = row["Naziv"].ToString()
                };


                countries.Add(country);
            }

            return countries;
        }

        internal static IList<City> GetCitiesByCountry(int countryId)
        {
            var tblQuestions = SqlHelper.ExecuteDataset(cs, "GetCitiesByCountry", countryId).Tables[0];

            IList<City> cities = new List<City>();

            foreach (DataRow row in tblQuestions.Rows)
            {
                City city = new City
                {
                    Id = (int)row["IDGrad"],
                    Name = row["Naziv"].ToString(),
                    CountryId = (int)row["DrzavaID"]
                };


                cities.Add(city);
            }

            return cities;
        }

        internal static IList<City> GetAllCities()
        {
            var tblQuestions = SqlHelper.ExecuteDataset(cs, "getAllCities").Tables[0];

            IList<City> cities = new List<City>();

            foreach (DataRow row in tblQuestions.Rows)
            {
                City city = new City
                {
                    Id = (int)row["IDGrad"],
                    Name = row["Naziv"].ToString(),
                    CountryId = (int)row["DrzavaID"]
                };


                cities.Add(city);
            }

            return cities;
        }

        internal static IList<User> GetUsersFromCity(int skip, int rows, int cityId, string orderBy)
        {
            var tblUsers = SqlHelper.ExecuteDataset(cs, "getUsersFromCity", skip, rows, cityId).Tables[0];

            IList<User> users = new List<User>();

            foreach (DataRow row in tblUsers.Rows)
            {
                User user = new User
                {
                    Id = (int)row["IDKupac"],
                    FirstName = row["Ime"].ToString(),
                    LastName = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Telefon"].ToString(),
                    CityId = (int)row["GradID"],
                };


                users.Add(user);
            }

            switch (orderBy)
            {
                case "Ime (uzlazno)":
                    return users.OrderBy(u => u.FirstName).ToList();
                case "Ime (silazno)":
                    return users.OrderByDescending(u => u.FirstName).ToList();
                case "Prezime (uzlazno)":
                    return users.OrderBy(u => u.LastName).ToList();
                case "Prezime (silazno)":
                    return users.OrderByDescending(u => u.LastName).ToList();
                case "Id (uzlazno)":
                    return users.OrderBy(u => u.Id).ToList();
                case "Id (silazno)":
                    return users.OrderByDescending(u => u.Id).ToList();
                default:
                    return users;
            }
        }

        internal static IList<User> GetUserById(int userId)
        {
            var tblUsers = SqlHelper.ExecuteDataset(cs, "getUserById", userId).Tables[0];

            IList<User> users = new List<User>();

            foreach (DataRow row in tblUsers.Rows)
            {
                User user = new User
                {
                    Id = (int)row["IDKupac"],
                    FirstName = row["Ime"].ToString(),
                    LastName = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Telefon"].ToString(),
                    CityId = (int)row["GradID"]
                };


                users.Add(user);
            }

            return users;
        }

        internal static void UpdateUserById(int userId, string firstName, string lastName, string email, string phone, int cityId)
        {
            SqlHelper.ExecuteNonQuery(
                cs,
                "updateUserById",
                userId,
                firstName,
                lastName,
                email,
                phone,
                cityId
            );
        }


    }
}
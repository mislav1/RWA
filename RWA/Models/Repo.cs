using Microsoft.ApplicationBlocks.Data;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace RWA.Models
{
    public class Repo
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        internal static IList<Product> GetProducts()
        {
            var tblproducts = SqlHelper.ExecuteDataset(cs, "GetAllProducts").Tables[0];

            IList<Product> products = new List<Product>();

            foreach (DataRow row in tblproducts.Rows)
            {
                Product product = new Product
                {
                    Id = (int)row["IDKupac"],
                    Name = row["Naziv"].ToString(),
                    ProductNumber = row["BrojProizvoda"].ToString(),
                    Color = row["Boja"].ToString(),
                    MinimumAmount = row["MinimalnaKolicinaNaSkladistu"].ToString(),
                    SubCategoryId = (int)row["PotkategorijaID"],
                    PriceWithoutPDV = (double)row["CijenaBezPDV"]
                };


                products.Add(product);
            }

            return products;
        }

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
    }
}
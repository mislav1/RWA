using Microsoft.ApplicationBlocks.Data;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Repo
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        internal static List<User> GetUsers()
        {
            var tblusers = SqlHelper.ExecuteDataset(cs, "GetAllUsers").Tables[0];

            List<User> users = new List<User>();

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
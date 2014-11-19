using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace DAL
{
    public class CountryProvider
    {
        private Db db;
        public CountryProvider()
        {
            db = new Db();
        }
        public List<Country> Gets()
        {
            return db.Countries.ToList();
        }
        public Country Get(int id)
        {
            return db.Countries.FirstOrDefault(u => u.CountryId == id);
        }
        public int Insert(Country use)
        {
            db.Countries.Add(use);
            return db.SaveChanges();
        }
        public int Update(Country Country)
        {
            db.Entry(Country).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            Country Country = db.Countries.Find(id);
            db.Countries.Remove(Country);
            return db.SaveChanges();
        }
    }
}

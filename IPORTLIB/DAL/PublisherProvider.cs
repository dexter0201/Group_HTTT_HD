using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace DAL
{
    public class PublisherProvider
    {
        private Db db;
        public PublisherProvider()
        {
            db = new Db();
        }
        public List<Publisher> Gets()
        {
            return db.Publishers.ToList();
        }
        public Publisher Get(int id)
        {
            return db.Publishers.FirstOrDefault(u => u.PublisherId == id);
        }
        public int Insert(Publisher use)
        {
            db.Publishers.Add(use);
            return db.SaveChanges();
        }
        public int Update(Publisher Publisher)
        {
            db.Entry(Publisher).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            Publisher Publisher = db.Publishers.Find(id);
            db.Publishers.Remove(Publisher);
            return db.SaveChanges();
        }
    }
}

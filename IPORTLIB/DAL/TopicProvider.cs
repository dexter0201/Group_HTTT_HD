using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace DAL
{
    public class TopicProvider
    {
        private Db db;
        public TopicProvider()
        {
            db = new Db();
        }
        public List<Topic> Gets()
        {
            return db.Topics.ToList();
        }
        public Topic Get(int id)
        {
            return db.Topics.FirstOrDefault(u => u.TopicId == id);
        }
        public int Insert(Topic use)
        {
            db.Topics.Add(use);
            return db.SaveChanges();
        }
        public int Update(Topic Topic)
        {
            db.Entry(Topic).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            Topic Topic = db.Topics.Find(id);
            db.Topics.Remove(Topic);
            return db.SaveChanges();
        }
    }
}

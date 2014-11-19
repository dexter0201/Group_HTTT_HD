using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace DAL
{
    public class LanguageProvider
    {
        private Db db;
        public LanguageProvider()
        {
            db = new Db();
        }
        public List<Language> Gets()
        {
            return db.Languages.ToList();
        }
        public Language Get(int id)
        {
            return db.Languages.FirstOrDefault(u => u.LanguageId == id);
        }
        public int Insert(Language use)
        {
            db.Languages.Add(use);
            return db.SaveChanges();
        }
        public int Update(Language Language)
        {
            db.Entry(Language).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            Language Language = db.Languages.Find(id);
            db.Languages.Remove(Language);
            return db.SaveChanges();
        }
    }
}

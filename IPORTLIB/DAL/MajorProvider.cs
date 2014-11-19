using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace DAL
{
    public class MajorProvider
    {
        private Db db;
        public MajorProvider()
        {
            db = new Db();
        }
        public List<Major> Gets()
        {
            return db.Majors.ToList();
        }
        public Major Get(int id)
        {
            return db.Majors.FirstOrDefault(u => u.MajorId == id);
        }
        public int Insert(Major use)
        {
            db.Majors.Add(use);
            return db.SaveChanges();
        }
        public int Update(Major Major)
        {
            db.Entry(Major).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            Major Major = db.Majors.Find(id);
            db.Majors.Remove(Major);
            return db.SaveChanges();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class AuthorProvider
    {
        private Db db;
        public AuthorProvider()
        {
            db = new Db();
        }
        public List<Author> Gets()
        {
            return db.Authors.ToList();
        }
        public Author Get(int id)
        {
            return db.Authors.FirstOrDefault(u => u.AuthorId == id);
        }
        public int Insert(Author use)
        {
            db.Authors.Add(use);
            return db.SaveChanges();
        }
        public int Update(Author Author)
        {
            db.Entry(Author).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            Author Author = db.Authors.Find(id);
            db.Authors.Remove(Author);
            return db.SaveChanges();
        }
    }
}

using System.Collections.Generic;
using DTO;
using System.Linq;

namespace DAL
{
    public class CategoryProvider
    {
        private Db db;
        public CategoryProvider()
        {
            db = new Db();
        }
        public List<Category> Gets()
        {
            return db.Categories.ToList();
        }
        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(u => u.CategoryId == id);
        }
        public int Insert(Category use)
        {
            db.Categories.Add(use);
            return db.SaveChanges();
        }
        public int Update(Category Category)
        {
            db.Entry(Category).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            Category Category = db.Categories.Find(id);
            db.Categories.Remove(Category);
            return db.SaveChanges();
        }
    }
}

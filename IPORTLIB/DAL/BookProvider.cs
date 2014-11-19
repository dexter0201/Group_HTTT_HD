using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class BookProvider
    {
        private Db db;
        public BookProvider()
        {
            db = new Db();
        }
        public List<Book> Gets()
        {
            return db.Books.ToList();
        }
        public Book Get(int id)
        {
            return db.Books.FirstOrDefault(u => u.BookId == id);
        }
        public int Insert(Book use)
        {
            db.Books.Add(use);
            return db.SaveChanges();
        }
        public int Update(Book Book)
        {
            db.Entry(Book).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            Book Book = db.Books.Find(id);
            db.Books.Remove(Book);
            return db.SaveChanges();
        }
    }
}

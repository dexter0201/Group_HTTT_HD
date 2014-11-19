using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace DAL
{
    public class SupplierProvider
    {
        private Db db;
        public SupplierProvider()
        {
            db = new Db();
        }
        public List<Supplier> Gets()
        {
            return db.Suppliers.ToList();
        }
        public Supplier Get(int id)
        {
            return db.Suppliers.FirstOrDefault(u => u.SupplierId == id);
        }
        public int Insert(Supplier use)
        {
            db.Suppliers.Add(use);
            return db.SaveChanges();
        }
        public int Update(Supplier Supplier)
        {
            db.Entry(Supplier).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            Supplier Supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(Supplier);
            return db.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace DAL
{
    public class LoanProvider
    {
        private Db db;
        public LoanProvider()
        {
            db = new Db();
        }
        public List<Loan> Gets()
        {
            return db.Loans.ToList();
        }
        public Loan Get(int id)
        {
            return db.Loans.FirstOrDefault(u => u.LoanId == id);
        }
        public int Insert(Loan use)
        {
            db.Loans.Add(use);
            return db.SaveChanges();
        }
        public int Update(Loan Loan)
        {
            db.Entry(Loan).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            Loan Loan = db.Loans.Find(id);
            db.Loans.Remove(Loan);
            return db.SaveChanges();
        }
    }
}

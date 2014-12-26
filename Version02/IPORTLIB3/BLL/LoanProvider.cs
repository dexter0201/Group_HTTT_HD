using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class LoanProvider
	{
		ILoanRepository repository;
		internal LoanProvider(ILoanRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Loan> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Loan Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Loan obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Loan obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}
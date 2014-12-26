using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class LoanDetailProvider
	{
		ILoanDetailRepository repository;
		internal LoanDetailProvider(ILoanDetailRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<LoanDetail> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public LoanDetail Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(LoanDetail obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(LoanDetail obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}
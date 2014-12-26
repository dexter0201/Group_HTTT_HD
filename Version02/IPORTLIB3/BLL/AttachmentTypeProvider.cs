using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class AttachmentTypeProvider
	{
		IAttachmentTypeRepository repository;
		internal AttachmentTypeProvider(IAttachmentTypeRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<AttachmentType> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public AttachmentType Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(AttachmentType obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(AttachmentType obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}
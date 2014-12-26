using IDAL;
using System.Collections.Generic;
using DTO;
namespace BLL
{
	public class AttachmentProvider
	{
		IAttachmentRepository repository;
		internal AttachmentProvider(IAttachmentRepository repository)
		{
			this.repository = repository;
		}
		public IEnumerable<Attachment> Gets(object obj = null)
		{
			return repository.Gets(obj);
		}
		public Attachment Get(object id)
		{
			return repository.Get(id);
		}
		public bool Update(Attachment obj)
		{
			return repository.Update(obj);
		}
		public bool Insert(Attachment obj)
		{
			return repository.Insert(obj);
		}
		public bool Delete(object id)
		{
			return repository.Delete(id);
		}
	}
}
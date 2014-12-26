using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class AttachmentTypeApiController : ApiController
    {
        public IEnumerable<AttachmentType> Get()
        {
            return AppProvider.AttachmentType.Gets(0);
        }
        public AttachmentType Get(int id)
        {
            return AppProvider.AttachmentType.Get(id);
        }
        public HttpResponseMessage Post(AttachmentType attachmentType)
        {
            AppProvider.AttachmentType.Insert(attachmentType);
            var respose = Request.CreateResponse<AttachmentType>(HttpStatusCode.Created, attachmentType);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/AttachmentTypeApi/" + attachmentType.AttachmentTypeId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public AttachmentType Delete(int id)
        {
            AttachmentType attachmentType = AppProvider.AttachmentType.Get(id);
            if (attachmentType == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.AttachmentType.Delete(id);
            return attachmentType;
        }
    }
}
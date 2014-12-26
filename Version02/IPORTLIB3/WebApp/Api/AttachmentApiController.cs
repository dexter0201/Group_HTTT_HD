using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class AttachmentApiController : ApiController
    {
        public IEnumerable<Attachment> Get()
        {
            return AppProvider.Attachment.Gets(0);
        }
        public Attachment Get(int id)
        {
            return AppProvider.Attachment.Get(id);
        }
        public HttpResponseMessage Post(Attachment attachment)
        {
            AppProvider.Attachment.Insert(attachment);
            var respose = Request.CreateResponse<Attachment>(HttpStatusCode.Created, attachment);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/AttachmentApi/" + attachment.AttachmentId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Attachment Delete(int id)
        {
            Attachment attachment = AppProvider.Attachment.Get(id);
            if (attachment == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Attachment.Delete(id);
            return attachment;
        }
    }
}
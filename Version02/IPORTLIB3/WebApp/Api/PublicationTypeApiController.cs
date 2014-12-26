using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class PublicationTypeApiController : ApiController
    {
        public IEnumerable<PublicationType> Get()
        {
            return AppProvider.PublicationType.Gets(0);
        }
        public PublicationType Get(int id)
        {
            return AppProvider.PublicationType.Get(id);
        }
        public HttpResponseMessage Post(PublicationType publicationType)
        {
            AppProvider.PublicationType.Insert(publicationType);
            var respose = Request.CreateResponse<PublicationType>(HttpStatusCode.Created, publicationType);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/PublicationTypeApi/" + publicationType.PublicationTypeId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public PublicationType Delete(int id)
        {
            PublicationType publicationType = AppProvider.PublicationType.Get(id);
            if (publicationType == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.PublicationType.Delete(id);
            return publicationType;
        }
    }
}
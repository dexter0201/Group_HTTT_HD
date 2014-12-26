using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class PublicationApiController : ApiController
    {
        public IEnumerable<Publication> Get()
        {
            return AppProvider.Publication.Gets(0);
        }
        public Publication Get(int id)
        {
            return AppProvider.Publication.Get(id);
        }
        public HttpResponseMessage Post(Publication publication)
        {
            AppProvider.Publication.Insert(publication);
            var respose = Request.CreateResponse<Publication>(HttpStatusCode.Created, publication);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/PublicationApi/" + publication.PublicationId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Publication Delete(int id)
        {
            Publication publication = AppProvider.Publication.Get(id);
            if (publication == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Publication.Delete(id);
            return publication;
        }
    }
}
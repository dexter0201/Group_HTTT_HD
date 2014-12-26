using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class PublisherApiController : ApiController
    {
        public IEnumerable<Publisher> Get()
        {
            return AppProvider.Publisher.Gets(0);
        }
        public Publisher Get(int id)
        {
            return AppProvider.Publisher.Get(id);
        }
        public HttpResponseMessage Post(Publisher publisher)
        {
            AppProvider.Publisher.Insert(publisher);
            var respose = Request.CreateResponse<Publisher>(HttpStatusCode.Created, publisher);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/PublisherApi/" + publisher.PublisherId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Publisher Delete(int id)
        {
            Publisher publisher = AppProvider.Publisher.Get(id);
            if (publisher == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Publisher.Delete(id);
            return publisher;
        }
    }
}
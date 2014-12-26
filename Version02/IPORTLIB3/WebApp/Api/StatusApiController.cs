using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class StatusApiController : ApiController
    {
        public IEnumerable<Status> Get()
        {
            return AppProvider.Status.Gets(0);
        }
        public Status Get(int id)
        {
            return AppProvider.Status.Get(id);
        }
        public HttpResponseMessage Post(Status status)
        {
            AppProvider.Status.Insert(status);
            var respose = Request.CreateResponse<Status>(HttpStatusCode.Created, status);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/StatusApi/" + status.StatusId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Status Delete(int id)
        {
            Status status = AppProvider.Status.Get(id);
            if (status == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Status.Delete(id);
            return status;
        }
    }
}
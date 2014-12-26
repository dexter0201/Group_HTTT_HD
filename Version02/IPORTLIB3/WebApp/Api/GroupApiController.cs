using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class GroupApiController : ApiController
    {
        public IEnumerable<Group> Get()
        {
            return AppProvider.Group.Gets(0);
        }
        public Group Get(int id)
        {
            return AppProvider.Group.Get(id);
        }
        public HttpResponseMessage Post(Group group)
        {
            AppProvider.Group.Insert(group);
            var respose = Request.CreateResponse<Group>(HttpStatusCode.Created, group);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/GroupApi/" + group.GroupId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Group Delete(int id)
        {
            Group group = AppProvider.Group.Get(id);
            if (group == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Group.Delete(id);
            return group;
        }
    }
}
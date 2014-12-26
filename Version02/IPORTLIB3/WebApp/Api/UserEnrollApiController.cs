using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class UserEnrollApiController : ApiController
    {
        public IEnumerable<UserEnroll> Get()
        {
            return AppProvider.UserEnroll.Gets(0);
        }
        public UserEnroll Get(int id)
        {
            return AppProvider.UserEnroll.Get(id);
        }
        public HttpResponseMessage Post(UserEnroll userEnroll)
        {
            AppProvider.UserEnroll.Insert(userEnroll);
            var respose = Request.CreateResponse<UserEnroll>(HttpStatusCode.Created, userEnroll);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/UserEnrollApi/" + userEnroll.UserEnrollId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public UserEnroll Delete(int id)
        {
            UserEnroll userEnroll = AppProvider.UserEnroll.Get(id);
            if (userEnroll == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.UserEnroll.Delete(id);
            return userEnroll;
        }
    }
}
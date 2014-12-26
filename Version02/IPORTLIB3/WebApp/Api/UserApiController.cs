using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class UserApiController : ApiController
    {
        public IEnumerable<User> Get()
        {
            return AppProvider.User.Gets(0);
        }
        public User Get(int id)
        {
            return AppProvider.User.Get(id);
        }
        public HttpResponseMessage Post(User user)
        {
            AppProvider.User.Insert(user);
            var respose = Request.CreateResponse<User>(HttpStatusCode.Created, user);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/UserApi/" + user.UserId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public User Delete(int id)
        {
            User user = AppProvider.User.Get(id);
            if (user == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.User.Delete(id);
            return user;
        }
    }
}
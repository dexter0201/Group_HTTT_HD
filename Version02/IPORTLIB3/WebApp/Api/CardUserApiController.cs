using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class CardUserApiController : ApiController
    {
        public IEnumerable<CardUser> Get()
        {
            return AppProvider.CardUser.Gets(0);
        }
        public CardUser Get(int id)
        {
            return AppProvider.CardUser.Get(id);
        }
        public HttpResponseMessage Post(CardUser cardUser)
        {
            AppProvider.CardUser.Insert(cardUser);
            var respose = Request.CreateResponse<CardUser>(HttpStatusCode.Created, cardUser);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/CardUserApi/" + cardUser.CardUserId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public CardUser Delete(int id)
        {
            CardUser cardUser = AppProvider.CardUser.Get(id);
            if (cardUser == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.CardUser.Delete(id);
            return cardUser;
        }
    }
}
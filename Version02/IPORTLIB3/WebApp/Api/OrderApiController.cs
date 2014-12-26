using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class OrderApiController : ApiController
    {
        public IEnumerable<Order> Get()
        {
            return AppProvider.Order.Gets(0);
        }
        public Order Get(int id)
        {
            return AppProvider.Order.Get(id);
        }
        public HttpResponseMessage Post(Order order)
        {
            AppProvider.Order.Insert(order);
            var respose = Request.CreateResponse<Order>(HttpStatusCode.Created, order);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/OrderApi/" + order.OrderId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Order Delete(int id)
        {
            Order order = AppProvider.Order.Get(id);
            if (order == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Order.Delete(id);
            return order;
        }
    }
}
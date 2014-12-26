using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class OrderDetailApiController : ApiController
    {
        public IEnumerable<OrderDetail> Get()
        {
            return AppProvider.OrderDetail.Gets(0);
        }
        public OrderDetail Get(int id)
        {
            return AppProvider.OrderDetail.Get(id);
        }
        public HttpResponseMessage Post(OrderDetail orderDetail)
        {
            AppProvider.OrderDetail.Insert(orderDetail);
            var respose = Request.CreateResponse<OrderDetail>(HttpStatusCode.Created, orderDetail);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/OrderDetailApi/" + orderDetail.OrderDetailId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public OrderDetail Delete(int id)
        {
            OrderDetail orderDetail = AppProvider.OrderDetail.Get(id);
            if (orderDetail == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.OrderDetail.Delete(id);
            return orderDetail;
        }
    }
}
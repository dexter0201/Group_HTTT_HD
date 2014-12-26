using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class SupplierApiController : ApiController
    {
        public IEnumerable<Supplier> Get()
        {
            return AppProvider.Supplier.Gets(0);
        }
        public Supplier Get(int id)
        {
            return AppProvider.Supplier.Get(id);
        }
        public HttpResponseMessage Post(Supplier supplier)
        {
            AppProvider.Supplier.Insert(supplier);
            var respose = Request.CreateResponse<Supplier>(HttpStatusCode.Created, supplier);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/SupplierApi/" + supplier.SupplierId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Supplier Delete(int id)
        {
            Supplier supplier = AppProvider.Supplier.Get(id);
            if (supplier == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Supplier.Delete(id);
            return supplier;
        }
    }
}
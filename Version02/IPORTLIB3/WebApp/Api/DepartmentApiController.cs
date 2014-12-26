using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class DepartmentApiController : ApiController
    {
        public IEnumerable<Department> Get()
        {
            return AppProvider.Department.Gets(0);
        }
        public Department Get(int id)
        {
            return AppProvider.Department.Get(id);
        }
        public HttpResponseMessage Post(Department department)
        {
            AppProvider.Department.Insert(department);
            var respose = Request.CreateResponse<Department>(HttpStatusCode.Created, department);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/DepartmentApi/" + department.DepartmentId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Department Delete(int id)
        {
            Department department = AppProvider.Department.Get(id);
            if (department == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Department.Delete(id);
            return department;
        }
    }
}
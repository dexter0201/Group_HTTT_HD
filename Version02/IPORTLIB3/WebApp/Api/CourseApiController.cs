using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class CourseApiController : ApiController
    {
        public IEnumerable<Course> Get()
        {
            return AppProvider.Course.Gets(0);
        }
        public Course Get(int id)
        {
            return AppProvider.Course.Get(id);
        }
        public HttpResponseMessage Post(Course course)
        {
            AppProvider.Course.Insert(course);
            var respose = Request.CreateResponse<Course>(HttpStatusCode.Created, course);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/CourseApi/" + course.CourseId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Course Delete(int id)
        {
            Course course = AppProvider.Course.Get(id);
            if (course == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Course.Delete(id);
            return course;
        }
    }
}
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class TopicApiController : ApiController
    {
        public IEnumerable<Topic> Get()
        {
            return AppProvider.Topic.Gets(0);
        }
        public Topic Get(int id)
        {
            return AppProvider.Topic.Get(id);
        }
        public HttpResponseMessage Post(Topic topic)
        {
            AppProvider.Topic.Insert(topic);
            var respose = Request.CreateResponse<Topic>(HttpStatusCode.Created, topic);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/TopicApi/" + topic.TopicId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Topic Delete(int id)
        {
            Topic topic = AppProvider.Topic.Get(id);
            if (topic == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Topic.Delete(id);
            return topic;
        }
    }
}
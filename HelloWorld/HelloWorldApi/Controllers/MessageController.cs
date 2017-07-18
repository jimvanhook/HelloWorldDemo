using HelloWorld.Data;
using System.Web.Http;

namespace HelloWorldApi.Controllers
{
    public class MessageController : ApiController
    {
        static readonly IApiMessageRepository apiMessageRepository = new ApiMessageRepository();

        // GET api/message
        public ApiMessage GetMessage()
        {
            return apiMessageRepository.GetAMessage();
        }
    }
}

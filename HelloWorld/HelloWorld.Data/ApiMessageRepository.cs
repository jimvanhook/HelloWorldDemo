using System.Collections.Generic;
using System.Linq;

namespace HelloWorld.Data
{
    public class ApiMessageRepository : IApiMessageRepository
    {
        private List<ApiMessage> apiMessages = new List<ApiMessage>();

        public ApiMessageRepository()
        {
            apiMessages.Add(new ApiMessage { Text = "Hello World!" });
        }

        public ApiMessage GetAMessage()
        {
            return apiMessages.FirstOrDefault(p => p.Text != null);
        }
    }
}

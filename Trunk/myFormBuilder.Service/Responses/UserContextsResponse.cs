using System.Collections.Generic;

namespace myFormBuilder.Service.Responses
{
    public class UserContextsResponse : IResponse
    {
        public IDictionary<string, string> Contexts { get; set; }
    }
}

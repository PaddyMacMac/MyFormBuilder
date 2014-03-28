using System.Collections.Generic;

namespace myFormBuilder.Service.Responses
{
    public class LoadContextExamsResponse : IResponse
    {
        public IDictionary<string, string> ExmaNamesAndIds { get; set; }
    }
}

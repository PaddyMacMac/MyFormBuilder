using myFormBuilder.Model.POCO;

namespace myFormBuilder.Service.Responses
{
    public class LoginResponse : IResponse
    {
        public string ContextId { get; set; }
        public string Context { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public bool Authenticated { get; set; }

        public LoginResponse(User user)
        {
            ContextId = user.ContextId;
            Context = user.Context;
            UserName = user.UserName;
            UserId = user.UserId;
            Authenticated = user.Authenticated;
        }
    }
}

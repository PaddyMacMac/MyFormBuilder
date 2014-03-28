using myFormBuilder.Presenter.POCO;
using myFormBuilder.Service.Responses;

namespace myFormBuilder.Presenter.Factories
{
    public class UserFactory
    {
        public static User GetUserFromResponse(LoginResponse loginReponse)
        {
            return new User
            {
                Context = loginReponse.Context,
                ContextId = loginReponse.ContextId,
                UserId = loginReponse.UserId,
                UserName = loginReponse.UserName,
                Authenticated = loginReponse.Authenticated
            };
        }
    }
}

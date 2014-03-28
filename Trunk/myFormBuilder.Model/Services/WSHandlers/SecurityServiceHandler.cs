using System.Collections.Generic;
using myFormBuilder.Model.Enums;
using myFormBuilder.Model.POCO;

namespace myFormBuilder.Model.Services.WSHandlers
{
    public class SecurityServiceHandler : IServiceHandler
    {
        private const int TODAY = 0;

        public User AuthenticateUser(string user, string pass)
        {
            using (var service = new SecurityService.SecurityService())
            {
                bool isExpiringSoon = false;
                int daysToExpiry = TODAY;
                var securityUser = service.AuthenticateUser(user, pass, out isExpiringSoon, out daysToExpiry);
                service.user = securityUser;
                SetGlobalAuthenticatedUser(securityUser);
            }

            return User.Instance;
        }

        public IDictionary<string, string> GetUserContexts(string userId)
        {
            var contextIds = new Dictionary<string, string>();
            using (var service = new SecurityService.SecurityService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.SecurityService) as SecurityService.User;
                var contexts = service.GetUserContexts();

                foreach (var context in contexts)
                {
                    contextIds.Add(context.contextId, context.contextName);
                }
            }
            return contextIds;
        }

        private void SetGlobalAuthenticatedUser(SecurityService.User securityUser)
        {
            User.Instance.Authenticated = true;
            User.Instance.UserName = securityUser.userName;
            User.Instance.UserId = securityUser.userId;
            User.Instance.ContextId = securityUser.currentContextId;
        }

        public void SetCurrentContext(string contextName, string contextId)
        {
            User.Instance.Context = contextName;
            User.Instance.ContextId = contextId;
        }

        public string GetCurrentContext()
        {
            return User.Instance.Context;
        }
    }
}

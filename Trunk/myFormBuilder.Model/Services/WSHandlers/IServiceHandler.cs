using myFormBuilder.Model.Enums;
using myFormBuilder.Model.Factories;

namespace myFormBuilder.Model.Services.WSHandlers
{
    public abstract class IServiceHandler
    {
        protected object GetServiceUser(ServiceTypesEnum userType)
        {
            return UserFactory.GetUser(userType);
        }
    }
}

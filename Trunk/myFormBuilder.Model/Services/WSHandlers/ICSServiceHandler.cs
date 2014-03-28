using myFormBuilder.Model.Enums;

namespace myFormBuilder.Model.Services.WSHandlers
{
    public class ICSServiceHandler : IServiceHandler
    {
        public string GetDefaultICSRootId()
        {
            using (var service = new ICSService.ICSService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.ICSService) as ICSService.User;
                return service.GetICSNodeRootFolder();
            }
        }
    }
}

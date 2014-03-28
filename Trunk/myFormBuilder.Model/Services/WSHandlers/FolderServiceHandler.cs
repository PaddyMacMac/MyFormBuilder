using myFormBuilder.Model.Enums;

namespace myFormBuilder.Model.Services.WSHandlers
{
    public class FolderServiceHandler : IServiceHandler
    {
        public string GetContentRootFolderLocationId()
        {
            using (var service = new FolderService.FolderService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.FolderService) as FolderService.User;
                return service.GetContentRootFolderId();
            }
        }
    }
}

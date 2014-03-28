using myFormBuilder.Model.Enums;
using myFormBuilder.Model.POCO;

namespace myFormBuilder.Model.Services.WSHandlers
{
    public class AutoGenCodeServiceHandler : IServiceHandler
    {
        private const string EXAM_FORM = "Prometric.Intelitest.ExamForm";

        public bool CheckCodeExist(string formCode)
        {
            using (var service = new AutoGenCodeWebService.AutoGenCodeWebService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.AutoGenCodeService) as AutoGenCodeWebService.User;
                return service.CheckCodeExists(EXAM_FORM, formCode, User.Instance.ContextId);
            }
        }
    }
}

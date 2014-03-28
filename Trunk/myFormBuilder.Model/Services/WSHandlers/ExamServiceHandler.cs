using System;
using System.Web.Services.Protocols;
using myFormBuilder.Model.Enums;

namespace myFormBuilder.Model.Services.WSHandlers
{
    public class ExamServiceHandler : IServiceHandler
    {
        private const string FORM_STATE_NEW = "New";

        public string SaveExamForm(string formCode, string examId, string language, string itemListId, string locationId)
        {
            using (var service = new ExamService.ExamService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.ExamService) as ExamService.User;
                var examForm = new ExamService.ExamForm()
                               {
                                    State = FORM_STATE_NEW,
                                    DefaultItemWeight = string.Empty,
                                    EstimatedDifficulty = string.Empty,
                                    FormCode = formCode,
                                    name = formCode,
                                    FormTitle = formCode,
                                    language = language,
                                    ItemListUUID = itemListId,
                                    folderId = locationId,
                                    UUID = Guid.NewGuid().ToString(),
                                    OwnerId = examId
                               };
                try
                {
                    return service.SaveExamForm(examForm).FormCode;
                }
                catch (SoapException e)
                {
                    return examForm.FormCode;
                }
            }
        }
    }
}

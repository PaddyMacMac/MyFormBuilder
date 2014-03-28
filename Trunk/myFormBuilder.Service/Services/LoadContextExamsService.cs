using System;
using myFormBuilder.DAL;
using myFormBuilder.Service.Requests;
using myFormBuilder.Service.Responses;

namespace myFormBuilder.Service.Services
{
    public class LoadContextExamsService
    {
        public LoadContextExamsResponse LoadContextExams(LoadContextExamsRequest request)
        {
            LoadContextExamsResponse loadContextExamsResponse = null;
            try
            {
                loadContextExamsResponse = new LoadContextExamsResponse()
                {
                    Error = null,
                    Success = true,
                    ExmaNamesAndIds = new ExamFacade().LoadContextExamsNamesAndIds(request.Context)
                };
            }
            catch (Exception ex)
            {
                loadContextExamsResponse = new LoadContextExamsResponse()
                {
                    Error = ex,
                    Success = false,
                };
            }
            return loadContextExamsResponse;
        }
    }
}

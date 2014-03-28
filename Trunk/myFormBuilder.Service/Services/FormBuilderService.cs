using System;
using myFormBuilder.Model.Services.Builders;
using myFormBuilder.Service.Requests;
using myFormBuilder.Service.Responses;

namespace myFormBuilder.Service.Services
{
    public class FormBuilderService
    {
        private FormBuilder _formBuilder;

        public FormBuilderService(FormBuilder formBuilder)
        {
            _formBuilder = formBuilder;
        }

        public FormBuilderService()
            : this(new FormBuilder())
        { }

        public FormFromFileResponse MakeFormFromFile(FormFromFileRequest request)
        {
            FormFromFileResponse makeFormFromFileResponse = null;
            try
            {
                makeFormFromFileResponse = new FormFromFileResponse()
                {
                    Error = null,
                    Success = true,
                    Message = _formBuilder.MakeFormFromFile(request.File, request.FileType, request.ExamCode, request.FormName)
                };
            }
            catch (Exception ex)
            {
                makeFormFromFileResponse = new FormFromFileResponse()
                {
                    Error = ex,
                    Success = false,
                };
            }
            return makeFormFromFileResponse;
        }
    }
}

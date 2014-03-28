using myFormBuilder.Service.Requests;
using myFormBuilder.View;

namespace myFormBuilder.Presenter.Factories
{
    public class FormFromFileRequestFactory
    {
        public static FormFromFileRequest GetFormFromFileRequest(IMainForm _view)
        {
            return new FormFromFileRequest()
            {
                File = _view.File,
                FileType = _view.FileType,
                ExamCode = _view.ExamCode,
                FormName = _view.FormName
            };
        }
    }
}

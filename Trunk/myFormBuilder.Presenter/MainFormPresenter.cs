using System.Collections.Generic;
using System.Linq;
using myFormBuilder.View;
using myFormBuilder.Service.Services;
using myFormBuilder.Service.Requests;
using myFormBuilder.Presenter.Factories;

namespace myFormBuilder.Presenter
{
    public class MainFormPresenter : IPresenter
    {
        private SecurityService _securityService;
        private IDictionary<string, string> _contextNamesAndIds;
        private IMainForm _view;

        public MainFormPresenter(SecurityService securityService, IMainForm view)
        {
            _securityService = securityService;
            _view = view;
        }

        public MainFormPresenter(IMainForm view)
            : this(new SecurityService(), view)
        {
        }

        public IDictionary<string, string> LoadUserContexts()
        {
            var request = new UserContextsRequest()
            {
                UserId = _view.UserId
            };

            var response = _securityService.LoadUserContexts(request);

            if (response.Success)
            {
                _contextNamesAndIds = response.Contexts;
                return _contextNamesAndIds;
            }
            else
            {
                throw response.Error;
            }
        }

        public IDictionary<string, string> LoadContextExams()
        {
            var request = new LoadContextExamsRequest()
            {
                Context = _securityService.GetCurrentContext()
            };

            var response = new LoadContextExamsService().LoadContextExams(request);

            if (response.Success)
            {
                return response.ExmaNamesAndIds;
            }
            else
            {
                throw response.Error;
            }
        }

        public void SetCurrentContext()
        {
            var request = new SetCurrentContextRequest()
            {
                ContextName = _view.CurrentContext,
                ContextId = GetIDFromName(_contextNamesAndIds, _view.CurrentContext)
            };

            _securityService.SetCurrentContext(request);
        }

        public string MakeFormFromFile()
        {
            var request = FormFromFileRequestFactory.GetFormFromFileRequest(_view);
            var response = new FormBuilderService().MakeFormFromFile(request);

            if (response.Success)
            {
                return response.Message;
            }
            else
            {
                throw response.Error;
            }
        }

        private string GetIDFromName(IDictionary<string, string> dic, string value)
        {
            return dic.Where(p => p.Value == value).Select(p => p.Key).FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using myFormBuilder.Model.POCO;
using myFormBuilder.Model.Utils;
using myFormBuilder.Model.Services.Readers;
using myFormBuilder.Model.Services.WSHandlers;

namespace myFormBuilder.Model.Services.Builders
{
    public class FormBuilder : IBuilder
    {
        private const string XML = "xml";
        private const string EXCEL = "excel";
        private const string ENGLISH = "EN";

        public string MakeFormFromFile(string file, string fileType, string examCode, string formName)
        {
            string message = string.Empty;
            var examId = new SearchServiceHandler().GetExamIdFromExamCode(examCode);

            if (fileType.ToLower().Equals(XML))
            {
                message = MakeFormFromXML(file, examId, formName, GetFolderLocationId());
            }
            else if (fileType.ToLower().Equals(EXCEL))
            {
                message = MakeFormsFromExcel(file, examId, GetFolderLocationId());
            }
            return message;
        }

        private string MakeFormFromXML(string file, string examId, string formName, string folderLocationId)
        {
            if (!new AutoGenCodeServiceHandler().CheckCodeExist(formName))
            {
                var masterCodes = new XMLReader().GetFormBuildInfoFromFile(file);
                formName = new ExamServiceHandler().SaveExamForm(formName, examId, LanguageMapper.GetLanguage(ENGLISH), GetItemListId(masterCodes), folderLocationId);
                return string.Format("Form with Form Code: {0} created and added to Intelitest...", formName);
            }
            throw new Exception(string.Format("Unable able to create Form with Form Code: {0}, as code already exists.", formName));
        }

        private string MakeFormsFromExcel(string file, string examId, string folderLocationId)
        {
            IList<FormContents> formCotents = new ExcelReader().GetFormBuildInfoFromFile(file);

            foreach (var formContent in formCotents)
            {
                var formCode = formContent.FormCode;
                var itemListId = GetItemListId(formContent.MasterCodes);

                if (!new AutoGenCodeServiceHandler().CheckCodeExist(formCode))
                {
                    new ExamServiceHandler().SaveExamForm(formContent.FormCode, examId, formContent.Language, itemListId, folderLocationId);
                    continue;
                }
                throw new Exception(string.Format("Unable able to create Form with Form Code: {0}, as code already exists.", formCode));

            }
            return "Forms created from Excel added to Intelitest...";
        }

        private IDictionary<string, ItemService.Item> GetItemIds(IList<string> masterCodes)
        {
            return new ItemServiceHandler().LoadItems(new SearchServiceHandler().GetItemIdsFromMasterCodes(masterCodes));
        }

        private string GetFolderLocationId()
        {
            return new FolderServiceHandler().GetContentRootFolderLocationId();
        }

        private string GetItemListId(IList<string> masterCodes)
        {
            return new ListServiceHandler().SaveItemList(GetItemIds(masterCodes), GetFolderLocationId());
        }
    }
}
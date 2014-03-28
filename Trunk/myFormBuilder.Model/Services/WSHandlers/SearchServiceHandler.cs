using System;
using System.Collections.Generic;
using myFormBuilder.Model.Enums;
using myFormBuilder.Model.POCO;

namespace myFormBuilder.Model.Services.WSHandlers
{
    public class SearchServiceHandler : IServiceHandler
    {
        private const string MASTER_CODE = "MASTERCODE";
        private const string EXAM_CODE = "ExamCode";
        private const string MCQSR = "Prometric.Intelitest.ItemMCQSR";
        private const string MCQMR = "Prometric.Intelitest.ItemMCQMR";
        private const string MCMRD = "Prometric.Intelitest.ItemMCMRD";
        private const string HOT_SPOT = "Prometric.Intelitest.ItemHotSpot";
        private const string DRAG_DROP = "Prometric.Intelitest.ItemDragAndDrop";
        private const string FORM_ESSAY = "Prometric.Intelitest.ItemFreeFormEssay";
        private const string SHORT_ANSWER = "Prometric.Intelitest.ItemFreeFormShortAnswer";
        private const string EXAM = "Prometric.Intelitest.Exam";

        private const int FIRST_INDEX = 0;

        public IList<string> GetItemIdsFromMasterCodes(IList<string> masterCodes)
        {
            var itemIds = new List<string>();

            using (var service = new SearchService.SearchService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.SearchService) as SearchService.User;
                var locationId = new ICSServiceHandler().GetDefaultICSRootId();
                var emptyStringSearchList = new SearchService.StringSearch[FIRST_INDEX];
                var emptyStringStatisticList = new SearchService.Statistic[FIRST_INDEX];

                foreach (string masterCode in masterCodes)
                {
                    SearchService.SearchReference[] searchRefs = null;
                    searchRefs = service.ContentSearch(locationId,
                                                SearchService.enumSearchDepth.Deep,
                                                GetItemContentTypes(),
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                MakeMasterCodeAttribute(masterCode),
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                emptyStringStatisticList,
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                true,
                                                true
                                        );
                    try
                    {
                        itemIds.Add(searchRefs[FIRST_INDEX].value);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(string.Format("No matching Items found, please ensure Master Codes are correct and belongs to Context: {0}", User.Instance.Context));
                    }
                }
            }
            return itemIds;
        }

        public string GetExamIdFromExamCode(string examCode)
        {
            using (var service = new SearchService.SearchService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.SearchService) as SearchService.User;
                var contextContentId = new FolderServiceHandler().GetContentRootFolderLocationId();
                var emptyStringSearchList = new SearchService.StringSearch[FIRST_INDEX];
                var emptyStringStatisticList = new SearchService.Statistic[FIRST_INDEX];

                SearchService.SearchReference[] searchRefs = service.ContentSearch(contextContentId,
                                              SearchService.enumSearchDepth.Deep,
                                              GetExamContentType(),
                                              emptyStringSearchList,
                                              emptyStringSearchList,
                                              MakeExamCodeAttribute(examCode),
                                              emptyStringSearchList,
                                              emptyStringSearchList,
                                              emptyStringStatisticList,
                                              emptyStringSearchList,
                                              emptyStringSearchList,
                                              emptyStringSearchList,
                                              emptyStringSearchList,
                                              emptyStringSearchList,
                                              true,
                                              true
                                      );
                try
                {
                    return searchRefs[FIRST_INDEX].value;
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("No matching Exam found, please ensure Exam Code is correct and belongs to Context: {0}!", User.Instance.Context));
                }
            }
        }

        private string[] GetExamContentType()
        {
            var contentTypes = new List<string>();
            contentTypes.Add(EXAM);
            return contentTypes.ToArray();
        }


        private string[] GetItemContentTypes()
        {
            var contentTypes = new List<string>();
            contentTypes.Add(MCQSR);
            contentTypes.Add(MCQMR);
            contentTypes.Add(MCMRD);
            contentTypes.Add(HOT_SPOT);
            contentTypes.Add(DRAG_DROP);
            contentTypes.Add(FORM_ESSAY);
            contentTypes.Add(SHORT_ANSWER);
            return contentTypes.ToArray();
        }

        private SearchService.Attribute[] MakeMasterCodeAttribute(string masterCode)
        {
            return new SearchService.Attribute[] 
            { 
                new SearchService.Attribute
                {
                    searchType = SearchService.enumSearchType.Exact,
                    name = MASTER_CODE,
                    Value = masterCode,
                }
           };
        }

        private SearchService.Attribute[] MakeExamCodeAttribute(string examCode)
        {
            return new SearchService.Attribute[] 
            { 
                new SearchService.Attribute
                {
                    searchType = SearchService.enumSearchType.Exact,
                    name = EXAM_CODE,
                    Value = examCode,
                }
           };
        }
    }
}


using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using myFormBuilder.Model.POCO;
using myFormBuilder.Model.Utils;

namespace myFormBuilder.Model.Services.Readers
{
    public class ExcelReader : IReader<FormContents>
    {
        private const int TEST_FORM_COL = 1;
        private const int DIFFICULTY_COL = 2;
        private const string TEST_FORM = "Test form";
        //private const string AVG_DEV = "AvgDev";
        private const int FIRST_ROW = 1;
        private const int SECOND_ROW = 2;
        private const int THRID_COL = 3;
        private const int EMPTY_RANGE = 1;

        public IList<FormContents> GetFormBuildInfoFromFile(string file)
        {
            var workSheets = new Application().Workbooks.Open(file).Sheets;
            var formContents = new List<FormContents>();

            foreach (Worksheet sheet in workSheets)
            {
                var range = sheet.UsedRange;

                if (range.Count > EMPTY_RANGE)
                {
                    CheckColumnHeadings(range);

                    int rowCount = range.Rows.Count;
                    int colCount = range.Columns.Count;

                    for (int row = SECOND_ROW; row <= rowCount; row++)
                    {
                        var formContent = new FormContents()
                        {
                            Language = GetMappedLanguage(sheet.Name),
                            FormCode = range.Cells[row, TEST_FORM_COL].Value2,
                            MasterCodes = GetMasterCodes(range, row, colCount)
                        };
                        formContents.Add(formContent);
                    }
                }
            }
            return formContents;
        }

        private IList<string> GetMasterCodes(Range range, int row, int colCount)
        {
            var masterCodes = new List<string>();

            for (int column = THRID_COL; column <= colCount; column++)
            {
                var masterCode = range.Cells[row, column].Value2;

                if (!masterCodes.Contains(masterCode))
                {
                    masterCodes.Add(masterCode);
                }
            }
            return masterCodes;
        }

        private void CheckColumnHeadings(Range range)
        {
            if (!range.Cells[FIRST_ROW, TEST_FORM_COL].Value2.ToLower().Equals(TEST_FORM.ToLower()))// || !range.Cells[FIRST_ROW, DIFFICULTY_COL].Value2.ToLower().Equals(AVG_DEV.ToLower()))
            {
                throw new Exception("Please provide an Excel File with Work books containing: Test Form and Avg Dev in columns One and Two.");
            }
        }

        private string GetMappedLanguage(string languageCode)
        {
            return LanguageMapper.GetLanguage(languageCode);
        }
    }
}

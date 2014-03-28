using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace myFormBuilder.DAL
{
    public class ExamFacade : IItemBankConnection
    {
        private const string STP_EXAMNAME = "stp_getExamNameCodesForContext";

        public IDictionary<string, string> LoadContextExamsNamesAndIds(string contextName)
        {
            var cmdSelect = new SqlCommand()
            {
                CommandText = STP_EXAMNAME,
                CommandType = CommandType.StoredProcedure
            };

            var resultParam = new SqlParameter()
            {
                ParameterName = "@oResult",
                SqlDbType = SqlDbType.NVarChar,
                Size = -1,
                Direction = ParameterDirection.Output
            };
            cmdSelect.Parameters.Add(resultParam);
            cmdSelect.Parameters.AddWithValue("@contextname", contextName);

            var dataReader = ExecuteSqlCommand(cmdSelect).CreateDataReader();
            var examNamesAndIds = new Dictionary<string, string>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    var examCode = (string)dataReader["ExamCode"];
                    var examId = (string)dataReader["ExamID"];

                    if (!examNamesAndIds.ContainsKey(examId))
                    {
                        examNamesAndIds.Add(examId, examCode);
                    }
                }
                dataReader.Close();
            }
            return examNamesAndIds;
        }
    }
}


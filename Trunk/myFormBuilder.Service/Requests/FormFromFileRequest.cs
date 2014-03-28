namespace myFormBuilder.Service.Requests
{
    public class FormFromFileRequest
    {
        public string File { get; set; }
        public string FileType { get; set; }
        public string ExamCode { get; set; }
        public string FormName { get; set; }
    }
}

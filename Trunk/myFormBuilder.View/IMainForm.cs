
namespace myFormBuilder.View
{
    public interface IMainForm
    {
        string FileType { get; set; }
        string UserId { get; set; }
        string CurrentContext { get; set; }
        string File { get; set; }
        string ExamCode { get; set; }
        string FormName { get; set; }
    }
}

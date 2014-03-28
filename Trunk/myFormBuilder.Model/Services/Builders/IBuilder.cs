namespace myFormBuilder.Model.Services.Builders
{
    public interface IBuilder
    {
        string MakeFormFromFile(string file, string fileType, string examCode, string formName);
    }
}

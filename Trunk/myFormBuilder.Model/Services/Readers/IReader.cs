using System.Collections.Generic;

namespace myFormBuilder.Model.Services.Readers
{
    public interface IReader<T>
    {
        IList<T> GetFormBuildInfoFromFile(string file);
    }
}

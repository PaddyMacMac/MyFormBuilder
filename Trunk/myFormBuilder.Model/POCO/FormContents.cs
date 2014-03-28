using System.Collections.Generic;

namespace myFormBuilder.Model.POCO
{
    public class FormContents
    {
        public string FormCode { get; set; }
        public string Language { get; set; }
        public IList<string> MasterCodes { get; set; }
    }
}

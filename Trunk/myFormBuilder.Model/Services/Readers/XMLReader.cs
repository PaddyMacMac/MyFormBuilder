using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace myFormBuilder.Model.Services.Readers
{
    public class XMLReader : IReader<string>
    {
        private const string PRESENTATION = "presentation";
        private const string ITEM = "item";

        public IList<string> GetFormBuildInfoFromFile(string file)
        {
            var doc = XElement.Load(file);

            var masterCodes = from pres in doc.Descendants(PRESENTATION)
                        select pres.Attribute(ITEM).Value;

            return masterCodes.Distinct().ToList();
        }
    }
}

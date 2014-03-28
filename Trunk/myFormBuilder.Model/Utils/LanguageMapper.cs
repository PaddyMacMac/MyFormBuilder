using System.Collections.Generic;

namespace myFormBuilder.Model.Utils
{
    public sealed class LanguageMapper
    {
        private const string BULGARIAN = "89D1D22F-0DCB-4FEC-9D23-B8154AA40511";
        private const string CZECH = "56A3A9CA-A83D-490F-A47F-71A6D72F7658";
        private const string DANISH = "44E2D466-AF65-4A15-A7A8-6AA1C45BB854";
        private const string GERMAN = "4D1A9B62-DAA1-474E-944E-120816E630E4";
        private const string GREEK = "B40C512D-BFB1-41E4-9ADF-22C8D17B6F7F";
        private const string ENGLISH = "C45A235C-E6B4-4B65-99F6-3CAA4ECF8EC9";
        private const string SPANISH = "591C2DD1-DC81-4C9D-B7C2-B28C9CD8EAC1";
        private const string ESTONIAN = "DC7899A3-0037-481C-80DF-BA6FB7F8605D";
        private const string FINNISH = "C5DAE7AD-3DFE-4427-95FF-6EC0AA8F4FF9";
        private const string FRENCH = "E8C9F1FB-0C7D-4878-BE0C-F4D2E6298CB6";
        private const string HUNGARIAN = "3A7FACDE-352B-47C9-AC23-23E207DB89F6";
        private const string ITALIAN = "509DDAA0-623D-43F5-96AB-65118DF6032C";
        private const string LITHUANIAN = "833F60EF-E191-43C3-8D64-29C5477C8A30";
        private const string LATVIAN = "09C1E0FD-8A84-4B02-9C40-E334CE735BDA";
        private const string MALTESE = "7A986765-C776-41F5-9A6B-19D62AD81293";
        private const string DUTCH = "7CD3FBAC-98CD-4C8A-830E-E3B30B78CBAE";
        private const string POLISH = "EC96DBE9-D09A-4DE1-B2F1-187B279DD77F";
        private const string PORTUGUESE = "2F86D647-2EE1-4E2E-8238-2163ECF86F66";
        private const string ROMANIAN = "2720445E-7F9D-428A-BEEC-B5E140D9FD08";
        private const string SLOVAK = "1AE8480E-D8F7-4AA6-8895-C99D97888253";
        private const string SLOVENIAN = "8F61408D-7E8B-403C-ACB1-869F213942A2";
        private const string SWEDISH = "6971A5E7-F943-4815-8C22-07BCD187B50B";
        private const string UNKNOWN = "Unknown";

        private static IDictionary<string, string> _languageMappings = MapLanguages();

        public static string GetLanguage(string languageCode)
        {
            try
            {
                return _languageMappings[languageCode];
            }
            catch (KeyNotFoundException e)
            {
                return UNKNOWN;
            }
        }

        private static IDictionary<string, string> MapLanguages()
        {
            _languageMappings = new Dictionary<string, string>();
            _languageMappings.Add("BG", BULGARIAN);
            _languageMappings.Add("CS", CZECH);
            _languageMappings.Add("DA", DANISH);
            _languageMappings.Add("DE", GERMAN);
            _languageMappings.Add("EL", GREEK);
            _languageMappings.Add("EN", ENGLISH);
            _languageMappings.Add("ES", SPANISH);
            _languageMappings.Add("ET", ESTONIAN);
            _languageMappings.Add("FI", FINNISH);
            _languageMappings.Add("FR", FRENCH);
            _languageMappings.Add("HU", HUNGARIAN);
            _languageMappings.Add("IT", ITALIAN);
            _languageMappings.Add("LT", LITHUANIAN);
            _languageMappings.Add("LV", LATVIAN);
            _languageMappings.Add("MT", MALTESE);
            _languageMappings.Add("NL", DUTCH);
            _languageMappings.Add("PL", POLISH);
            _languageMappings.Add("PT", PORTUGUESE);
            _languageMappings.Add("RO", ROMANIAN);
            _languageMappings.Add("SK", SLOVAK);
            _languageMappings.Add("SL", SLOVENIAN);
            _languageMappings.Add("SV", SWEDISH);
            return _languageMappings;
        }
    }
}

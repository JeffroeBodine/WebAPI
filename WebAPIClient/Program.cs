using System;
using System.Net.Http;
using ObjectLibrary;

namespace WebAPIClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            DoShit();

            Console.Read();
        }

        static async void DoShit()
        {
            var baseAddress = new Uri(@"http://msullivan-vm/CompassDataBroker/api/");

            using (var client = new HttpClient())
            {
                var parms = new CreateDocumentParms { DocumentTypeId = (long)DocumentTypes.JeffroesDocType};
                parms.Keywords.Add(CreateKeyword(KeywordTypes.FirstName, "Johnny"));
                parms.Keywords.Add(CreateKeyword(KeywordTypes.LastName, "Northwoods"));
                parms.Keywords.Add(CreateKeyword(KeywordTypes.SSN, "111-11-1111"));
                parms.Keywords.Add(CreateKeyword(KeywordTypes.CompassNumber, "OH123000000001"));

                client.BaseAddress = baseAddress;
                var response = await client.PostAsJsonAsync("Document", parms);
            }
        }

        private static Keyword CreateKeyword(KeywordTypes keywordType, string keywordValue)
        {
            return new Keyword(new KeywordType((long)keywordType, keywordType.ToString(), typeof(string), ""), keywordValue);
        }
    }
}

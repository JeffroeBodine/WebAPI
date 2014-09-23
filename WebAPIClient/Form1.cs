using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ObjectLibrary;

namespace WebAPIClient
{
    public partial class Form1 : Form
    {
        public string BaseUrl
        {
            get { return txtBaseURL.Text; }
        }

        public Form1()
        {
            InitializeComponent();

            //SendImageSet();
        }

        private static void SendImageSet()
        {
            var putDocumentParams = new PutDocumentParams(337);

            var compassNumberKWT = new KeywordType(136, "", typeof(string), "");
            var ssnKWT = new KeywordType(103, "", typeof(string), "");
            var firstNameKWT = new KeywordType(104, "", typeof(string), "");
            var lastNameKWT = new KeywordType(105, "", typeof(string), "");

            putDocumentParams.Keywords.Add(new Keyword(compassNumberKWT, "OH123000000001"));
            putDocumentParams.Keywords.Add(new Keyword(ssnKWT, "111-11-1111"));
            putDocumentParams.Keywords.Add(new Keyword(firstNameKWT, "Jeffroe"));
            putDocumentParams.Keywords.Add(new Keyword(lastNameKWT, "Bodine"));

            var multipartContent = new MultipartFormDataContent();

            var searlizedPutDocumentMetadata = JsonConvert.SerializeObject(putDocumentParams, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            multipartContent.Add(new StringContent(searlizedPutDocumentMetadata, Encoding.UTF8, "application/json"), "PutDocumentParams");

            var counter = 1;
            foreach (var fileName in Directory.GetFiles("images"))
            {
                var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                multipartContent.Add(new StreamContent(fs), "File" + counter, Path.GetFileName(fileName));
                counter++;
            }

            var response = new HttpClient()
                .PostAsync("http://localhost/CompassDataBroker/api/Document/UploadFile", multipartContent)
                .Result;

            var responseContent = response.Content.ReadAsStringAsync().Result;
            Trace.Write(responseContent);
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        private void btnDocumentTypes_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("DocumentType").Result;

                if (response.IsSuccessStatusCode)
                {
                    var documentTypes = response.Content.ReadAsAsync<IEnumerable<DocumentType>>().Result;
                    DisplayDocumentTypes(documentTypes);
                }
            }
        }
        private void btnDocumentType_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(String.Format("DocumentType/{0}", txtDocumentTypeId.Text)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var documentType = response.Content.ReadAsAsync<DocumentType>().Result;
                    DisplayDocumentType(documentType);
                }
            }
        }

        private void btnKeywordTypes_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("KeywordType").Result;

                if (response.IsSuccessStatusCode)
                {
                    var keywordTypes = response.Content.ReadAsAsync<IEnumerable<KeywordType>>().Result;
                    DisplayKeywordTypes(keywordTypes);
                }
            }
        }
        private void btnKeywordType_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(String.Format("KeywordType/{0}", txtKeywordTypeId.Text)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var keywordType = response.Content.ReadAsAsync<KeywordType>().Result;
                    DisplayKeywordType(keywordType);
                }
            }
        }

        private void btnGetCase_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(String.Format("Case/{0}", txtCaseId.Text)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var myCase = response.Content.ReadAsAsync<Case>().Result;
                    DisplayCase(myCase);
                }
            }
        }
        private void btnGetClients_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(String.Format("Case/{0}/Client", txtCaseIdForClients.Text)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var clients = response.Content.ReadAsAsync<IEnumerable<Client>>().Result;
                    DisplayClients(clients);
                }
            }
        }

        private void DisplayCase(Case myCase)
        {
            txtResult.Clear();

            txtResult.Text += String.Format("Id: {0}, Case Number: {1}, Secondary Case Number: {2}, Program Type Id: {3}, Case Worker Id: {4}, Case Head Id: {5}{6}"
                                            , myCase.Id, myCase.CaseNumber, myCase.SecondaryCaseNumber, myCase.ProgramTypeId, myCase.CaseWorkerId, myCase.CaseHeadId, Environment.NewLine);
        }
        private void DisplayClients(IEnumerable<Client> clients)
        {
            txtResult.Clear();
            foreach (var c in clients)
            {
                txtResult.Text += String.Format("Id: {0}, SSN: {1} First Name: {2}, Last Name: {3}{4}", c.Id, c.SSN, c.FirstName, c.LastName, Environment.NewLine);
            }
        }
        private void DisplayKeywordTypes(IEnumerable<KeywordType> keywordTypes)
        {
            txtResult.Clear();
            foreach (var kwt in keywordTypes)
            {
                txtResult.Text += String.Format("Id: {0}, Name: {1}, Data Type:{2}, Default Value: {3}{4}", kwt.Id, kwt.Name, kwt.DataTypeString, kwt.DefaultValue, Environment.NewLine);
            }
        }
        private void DisplayKeywordType(KeywordType kwt)
        {
            txtResult.Clear();

            txtResult.Text += String.Format("Id: {0}, Name: {1}, Data Type:{2}, Default Value: {3}{4}", kwt.Id, kwt.Name, kwt.DataTypeString, kwt.DefaultValue, Environment.NewLine);
        }
        private void DisplayDocumentTypes(IEnumerable<DocumentType> documentTypes)
        {
            txtResult.Clear();
            foreach (var dtg in documentTypes)
            {
                txtResult.Text += String.Format("Id: {0}, Name: {1}{2}", dtg.Id, dtg.Name, Environment.NewLine);

                foreach (var dt in dtg.DocumentTypeList)
                {
                    txtResult.Text += String.Format("    Id: {0}, Name: {1}{2}", dt.Id, dt.Name, Environment.NewLine);
                }
            }
        }
        private void DisplayDocumentType(DocumentType documentType)
        {
            txtResult.Clear();

            txtResult.Text += String.Format("Id: {0}, Name: {1}{2}", documentType.Id, documentType.Name, Environment.NewLine);
        }

        private void txtResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }






    }
}

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
            var SSNKWT = new KeywordType(103, "", typeof(string), "");
            var FirstNameKWT = new KeywordType(104, "", typeof(string), "");
            var LastNameKWT = new KeywordType(105, "", typeof(string), "");

            putDocumentParams.Keywords.Add(new Keyword(compassNumberKWT, "OH123000000001"));
            putDocumentParams.Keywords.Add(new Keyword(SSNKWT, "111-11-1111"));
            putDocumentParams.Keywords.Add(new Keyword(FirstNameKWT, "Jeffroe"));
            putDocumentParams.Keywords.Add(new Keyword(LastNameKWT, "Bodine"));

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

        private void btnClearResult_Click(object sender, System.EventArgs e)
        {
            txtResult.Clear();
        }

        private void btnDocumentTypes_Click(object sender, System.EventArgs e)
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

        private void btnGetDocumentType_Click(object sender, EventArgs e)
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

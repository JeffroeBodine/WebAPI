using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ObjectLibrary;

namespace WebAPIClient
{
    public partial class frmUploadDocument : Form
    {
        public frmUploadDocument()
        {
            InitializeComponent();
        }

        private void btnFolderFinder_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog {SelectedPath = @"c:\50 2 Page Color Files\"};
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtImagesFolderPath.Text = dlg.SelectedPath;
            }
        }

        private void UploadDocument()
        {
            var putDocumentParams = new PutDocumentParams(long.Parse(txtDocumentTypeId.Text));

            var compassNumberKWT = new KeywordType(136, "", typeof(string), "");
            var ssnKWT = new KeywordType(103, "", typeof(string), "");
            var firstNameKWT = new KeywordType(104, "", typeof(string), "");
            var lastNameKWT = new KeywordType(105, "", typeof(string), "");

            putDocumentParams.Keywords.Add(new Keyword(compassNumberKWT, txtCompassNumber.Text));
            putDocumentParams.Keywords.Add(new Keyword(ssnKWT, txtSSN.Text));
            putDocumentParams.Keywords.Add(new Keyword(firstNameKWT, txtFirstName.Text));
            putDocumentParams.Keywords.Add(new Keyword(lastNameKWT, txtLastName.Text));

            var multipartContent = new MultipartFormDataContent();

            var searlizedPutDocumentMetadata = JsonConvert.SerializeObject(putDocumentParams, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            multipartContent.Add(new StringContent(searlizedPutDocumentMetadata, Encoding.UTF8, "application/json"), "PutDocumentParams");

            var sw = new Stopwatch();
            sw.Start();

            var counter = 1;
            foreach (var fileName in Directory.GetFiles(txtImagesFolderPath.Text))
            {
                var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                multipartContent.Add(new StreamContent(fs), "File" + counter, Path.GetFileName(fileName));
                counter++;
            }

            try
            {
                using (var response = new HttpClient().PostAsync("http://localhost/CompassDataBroker/api/Document/UploadFile", multipartContent).Result)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;

                    sw.Stop();

                    MessageBox.Show(String.Format("Document Id: {0} \nCompleted in {1} seconds", responseContent, sw.Elapsed.TotalSeconds));

                    Trace.Write(responseContent);
                }
            }
            catch (Exception ex)
            {
                sw.Stop();
                throw;
            }
          
         
           

        }

        private void btnUploadDocument_Click(object sender, EventArgs e)
        {
            UploadDocument();
        }
    }
}

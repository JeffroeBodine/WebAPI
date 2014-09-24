﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ObjectLibrary;
using WebApi;

namespace WebAPIClient
{
    public partial class Form1 : Form
    {
        public string BaseUrl
        {
            get { return txtBaseURL.Text; }
        }

        private SDK SDK { get; set; }

        public Form1()
        {
            InitializeComponent();
            SDK = new SDK(BaseUrl);

            //SendImageSet();
        }

        //private static void SendImageSet()
        //{
        //    var putDocumentParams = new PutDocumentParams(337);

        //    var compassNumberKWT = new KeywordType(136, "", typeof(string), "");
        //    var ssnKWT = new KeywordType(103, "", typeof(string), "");
        //    var firstNameKWT = new KeywordType(104, "", typeof(string), "");
        //    var lastNameKWT = new KeywordType(105, "", typeof(string), "");

        //    putDocumentParams.Keywords.Add(new Keyword(compassNumberKWT, "OH123000000001"));
        //    putDocumentParams.Keywords.Add(new Keyword(ssnKWT, "111-11-1111"));
        //    putDocumentParams.Keywords.Add(new Keyword(firstNameKWT, "Jeffroe"));
        //    putDocumentParams.Keywords.Add(new Keyword(lastNameKWT, "Bodine"));

        //    var multipartContent = new MultipartFormDataContent();

        //    var searlizedPutDocumentMetadata = JsonConvert.SerializeObject(putDocumentParams, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

        //    multipartContent.Add(new StringContent(searlizedPutDocumentMetadata, Encoding.UTF8, "application/json"), "PutDocumentParams");

        //    var counter = 1;
        //    foreach (var fileName in Directory.GetFiles("images"))
        //    {
        //        var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        //        multipartContent.Add(new StreamContent(fs), "File" + counter, Path.GetFileName(fileName));
        //        counter++;
        //    }

        //    var response = new HttpClient()
        //        .PostAsync("http://localhost/CompassDataBroker/api/Document/UploadFile", multipartContent)
        //        .Result;

        //    var responseContent = response.Content.ReadAsStringAsync().Result;
        //    Trace.Write(responseContent);
        //}

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        private void btnDocumentTypes_Click(object sender, EventArgs e)
        {
            DisplayDocumentTypes(SDK.GetDocumentTypes());
        }
        private void btnDocumentType_Click(object sender, EventArgs e)
        {
            DisplayDocumentType(SDK.GetDocumentType(txtDocumentTypeId.Text));
        }

        private void btnKeywordTypes_Click(object sender, EventArgs e)
        {
            DisplayKeywordTypes(SDK.GetKeywordTypes());
        }
        private void btnKeywordType_Click(object sender, EventArgs e)
        {
            DisplayKeywordType(SDK.GetKeywordType(txtKeywordTypeId.Text));
        }

        private void btnGetCase_Click(object sender, EventArgs e)
        {
            DisplayCase(SDK.GetCase(txtCaseId.Text));
        }
        private void btnGetClients_Click(object sender, EventArgs e)
        {
            DisplayClients(SDK.GetClients(txtCaseId.Text));
        }

        private void btnProgramTypes_Click(object sender, EventArgs e)
        {
            DisplayProgramTypes(SDK.GetProgramTypes());
        }


        private void btnGetProgramType_Click(object sender, EventArgs e)
        {
            DisplayProgramType(SDK.GetProgramType(txtCaseId.Text));
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            DisplayClient(SDK.GetClient(txtClientId.Text));
        }
        private void btnGetAddresses_Click(object sender, EventArgs e)
        {
            DisplayAddresses(SDK.GetAddresses(txtClientId.Text));
        }

        private void btnGetDocuments_Click(object sender, EventArgs e)
        {
            DisplayDocuments(SDK.GetDocuments(txtClientId.Text));
        }
        private void btnGetDocumentMetaData_Click(object sender, EventArgs e)
        {
            DisplayDocumentMetaData(SDK.GetDocumentMetaData(txtDocumentId.Text));
        }
        private void btnGetKeywords_Click(object sender, EventArgs e)
        {
            DisplayKeywords(SDK.GetKeywords(txtDocumentId.Text));
        }
        private void btnGetFile_Click(object sender, EventArgs e)
        {
            using (var fs = new FileStream(@"c:\something.tif", FileMode.Create, FileAccess.Write))
            {
                using (var ms = SDK.GetFile(txtDocumentId.Text).Result)
                {
                    ms.CopyTo(fs);
                }
            }
        }

        private void DisplayKeywords(IEnumerable<Keyword> keywords)
        {
            txtResult.Clear();
            foreach (var kw in keywords)
            {
                txtResult.Text += String.Format("Id: {0}, Name: {1}, Value: {2}{3}", kw.KeywordType.Id, kw.KeywordType.Name, kw.StringValue, Environment.NewLine);
            }
        }
        private void DisplayDocumentMetaData(DocumentMetaData m)
        {
            txtResult.Clear();
            txtResult.Text += String.Format("Page Count: {0}, Mime Type: {1}, Extension: {2}{3}", m.PageCount, m.MimeType, m.Extension, Environment.NewLine);
        }
        private void DisplayDocuments(IEnumerable<Document> documents)
        {
            txtResult.Clear();

            foreach (var document in documents)
            {
                txtResult.Text += String.Format("Id: {0}, Name: {1}{2}", document.Id, document.Name, Environment.NewLine);
                txtResult.Text += String.Format("    Author: {0}, Created: {1}, LUP Date: {2}, Document Type Id: {3}{4}"
                                                , document.Author, document.CreateDate, document.LUPDate, document.DocumentTypeID, Environment.NewLine);
            }
        }
        private void DisplayProgramTypes(IEnumerable<ProgramType> programTypes)
        {
            txtResult.Clear();
            foreach (var programType in programTypes)
            {
                txtResult.Text += String.Format("Id: {0}, Name: {1}{2}", programType.Id, programType.Name, Environment.NewLine);
            }
        }
        private void DisplayProgramType(ProgramType programType)
        {
            txtResult.Clear();
            txtResult.Text += String.Format("Id: {0}, Name: {1}{2}", programType.Id, programType.Name, Environment.NewLine);
        }
        private void DisplayAddresses(IEnumerable<Address> addresses)
        {
            txtResult.Clear();
            foreach (var a in addresses)
            {
                txtResult.Text += String.Format("Id: {0}, Type: {1}{2}", a.Id, a.AddressType, Environment.NewLine);
                txtResult.Text += String.Format("  {0}{1}", a.Street1, Environment.NewLine);
                txtResult.Text += String.Format("  {0}{1}", a.Street2, Environment.NewLine);
                txtResult.Text += String.Format("  {0}{1}", a.Street3, Environment.NewLine);
                txtResult.Text += String.Format("  {0}, {1} {2} - {3}{4}", a.City, a.State, a.Zip, a.Plus4, Environment.NewLine);
                txtResult.Text += Environment.NewLine;
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
        private void DisplayClient(Client client)
        {
            txtResult.Clear();
            txtResult.Text += String.Format("Id: {0}, SSN: {1} First Name: {2}, Last Name: {3}{4}", client.Id, client.SSN, client.FirstName, client.LastName, Environment.NewLine);

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

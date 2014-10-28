using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private SDK Sdk { get; set; }

        public Form1()
        {
            InitializeComponent();
            Sdk = new SDK(BaseUrl);

            //SendImageSet();
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        private void btnDocumentTypes_Click(object sender, EventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var documentTypes = Sdk.GetDocumentTypes();
            stopwatch.Stop();

            DisplayStopwatchTime(stopwatch);
            DisplayDocumentTypes(documentTypes);
        }
        private void btnDocumentType_Click(object sender, EventArgs e)
        {
            DisplayDocumentType(Sdk.GetDocumentType(txtDocumentTypeId.Text));
        }

        private void btnKeywordTypes_Click(object sender, EventArgs e)
        {
            DisplayKeywordTypes(Sdk.GetKeywordTypes());
        }
        private void btnKeywordType_Click(object sender, EventArgs e)
        {
            DisplayKeywordType(Sdk.GetKeywordType(txtKeywordTypeId.Text));
        }

        private void btnGetCase_Click(object sender, EventArgs e)
        {
            DisplayCase(Sdk.GetCase(txtCaseId.Text));
        }
        private void btnGetClients_Click(object sender, EventArgs e)
        {
            DisplayClients(Sdk.GetClients(txtCaseId.Text));
        }

        private void btnProgramTypes_Click(object sender, EventArgs e)
        {
            DisplayProgramTypes(Sdk.GetProgramTypes());
        }

        private void btnGetProgramType_Click(object sender, EventArgs e)
        {
            DisplayProgramType(Sdk.GetProgramType(txtCaseId.Text));
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            DisplayClient(Sdk.GetClient(txtClientId.Text));
        }
        private void btnGetAddresses_Click(object sender, EventArgs e)
        {
            DisplayAddresses(Sdk.GetAddresses(txtClientId.Text));
        }

        private void btnGetDocuments_Click(object sender, EventArgs e)
        {
            DisplayDocuments(Sdk.GetDocuments(txtClientId.Text));
        }
        private void btnGetDocumentMetaData_Click(object sender, EventArgs e)
        {
            DisplayDocumentMetaData(Sdk.GetDocumentMetaData(txtDocumentId.Text));
        }
        private void btnGetKeywords_Click(object sender, EventArgs e)
        {
            DisplayKeywords(Sdk.GetKeywords(txtDocumentId.Text));
        }
        private void btnGetFile_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.FileName = "something";
            dlg.AddExtension = true;
            dlg.DefaultExt = "tiff";
            dlg.Filter = "Tiff files (*.tif, *.tiff)|*.tif| All files (*.*)|*.*";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (var fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write))
                {
                    using (var ms = Sdk.GetFile(txtDocumentId.Text))
                    {
                        ms.CopyTo(fs);
                    }
                }
                Process.Start(dlg.FileName);
            }
        }

        private void btnGetTasks_Click(object sender, EventArgs e)
        {
            var tasks = Sdk.GetTasks();
            DisplayTasks(tasks);
        }
        private void btnGetTask_Click(object sender, EventArgs e)
        {
            var task = Sdk.GetTask(txtTaskId.Text);
            DisplayTask(task);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var frmAddTask = new frmAddTask(Sdk);
            frmAddTask.ShowDialog();

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

            if (documents == null) return;

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

            if (null == myCase)
                txtResult.Text += "No Cases Found";
            else
            {
                txtResult.Text += String.Format("Id: {0}, Case Number: {1}, Secondary Case Number: {2}, Program Type Id: {3}, Case Worker Id: {4}, Case Head Id: {5}{6}"
                                            , myCase.Id, myCase.CaseNumber, myCase.SecondaryCaseNumber, myCase.ProgramTypeId, myCase.CaseWorkerId, myCase.CaseHeadId, Environment.NewLine);

            }
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
            if (documentTypes == null)
                return;

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
        private void DisplayTasks(IEnumerable<Task> tasks)
        {
            txtResult.Clear();
            if (tasks == null)
                return;

            foreach (var t in tasks)
            {
                txtResult.Text += String.Format("Id: {0}, Description: {1}{2}", t.Id, t.Description, Environment.NewLine);
            }
        }
        private void DisplayTask(Task task)
        {
            txtResult.Clear();
            txtResult.Text += String.Format("Id: {0}, Description: {1}{2}", task.Id, task.Description, Environment.NewLine);
        }

        private void DisplayStopwatchTime(Stopwatch stopwatch)
        {
            txtResult.Clear();
            txtResult.Text += String.Format("Total Elapsed Time: {0} seconds.{1}", stopwatch.Elapsed.TotalMilliseconds / 1000, Environment.NewLine);
            ;
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

        private void btnUploadDocument_Click(object sender, EventArgs e)
        {
            new frmUploadDocument().ShowDialog();
        }

    }
}

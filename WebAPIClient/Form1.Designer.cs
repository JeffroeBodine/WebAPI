namespace WebAPIClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbImaging = new System.Windows.Forms.GroupBox();
            this.btnProgramTypes = new System.Windows.Forms.Button();
            this.txtKeywordTypeId = new System.Windows.Forms.TextBox();
            this.btnKeywordType = new System.Windows.Forms.Button();
            this.btnKeywordTypes = new System.Windows.Forms.Button();
            this.txtDocumentTypeId = new System.Windows.Forms.TextBox();
            this.btnDocumentType = new System.Windows.Forms.Button();
            this.btnDocumentTypes = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBaseURL = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGetProgramType = new System.Windows.Forms.Button();
            this.btnGetClients = new System.Windows.Forms.Button();
            this.txtCaseId = new System.Windows.Forms.TextBox();
            this.btnGetCase = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGetDocuments = new System.Windows.Forms.Button();
            this.btnGetAddresses = new System.Windows.Forms.Button();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.btnClient = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnUploadDocument = new System.Windows.Forms.Button();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.btnGetKeywords = new System.Windows.Forms.Button();
            this.txtDocumentId = new System.Windows.Forms.TextBox();
            this.btnGetDocumentMetaData = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnGetTask = new System.Windows.Forms.Button();
            this.btnGetTasks = new System.Windows.Forms.Button();
            this.txtTaskId = new System.Windows.Forms.TextBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.gbImaging.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbImaging
            // 
            this.gbImaging.Controls.Add(this.btnProgramTypes);
            this.gbImaging.Controls.Add(this.txtKeywordTypeId);
            this.gbImaging.Controls.Add(this.btnKeywordType);
            this.gbImaging.Controls.Add(this.btnKeywordTypes);
            this.gbImaging.Controls.Add(this.txtDocumentTypeId);
            this.gbImaging.Controls.Add(this.btnDocumentType);
            this.gbImaging.Controls.Add(this.btnDocumentTypes);
            this.gbImaging.Location = new System.Drawing.Point(12, 38);
            this.gbImaging.Name = "gbImaging";
            this.gbImaging.Size = new System.Drawing.Size(194, 169);
            this.gbImaging.TabIndex = 0;
            this.gbImaging.TabStop = false;
            this.gbImaging.Text = "Imaging";
            // 
            // btnProgramTypes
            // 
            this.btnProgramTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProgramTypes.Location = new System.Drawing.Point(6, 135);
            this.btnProgramTypes.Name = "btnProgramTypes";
            this.btnProgramTypes.Size = new System.Drawing.Size(182, 23);
            this.btnProgramTypes.TabIndex = 12;
            this.btnProgramTypes.Text = "Get Program Types";
            this.btnProgramTypes.UseVisualStyleBackColor = true;
            this.btnProgramTypes.Click += new System.EventHandler(this.btnProgramTypes_Click);
            // 
            // txtKeywordTypeId
            // 
            this.txtKeywordTypeId.Location = new System.Drawing.Point(130, 108);
            this.txtKeywordTypeId.Name = "txtKeywordTypeId";
            this.txtKeywordTypeId.Size = new System.Drawing.Size(58, 20);
            this.txtKeywordTypeId.TabIndex = 6;
            // 
            // btnKeywordType
            // 
            this.btnKeywordType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeywordType.Location = new System.Drawing.Point(6, 106);
            this.btnKeywordType.Name = "btnKeywordType";
            this.btnKeywordType.Size = new System.Drawing.Size(118, 23);
            this.btnKeywordType.TabIndex = 5;
            this.btnKeywordType.Text = "Get Keyword Types";
            this.btnKeywordType.UseVisualStyleBackColor = true;
            this.btnKeywordType.Click += new System.EventHandler(this.btnKeywordType_Click);
            // 
            // btnKeywordTypes
            // 
            this.btnKeywordTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeywordTypes.Location = new System.Drawing.Point(6, 77);
            this.btnKeywordTypes.Name = "btnKeywordTypes";
            this.btnKeywordTypes.Size = new System.Drawing.Size(182, 23);
            this.btnKeywordTypes.TabIndex = 4;
            this.btnKeywordTypes.Text = "Get Keyword Types";
            this.btnKeywordTypes.UseVisualStyleBackColor = true;
            this.btnKeywordTypes.Click += new System.EventHandler(this.btnKeywordTypes_Click);
            // 
            // txtDocumentTypeId
            // 
            this.txtDocumentTypeId.Location = new System.Drawing.Point(130, 49);
            this.txtDocumentTypeId.Name = "txtDocumentTypeId";
            this.txtDocumentTypeId.Size = new System.Drawing.Size(58, 20);
            this.txtDocumentTypeId.TabIndex = 3;
            // 
            // btnDocumentType
            // 
            this.btnDocumentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocumentType.Location = new System.Drawing.Point(6, 48);
            this.btnDocumentType.Name = "btnDocumentType";
            this.btnDocumentType.Size = new System.Drawing.Size(118, 23);
            this.btnDocumentType.TabIndex = 2;
            this.btnDocumentType.Text = "Get Document Type";
            this.btnDocumentType.UseVisualStyleBackColor = true;
            this.btnDocumentType.Click += new System.EventHandler(this.btnDocumentType_Click);
            // 
            // btnDocumentTypes
            // 
            this.btnDocumentTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocumentTypes.Location = new System.Drawing.Point(6, 19);
            this.btnDocumentTypes.Name = "btnDocumentTypes";
            this.btnDocumentTypes.Size = new System.Drawing.Size(182, 23);
            this.btnDocumentTypes.TabIndex = 1;
            this.btnDocumentTypes.Text = "Get Document Types";
            this.btnDocumentTypes.UseVisualStyleBackColor = true;
            this.btnDocumentTypes.Click += new System.EventHandler(this.btnDocumentTypes_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(6, 19);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(1246, 305);
            this.txtResult.TabIndex = 1;
            this.txtResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResult_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnClearResult);
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Location = new System.Drawing.Point(12, 388);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1258, 330);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // btnClearResult
            // 
            this.btnClearResult.Location = new System.Drawing.Point(1158, 283);
            this.btnClearResult.Name = "btnClearResult";
            this.btnClearResult.Size = new System.Drawing.Size(75, 23);
            this.btnClearResult.TabIndex = 2;
            this.btnClearResult.Text = "Clear";
            this.btnClearResult.UseVisualStyleBackColor = true;
            this.btnClearResult.Click += new System.EventHandler(this.btnClearResult_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Base URL: ";
            // 
            // txtBaseURL
            // 
            this.txtBaseURL.Location = new System.Drawing.Point(80, 12);
            this.txtBaseURL.Name = "txtBaseURL";
            this.txtBaseURL.Size = new System.Drawing.Size(545, 20);
            this.txtBaseURL.TabIndex = 3;
            this.txtBaseURL.Text = "http://localhost/CompassDataBroker/api/";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGetProgramType);
            this.groupBox2.Controls.Add(this.btnGetClients);
            this.groupBox2.Controls.Add(this.txtCaseId);
            this.groupBox2.Controls.Add(this.btnGetCase);
            this.groupBox2.Location = new System.Drawing.Point(12, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 169);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cases";
            // 
            // btnGetProgramType
            // 
            this.btnGetProgramType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetProgramType.Location = new System.Drawing.Point(6, 77);
            this.btnGetProgramType.Name = "btnGetProgramType";
            this.btnGetProgramType.Size = new System.Drawing.Size(118, 23);
            this.btnGetProgramType.TabIndex = 10;
            this.btnGetProgramType.Text = "Get Program Type";
            this.btnGetProgramType.UseVisualStyleBackColor = true;
            this.btnGetProgramType.Click += new System.EventHandler(this.btnGetProgramType_Click);
            // 
            // btnGetClients
            // 
            this.btnGetClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetClients.Location = new System.Drawing.Point(6, 48);
            this.btnGetClients.Name = "btnGetClients";
            this.btnGetClients.Size = new System.Drawing.Size(118, 23);
            this.btnGetClients.TabIndex = 9;
            this.btnGetClients.Text = "Get Clients";
            this.btnGetClients.UseVisualStyleBackColor = true;
            this.btnGetClients.Click += new System.EventHandler(this.btnGetClients_Click);
            // 
            // txtCaseId
            // 
            this.txtCaseId.Location = new System.Drawing.Point(130, 20);
            this.txtCaseId.Name = "txtCaseId";
            this.txtCaseId.Size = new System.Drawing.Size(58, 20);
            this.txtCaseId.TabIndex = 8;
            // 
            // btnGetCase
            // 
            this.btnGetCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetCase.Location = new System.Drawing.Point(6, 19);
            this.btnGetCase.Name = "btnGetCase";
            this.btnGetCase.Size = new System.Drawing.Size(118, 23);
            this.btnGetCase.TabIndex = 7;
            this.btnGetCase.Text = "Get Case";
            this.btnGetCase.UseVisualStyleBackColor = true;
            this.btnGetCase.Click += new System.EventHandler(this.btnGetCase_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGetDocuments);
            this.groupBox3.Controls.Add(this.btnGetAddresses);
            this.groupBox3.Controls.Add(this.txtClientId);
            this.groupBox3.Controls.Add(this.btnClient);
            this.groupBox3.Location = new System.Drawing.Point(212, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 169);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Clients";
            // 
            // btnGetDocuments
            // 
            this.btnGetDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetDocuments.Location = new System.Drawing.Point(6, 77);
            this.btnGetDocuments.Name = "btnGetDocuments";
            this.btnGetDocuments.Size = new System.Drawing.Size(118, 23);
            this.btnGetDocuments.TabIndex = 10;
            this.btnGetDocuments.Text = "Get Documents";
            this.btnGetDocuments.UseVisualStyleBackColor = true;
            this.btnGetDocuments.Click += new System.EventHandler(this.btnGetDocuments_Click);
            // 
            // btnGetAddresses
            // 
            this.btnGetAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetAddresses.Location = new System.Drawing.Point(6, 48);
            this.btnGetAddresses.Name = "btnGetAddresses";
            this.btnGetAddresses.Size = new System.Drawing.Size(118, 23);
            this.btnGetAddresses.TabIndex = 9;
            this.btnGetAddresses.Text = "Get Addresses";
            this.btnGetAddresses.UseVisualStyleBackColor = true;
            this.btnGetAddresses.Click += new System.EventHandler(this.btnGetAddresses_Click);
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(130, 20);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(58, 20);
            this.txtClientId.TabIndex = 8;
            // 
            // btnClient
            // 
            this.btnClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClient.Location = new System.Drawing.Point(6, 19);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(118, 23);
            this.btnClient.TabIndex = 7;
            this.btnClient.Text = "Get Client";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnUploadDocument);
            this.groupBox4.Controls.Add(this.btnGetFile);
            this.groupBox4.Controls.Add(this.btnGetKeywords);
            this.groupBox4.Controls.Add(this.txtDocumentId);
            this.groupBox4.Controls.Add(this.btnGetDocumentMetaData);
            this.groupBox4.Location = new System.Drawing.Point(412, 38);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 139);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Documents";
            // 
            // btnUploadDocument
            // 
            this.btnUploadDocument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadDocument.Location = new System.Drawing.Point(6, 105);
            this.btnUploadDocument.Name = "btnUploadDocument";
            this.btnUploadDocument.Size = new System.Drawing.Size(153, 23);
            this.btnUploadDocument.TabIndex = 14;
            this.btnUploadDocument.Text = "Upload Document";
            this.btnUploadDocument.UseVisualStyleBackColor = true;
            this.btnUploadDocument.Click += new System.EventHandler(this.btnUploadDocument_Click);
            // 
            // btnGetFile
            // 
            this.btnGetFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFile.Location = new System.Drawing.Point(6, 77);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(153, 23);
            this.btnGetFile.TabIndex = 13;
            this.btnGetFile.Text = "Get File";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // btnGetKeywords
            // 
            this.btnGetKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetKeywords.Location = new System.Drawing.Point(6, 48);
            this.btnGetKeywords.Name = "btnGetKeywords";
            this.btnGetKeywords.Size = new System.Drawing.Size(153, 23);
            this.btnGetKeywords.TabIndex = 12;
            this.btnGetKeywords.Text = "Get Keywords";
            this.btnGetKeywords.UseVisualStyleBackColor = true;
            this.btnGetKeywords.Click += new System.EventHandler(this.btnGetKeywords_Click);
            // 
            // txtDocumentId
            // 
            this.txtDocumentId.Location = new System.Drawing.Point(165, 21);
            this.txtDocumentId.Name = "txtDocumentId";
            this.txtDocumentId.Size = new System.Drawing.Size(58, 20);
            this.txtDocumentId.TabIndex = 11;
            // 
            // btnGetDocumentMetaData
            // 
            this.btnGetDocumentMetaData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetDocumentMetaData.Location = new System.Drawing.Point(6, 19);
            this.btnGetDocumentMetaData.Name = "btnGetDocumentMetaData";
            this.btnGetDocumentMetaData.Size = new System.Drawing.Size(153, 23);
            this.btnGetDocumentMetaData.TabIndex = 2;
            this.btnGetDocumentMetaData.Text = "Get Document MetaData";
            this.btnGetDocumentMetaData.UseVisualStyleBackColor = true;
            this.btnGetDocumentMetaData.Click += new System.EventHandler(this.btnGetDocumentMetaData_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAddTask);
            this.groupBox5.Controls.Add(this.txtTaskId);
            this.groupBox5.Controls.Add(this.btnGetTask);
            this.groupBox5.Controls.Add(this.btnGetTasks);
            this.groupBox5.Location = new System.Drawing.Point(653, 38);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(235, 139);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tasks";
            // 
            // btnGetTask
            // 
            this.btnGetTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetTask.Location = new System.Drawing.Point(6, 46);
            this.btnGetTask.Name = "btnGetTask";
            this.btnGetTask.Size = new System.Drawing.Size(159, 23);
            this.btnGetTask.TabIndex = 16;
            this.btnGetTask.Text = "Get Task";
            this.btnGetTask.UseVisualStyleBackColor = true;
            this.btnGetTask.Click += new System.EventHandler(this.btnGetTask_Click);
            // 
            // btnGetTasks
            // 
            this.btnGetTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetTasks.Location = new System.Drawing.Point(6, 17);
            this.btnGetTasks.Name = "btnGetTasks";
            this.btnGetTasks.Size = new System.Drawing.Size(159, 23);
            this.btnGetTasks.TabIndex = 15;
            this.btnGetTasks.Text = "Get Tasks";
            this.btnGetTasks.UseVisualStyleBackColor = true;
            this.btnGetTasks.Click += new System.EventHandler(this.btnGetTasks_Click);
            // 
            // txtTaskId
            // 
            this.txtTaskId.Location = new System.Drawing.Point(171, 46);
            this.txtTaskId.Name = "txtTaskId";
            this.txtTaskId.Size = new System.Drawing.Size(58, 20);
            this.txtTaskId.TabIndex = 15;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTask.Location = new System.Drawing.Point(6, 75);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(159, 23);
            this.btnAddTask.TabIndex = 15;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 730);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtBaseURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbImaging);
            this.Name = "Form1";
            this.Text = "Web API Client";
            this.gbImaging.ResumeLayout(false);
            this.gbImaging.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbImaging;
        private System.Windows.Forms.Button btnDocumentTypes;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClearResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBaseURL;
        private System.Windows.Forms.TextBox txtDocumentTypeId;
        private System.Windows.Forms.Button btnDocumentType;
        private System.Windows.Forms.Button btnKeywordTypes;
        private System.Windows.Forms.TextBox txtKeywordTypeId;
        private System.Windows.Forms.Button btnKeywordType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCaseId;
        private System.Windows.Forms.Button btnGetCase;
        private System.Windows.Forms.Button btnGetClients;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnGetAddresses;
        private System.Windows.Forms.Button btnGetProgramType;
        private System.Windows.Forms.Button btnProgramTypes;
        private System.Windows.Forms.Button btnGetDocuments;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGetDocumentMetaData;
        private System.Windows.Forms.TextBox txtDocumentId;
        private System.Windows.Forms.Button btnGetKeywords;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.Button btnUploadDocument;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtTaskId;
        private System.Windows.Forms.Button btnGetTask;
        private System.Windows.Forms.Button btnGetTasks;
        private System.Windows.Forms.Button btnAddTask;
    }
}


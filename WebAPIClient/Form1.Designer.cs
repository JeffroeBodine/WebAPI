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
            this.txtCaseId = new System.Windows.Forms.TextBox();
            this.btnGetCase = new System.Windows.Forms.Button();
            this.btnGetClients = new System.Windows.Forms.Button();
            this.txtCaseIdForClients = new System.Windows.Forms.TextBox();
            this.gbImaging.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbImaging
            // 
            this.gbImaging.Controls.Add(this.txtKeywordTypeId);
            this.gbImaging.Controls.Add(this.btnKeywordType);
            this.gbImaging.Controls.Add(this.btnKeywordTypes);
            this.gbImaging.Controls.Add(this.txtDocumentTypeId);
            this.gbImaging.Controls.Add(this.btnDocumentType);
            this.gbImaging.Controls.Add(this.btnDocumentTypes);
            this.gbImaging.Location = new System.Drawing.Point(12, 38);
            this.gbImaging.Name = "gbImaging";
            this.gbImaging.Size = new System.Drawing.Size(194, 362);
            this.gbImaging.TabIndex = 0;
            this.gbImaging.TabStop = false;
            this.gbImaging.Text = "Imaging";
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
            this.txtResult.Size = new System.Drawing.Size(1246, 287);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1258, 312);
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
            this.groupBox2.Controls.Add(this.txtCaseIdForClients);
            this.groupBox2.Controls.Add(this.btnGetClients);
            this.groupBox2.Controls.Add(this.txtCaseId);
            this.groupBox2.Controls.Add(this.btnGetCase);
            this.groupBox2.Location = new System.Drawing.Point(212, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 362);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cases";
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
            // txtCaseIdForClients
            // 
            this.txtCaseIdForClients.Location = new System.Drawing.Point(130, 49);
            this.txtCaseIdForClients.Name = "txtCaseIdForClients";
            this.txtCaseIdForClients.Size = new System.Drawing.Size(58, 20);
            this.txtCaseIdForClients.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 730);
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
        private System.Windows.Forms.TextBox txtCaseIdForClients;
        private System.Windows.Forms.Button btnGetClients;
    }
}


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
            this.btnDocumentTypes = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBaseURL = new System.Windows.Forms.TextBox();
            this.btnGetDocumentType = new System.Windows.Forms.Button();
            this.txtDocumentTypeId = new System.Windows.Forms.TextBox();
            this.gbImaging.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbImaging
            // 
            this.gbImaging.Controls.Add(this.txtDocumentTypeId);
            this.gbImaging.Controls.Add(this.btnGetDocumentType);
            this.gbImaging.Controls.Add(this.btnDocumentTypes);
            this.gbImaging.Location = new System.Drawing.Point(12, 38);
            this.gbImaging.Name = "gbImaging";
            this.gbImaging.Size = new System.Drawing.Size(194, 362);
            this.gbImaging.TabIndex = 0;
            this.gbImaging.TabStop = false;
            this.gbImaging.Text = "Imaging";
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
            // btnGetDocumentType
            // 
            this.btnGetDocumentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetDocumentType.Location = new System.Drawing.Point(6, 48);
            this.btnGetDocumentType.Name = "btnGetDocumentType";
            this.btnGetDocumentType.Size = new System.Drawing.Size(118, 23);
            this.btnGetDocumentType.TabIndex = 2;
            this.btnGetDocumentType.Text = "Get Document Type";
            this.btnGetDocumentType.UseVisualStyleBackColor = true;
            this.btnGetDocumentType.Click += new System.EventHandler(this.btnGetDocumentType_Click);
            // 
            // txtDocumentTypeId
            // 
            this.txtDocumentTypeId.Location = new System.Drawing.Point(130, 49);
            this.txtDocumentTypeId.Name = "txtDocumentTypeId";
            this.txtDocumentTypeId.Size = new System.Drawing.Size(58, 20);
            this.txtDocumentTypeId.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 730);
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
        private System.Windows.Forms.Button btnGetDocumentType;
    }
}


namespace WebAPIClient
{
    partial class frmUploadDocument
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
            this.txtDocumentTypeId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompassNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSSN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImagesFolderPath = new System.Windows.Forms.TextBox();
            this.btnFolderFinder = new System.Windows.Forms.Button();
            this.btnUploadDocument = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDocumentTypeId
            // 
            this.txtDocumentTypeId.Location = new System.Drawing.Point(116, 12);
            this.txtDocumentTypeId.Name = "txtDocumentTypeId";
            this.txtDocumentTypeId.Size = new System.Drawing.Size(228, 20);
            this.txtDocumentTypeId.TabIndex = 0;
            this.txtDocumentTypeId.Text = "337";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Document Type Id: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Compass #: ";
            // 
            // txtCompassNumber
            // 
            this.txtCompassNumber.Location = new System.Drawing.Point(116, 60);
            this.txtCompassNumber.Name = "txtCompassNumber";
            this.txtCompassNumber.Size = new System.Drawing.Size(228, 20);
            this.txtCompassNumber.TabIndex = 2;
            this.txtCompassNumber.Text = "OH123000000001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SSN: ";
            // 
            // txtSSN
            // 
            this.txtSSN.Location = new System.Drawing.Point(457, 59);
            this.txtSSN.Name = "txtSSN";
            this.txtSSN.Size = new System.Drawing.Size(228, 20);
            this.txtSSN.TabIndex = 4;
            this.txtSSN.Text = "111-11-1111";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "First Name: ";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(116, 89);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(228, 20);
            this.txtFirstName.TabIndex = 6;
            this.txtFirstName.Text = "Jeffroe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Last Name: ";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(457, 85);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(228, 20);
            this.txtLastName.TabIndex = 8;
            this.txtLastName.Text = "Bodine";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Images Folder: ";
            // 
            // txtImagesFolderPath
            // 
            this.txtImagesFolderPath.Location = new System.Drawing.Point(116, 136);
            this.txtImagesFolderPath.Name = "txtImagesFolderPath";
            this.txtImagesFolderPath.Size = new System.Drawing.Size(532, 20);
            this.txtImagesFolderPath.TabIndex = 10;
            // 
            // btnFolderFinder
            // 
            this.btnFolderFinder.Location = new System.Drawing.Point(654, 134);
            this.btnFolderFinder.Name = "btnFolderFinder";
            this.btnFolderFinder.Size = new System.Drawing.Size(31, 23);
            this.btnFolderFinder.TabIndex = 12;
            this.btnFolderFinder.Text = "...";
            this.btnFolderFinder.UseVisualStyleBackColor = true;
            this.btnFolderFinder.Click += new System.EventHandler(this.btnFolderFinder_Click);
            // 
            // btnUploadDocument
            // 
            this.btnUploadDocument.Location = new System.Drawing.Point(265, 186);
            this.btnUploadDocument.Name = "btnUploadDocument";
            this.btnUploadDocument.Size = new System.Drawing.Size(149, 23);
            this.btnUploadDocument.TabIndex = 13;
            this.btnUploadDocument.Text = "Upload Document";
            this.btnUploadDocument.UseVisualStyleBackColor = true;
            this.btnUploadDocument.Click += new System.EventHandler(this.btnUploadDocument_Click);
            // 
            // frmUploadDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 227);
            this.Controls.Add(this.btnUploadDocument);
            this.Controls.Add(this.btnFolderFinder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtImagesFolderPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSSN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCompassNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDocumentTypeId);
            this.Name = "frmUploadDocument";
            this.Text = "Upload Document";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDocumentTypeId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompassNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSSN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtImagesFolderPath;
        private System.Windows.Forms.Button btnFolderFinder;
        private System.Windows.Forms.Button btnUploadDocument;
    }
}
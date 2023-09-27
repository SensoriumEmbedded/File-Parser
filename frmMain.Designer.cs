
namespace Text_File_Parser
{
    partial class frmMain
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
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btnThousandTrails = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSpiralST3 = new System.Windows.Forms.Button();
            this.btnC64CharSet = new System.Windows.Forms.Button();
            this.tbMaxChars = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearDisp = new System.Windows.Forms.Button();
            this.btnC64CRTfile = new System.Windows.Forms.Button();
            this.cbChipInfo = new System.Windows.Forms.CheckBox();
            this.btnC64SIDfile = new System.Windows.Forms.Button();
            this.cbSIDDetails = new System.Windows.Forms.CheckBox();
            this.cbSIDSummary = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rtbOutput
            // 
            this.rtbOutput.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.Location = new System.Drawing.Point(12, 99);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(776, 339);
            this.rtbOutput.TabIndex = 0;
            this.rtbOutput.Text = "";
            // 
            // btnThousandTrails
            // 
            this.btnThousandTrails.Location = new System.Drawing.Point(552, 12);
            this.btnThousandTrails.Name = "btnThousandTrails";
            this.btnThousandTrails.Size = new System.Drawing.Size(236, 23);
            this.btnThousandTrails.TabIndex = 1;
            this.btnThousandTrails.Text = "Thousand Trails Places Stayed";
            this.btnThousandTrails.UseVisualStyleBackColor = true;
            this.btnThousandTrails.Click += new System.EventHandler(this.btnThousandTrails_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSpiralST3
            // 
            this.btnSpiralST3.Location = new System.Drawing.Point(552, 41);
            this.btnSpiralST3.Name = "btnSpiralST3";
            this.btnSpiralST3.Size = new System.Drawing.Size(236, 49);
            this.btnSpiralST3.TabIndex = 2;
            this.btnSpiralST3.Text = "Spiral SIT/ST3 Parse\r\nEntry per line to CSV";
            this.btnSpiralST3.UseVisualStyleBackColor = true;
            this.btnSpiralST3.Click += new System.EventHandler(this.btnSpiralST3_Click);
            // 
            // btnC64CharSet
            // 
            this.btnC64CharSet.Location = new System.Drawing.Point(12, 12);
            this.btnC64CharSet.Name = "btnC64CharSet";
            this.btnC64CharSet.Size = new System.Drawing.Size(236, 23);
            this.btnC64CharSet.TabIndex = 3;
            this.btnC64CharSet.Text = "C64 Char set file";
            this.btnC64CharSet.UseVisualStyleBackColor = true;
            this.btnC64CharSet.Click += new System.EventHandler(this.btnC64CharSet_Click);
            // 
            // tbMaxChars
            // 
            this.tbMaxChars.Location = new System.Drawing.Point(254, 13);
            this.tbMaxChars.MaxLength = 10;
            this.tbMaxChars.Name = "tbMaxChars";
            this.tbMaxChars.Size = new System.Drawing.Size(40, 22);
            this.tbMaxChars.TabIndex = 4;
            this.tbMaxChars.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "max chars";
            // 
            // btnClearDisp
            // 
            this.btnClearDisp.Location = new System.Drawing.Point(462, 70);
            this.btnClearDisp.Name = "btnClearDisp";
            this.btnClearDisp.Size = new System.Drawing.Size(69, 23);
            this.btnClearDisp.TabIndex = 7;
            this.btnClearDisp.Text = "Clear";
            this.btnClearDisp.UseVisualStyleBackColor = true;
            this.btnClearDisp.Click += new System.EventHandler(this.btnClearDisp_Click);
            // 
            // btnC64CRTfile
            // 
            this.btnC64CRTfile.Location = new System.Drawing.Point(12, 41);
            this.btnC64CRTfile.Name = "btnC64CRTfile";
            this.btnC64CRTfile.Size = new System.Drawing.Size(236, 23);
            this.btnC64CRTfile.TabIndex = 8;
            this.btnC64CRTfile.Text = "C64 Cartridge file";
            this.btnC64CRTfile.UseVisualStyleBackColor = true;
            this.btnC64CRTfile.Click += new System.EventHandler(this.btnC64CRTfile_Click);
            // 
            // cbChipInfo
            // 
            this.cbChipInfo.AutoSize = true;
            this.cbChipInfo.Location = new System.Drawing.Point(254, 44);
            this.cbChipInfo.Name = "cbChipInfo";
            this.cbChipInfo.Size = new System.Drawing.Size(101, 20);
            this.cbChipInfo.TabIndex = 9;
            this.cbChipInfo.Text = "Chip Details";
            this.cbChipInfo.UseVisualStyleBackColor = true;
            // 
            // btnC64SIDfile
            // 
            this.btnC64SIDfile.Location = new System.Drawing.Point(12, 70);
            this.btnC64SIDfile.Name = "btnC64SIDfile";
            this.btnC64SIDfile.Size = new System.Drawing.Size(236, 23);
            this.btnC64SIDfile.TabIndex = 10;
            this.btnC64SIDfile.Text = "C64 SID file";
            this.btnC64SIDfile.UseVisualStyleBackColor = true;
            this.btnC64SIDfile.Click += new System.EventHandler(this.btnC64SIDfile_Click);
            // 
            // cbSIDDetails
            // 
            this.cbSIDDetails.AutoSize = true;
            this.cbSIDDetails.Location = new System.Drawing.Point(346, 73);
            this.cbSIDDetails.Name = "cbSIDDetails";
            this.cbSIDDetails.Size = new System.Drawing.Size(71, 20);
            this.cbSIDDetails.TabIndex = 11;
            this.cbSIDDetails.Text = "Details";
            this.cbSIDDetails.UseVisualStyleBackColor = true;
            // 
            // cbSIDSummary
            // 
            this.cbSIDSummary.AutoSize = true;
            this.cbSIDSummary.Checked = true;
            this.cbSIDSummary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSIDSummary.Location = new System.Drawing.Point(254, 73);
            this.cbSIDSummary.Name = "cbSIDSummary";
            this.cbSIDSummary.Size = new System.Drawing.Size(86, 20);
            this.cbSIDSummary.TabIndex = 12;
            this.cbSIDSummary.Text = "Summary";
            this.cbSIDSummary.UseVisualStyleBackColor = true;
            this.cbSIDSummary.CheckedChanged += new System.EventHandler(this.cbSIDSummary_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbSIDSummary);
            this.Controls.Add(this.cbSIDDetails);
            this.Controls.Add(this.btnC64SIDfile);
            this.Controls.Add(this.cbChipInfo);
            this.Controls.Add(this.btnC64CRTfile);
            this.Controls.Add(this.btnClearDisp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMaxChars);
            this.Controls.Add(this.btnC64CharSet);
            this.Controls.Add(this.btnSpiralST3);
            this.Controls.Add(this.btnThousandTrails);
            this.Controls.Add(this.rtbOutput);
            this.Name = "frmMain";
            this.Text = "Text File Parser v0.01";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnThousandTrails;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSpiralST3;
        private System.Windows.Forms.Button btnC64CharSet;
        private System.Windows.Forms.TextBox tbMaxChars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearDisp;
        private System.Windows.Forms.Button btnC64CRTfile;
        private System.Windows.Forms.CheckBox cbChipInfo;
        private System.Windows.Forms.Button btnC64SIDfile;
        private System.Windows.Forms.CheckBox cbSIDDetails;
        private System.Windows.Forms.CheckBox cbSIDSummary;
    }
}


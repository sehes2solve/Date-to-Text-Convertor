namespace Date_to_Text_Converter
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.TXT_date = new System.Windows.Forms.TextBox();
            this.BTN_Convert = new System.Windows.Forms.Button();
            this.TXT_lang = new System.Windows.Forms.TextBox();
            this.TXT_accent = new System.Windows.Forms.TextBox();
            this.LBL_result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TXT_date
            // 
            this.TXT_date.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TXT_date.Location = new System.Drawing.Point(13, 13);
            this.TXT_date.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_date.Name = "TXT_date";
            this.TXT_date.Size = new System.Drawing.Size(229, 26);
            this.TXT_date.TabIndex = 0;
            this.TXT_date.Text = "The Date";
            this.TXT_date.Enter += new System.EventHandler(this.TXT_date_Enter);
            this.TXT_date.Leave += new System.EventHandler(this.TXT_date_Leave);
            // 
            // BTN_Convert
            // 
            this.BTN_Convert.Location = new System.Drawing.Point(260, 12);
            this.BTN_Convert.Name = "BTN_Convert";
            this.BTN_Convert.Size = new System.Drawing.Size(177, 26);
            this.BTN_Convert.TabIndex = 1;
            this.BTN_Convert.Text = "Convert";
            this.BTN_Convert.UseVisualStyleBackColor = true;
            this.BTN_Convert.Click += new System.EventHandler(this.BTN_Convert_Click);
            // 
            // TXT_lang
            // 
            this.TXT_lang.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TXT_lang.Location = new System.Drawing.Point(13, 46);
            this.TXT_lang.Name = "TXT_lang";
            this.TXT_lang.Size = new System.Drawing.Size(109, 26);
            this.TXT_lang.TabIndex = 2;
            this.TXT_lang.Text = "Language";
            this.TXT_lang.TextChanged += new System.EventHandler(this.TXT_lang_TextChanged);
            this.TXT_lang.Enter += new System.EventHandler(this.TXT_lang_Enter);
            this.TXT_lang.Leave += new System.EventHandler(this.TXT_lang_Leave);
            // 
            // TXT_accent
            // 
            this.TXT_accent.Enabled = false;
            this.TXT_accent.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TXT_accent.Location = new System.Drawing.Point(128, 46);
            this.TXT_accent.Name = "TXT_accent";
            this.TXT_accent.Size = new System.Drawing.Size(114, 26);
            this.TXT_accent.TabIndex = 3;
            this.TXT_accent.Text = "Accent (US,UK)";
            this.TXT_accent.Enter += new System.EventHandler(this.TXT_accent_Enter);
            this.TXT_accent.Leave += new System.EventHandler(this.TXT_accent_Leave);
            // 
            // LBL_result
            // 
            this.LBL_result.AutoSize = true;
            this.LBL_result.Location = new System.Drawing.Point(12, 75);
            this.LBL_result.Name = "LBL_result";
            this.LBL_result.Size = new System.Drawing.Size(53, 19);
            this.LBL_result.TabIndex = 8;
            this.LBL_result.Text = "Result";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 109);
            this.Controls.Add(this.LBL_result);
            this.Controls.Add(this.TXT_accent);
            this.Controls.Add(this.TXT_lang);
            this.Controls.Add(this.BTN_Convert);
            this.Controls.Add(this.TXT_date);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form";
            this.Text = "Date to Text Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXT_date;
        private System.Windows.Forms.Button BTN_Convert;
        private System.Windows.Forms.TextBox TXT_lang;
        private System.Windows.Forms.TextBox TXT_accent;
        private System.Windows.Forms.Label LBL_result;
    }
}


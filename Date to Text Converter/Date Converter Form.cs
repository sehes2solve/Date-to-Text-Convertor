using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Date_to_Text_Converter
{
    public partial class Form : System.Windows.Forms.Form
    {
        Date_Converter_Methodes ConMethodes = new Date_Converter_Methodes();
        public Form()
        {
            InitializeComponent();
        }

        private void TXT_date_Enter(object sender, EventArgs e)
        {
            if (TXT_date.Text == "The Date" && TXT_date.ForeColor == SystemColors.InactiveCaption)
            {
                TXT_date.Text = "";
                TXT_date.ForeColor = Color.Black;
            }
        }
        private void TXT_date_Leave(object sender, EventArgs e)
        {
            if (TXT_date.Text.Trim() == "")
            {
                TXT_date.ForeColor = SystemColors.InactiveCaption;
                TXT_date.Text = "The Date";
            }
        }
        private void TXT_lang_Enter(object sender, EventArgs e)
        {
            if (TXT_lang.Text == "Language" && TXT_lang.ForeColor == SystemColors.InactiveCaption)
            {
                TXT_lang.Text = "";
                TXT_lang.ForeColor = Color.Black;
            }
        }
        private void TXT_lang_Leave(object sender, EventArgs e)
        {
            if (TXT_lang.Text.Trim() == "")
            {
                TXT_lang.ForeColor = SystemColors.InactiveCaption;
                TXT_lang.Text = "Language";
            }
        }
        private void TXT_accent_Enter(object sender, EventArgs e)
        {
            if (TXT_accent.Text == "Accent (US,UK)" && TXT_accent.ForeColor == SystemColors.InactiveCaption)
            {
                TXT_accent.Text = "";
                TXT_accent.ForeColor = Color.Black;
            }
        }
        private void TXT_accent_Leave(object sender, EventArgs e)
        {
            if (TXT_accent.Text.Trim() == "")
            {
                TXT_accent.ForeColor = SystemColors.InactiveCaption;
                TXT_accent.Text = "Accent (US,UK)";
            }
        }
        private void BTN_Convert_Click(object sender, EventArgs e)
        {
            if (TXT_date.Text == "The Date" && TXT_date.ForeColor == SystemColors.InactiveCaption)
                TXT_date.Text = "";
            if (TXT_lang.Text == "Language" && TXT_lang.ForeColor == SystemColors.InactiveCaption)
                TXT_lang.Text = "";
            if (TXT_accent.Text == "Accent (US,UK)" && TXT_accent.ForeColor == SystemColors.InactiveCaption)
                TXT_accent.Text = "";
            LBL_result.Text = ConMethodes.DateConverter(TXT_date.Text, TXT_lang.Text, TXT_accent.Text);
            if (TXT_date.Text == "" && TXT_date.ForeColor == SystemColors.InactiveCaption)
                TXT_date.Text = "The Date";
            if (TXT_lang.Text == "" && TXT_lang.ForeColor == SystemColors.InactiveCaption)
                TXT_lang.Text = "Language";
            if (TXT_accent.Text == "" && TXT_accent.ForeColor == SystemColors.InactiveCaption)
                TXT_accent.Text = "Accent (US,UK)";
        }

        private void TXT_lang_TextChanged(object sender, EventArgs e)
        {
            if (TXT_lang.Text == "EN")
                TXT_accent.Enabled = true;
            else
            {
                TXT_accent.Enabled = false;
                TXT_accent.Text = "Accent (US,UK)";
            }
        }
    }
}

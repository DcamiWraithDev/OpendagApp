using System;
using System.Drawing;
using System.Windows.Forms;
using OpendagApplicatie;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace OpendagApplicatie
{
    public partial class Form1 : Form
    {
        private readonly string[] radioDates = { "20 Mei 2025", "27 Mei 2025", "3 Juni 2025" };

        public Form1()
        {
            InitializeComponent();
            SetUpTextBoxEvents();
            telefoon_Input.Text = "06-";
            BeheerPaneel.VisibleChanged += BeheerPaneel_VisibleChanged;
        }

        private void BeheerPaneel_VisibleChanged(object sender, EventArgs e)
        {
            if (BeheerPaneel.Visible)
            {
                LaadAanmeldingen();
            }
        }

        private void SetUpTextBoxEvents()
        {
            foreach (var input in new TextBox[] { voornaam_Input, achternaam_Input, email_Input, telefoon_Input })
                input.Enter += (sender, e) => ClearRedText(sender as TextBox);

            telefoon_Input.Enter += (sender, e) => ResetTelefoonInput(sender as TextBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = new
            {
                Voornaam = voornaam_Input.Text.Trim(),
                Achternaam = achternaam_Input.Text.Trim(),
                Email = email_Input.Text.Trim(),
                Telefoon = telefoon_Input.Text.Trim(),
                Geboortedatum = Geboortedatum_datePicker.Value,
                Leeftijd = FormValidation.BerekenLeeftijd(Geboortedatum_datePicker.Value),
                SelectedRadioButton = GetSelectedRadioButtonText()
            };

            bool isValid = FormValidation.Validate(data, this);

            if (isValid)
            {
                GetCSV.SaveToCsv(data);
                MessageBox.Show("Succesvol verstuurd!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                voornaam_Input.Text = "";
                achternaam_Input.Text = "";
                email_Input.Text = "";
                telefoon_Input.Text = "";
                Geboortedatum_datePicker.Value = DateTime.Parse("01/01/1900");
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;

            }
        }

        private void ClearRedText(TextBox textBox)
        {
            if (textBox.ForeColor == Color.Red)
            {
                textBox.ForeColor = Color.Black;
                textBox.Clear();
            }
        }

        private void ResetTelefoonInput(TextBox textBox)
        {
            if (textBox.ForeColor == Color.Red || string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "06-";
                textBox.ForeColor = Color.Black;
            }
        }

        private string GetSelectedRadioButtonText()
        {
            if (radioButton1.Checked) return radioDates[0];
            if (radioButton2.Checked) return radioDates[1];
            if (radioButton3.Checked) return radioDates[2];
            return string.Empty;
        }

        public void ShowError(Label label, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                label.Visible = false;
                label.Text = "";
            }
            else
            {
                label.Text = message;
                label.Visible = true;
            }
        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LaadAanmeldingen();
        }

        private void LaadAanmeldingen()
        {
            var telling = GetCSV.LeesAanmeldingen();

            totaalLabel.Text = $"Totaal aanmeldingen: {telling.Totaal}";
            mei20Label.Text = $"Aanmeldingen 20 Mei: {telling.Mei20}";
            mei27Label.Text = $"Aanmeldingen 27 Mei: {telling.Mei27}";
            juni3Label.Text = $"Aanmeldingen 3 Juni: {telling.Juni3}";
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            AanmeldPaneel.Visible = true;
            BeheerPaneel.Visible = false;
            BeheerInputfield.Text = "";
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {

            string wachtwoord = BeheerInputfield.Text.Trim();

            if (FormValidation.ValidateLogin(wachtwoord, this))
            {
                AanmeldPaneel.Visible = false;
                BeheerPaneel.Visible = true;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpendagApplicatie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            voornaam_Input.Enter += TextBox_Enter;
            achternaam_Input.Enter += TextBox_Enter;
            email_Input.Enter += TextBox_Enter;
            telefoon_Input.Enter += Telefoon_Input_Enter;

            telefoon_Input.Text = "06-";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string voornaam = voornaam_Input.Text;
            string achternaam = achternaam_Input.Text;
            string email = email_Input.Text;
            string telefoon = telefoon_Input.Text;

            bool isVoornaamInvalid = string.IsNullOrWhiteSpace(voornaam);
            bool isAchternaamInvalid = string.IsNullOrWhiteSpace(achternaam);
            bool isEmailInvalid = !Regex.IsMatch(email, @"^[A-Za-z0-9]{2,}@[A-Za-z0-9]{2,}\.[A-Za-z]{1,4}$");
            bool isTelefoonInvalid = !Regex.IsMatch(telefoon, @"^06-\d{8}$");

            if (isVoornaamInvalid)
            {
                voornaam_Input.Text = "Voornaam invalid";
                voornaam_Input.ForeColor = Color.Red;
            }

            if (isAchternaamInvalid)
            {
                achternaam_Input.Text = "Achternaam invalid";
                achternaam_Input.ForeColor = Color.Red;
            }

            if (isEmailInvalid)
            {
                email_Input.Text = "Email invalid";
                email_Input.ForeColor = Color.Red;
            }

            if (isTelefoonInvalid)
            {
                telefoon_Input.Text = "Telefoon invalid";
                telefoon_Input.ForeColor = Color.Red;
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.ForeColor == Color.Red)
            {
                textBox.Clear();
                textBox.ForeColor = Color.Black;
            }
        }

        private void Telefoon_Input_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.ForeColor == Color.Red || string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "06-";
                textBox.ForeColor = Color.Black;
            }
        }
    }
}

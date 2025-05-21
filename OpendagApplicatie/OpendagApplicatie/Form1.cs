using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            Geboortedatum_datePicker.MinDate = new DateTime(2000, 1, 1);
            Geboortedatum_datePicker.Value = Geboortedatum_datePicker.MinDate;
            Form2 form2 = new Form2();
            form2.Show();
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
                Leeftijd = BerekenLeeftijd(Geboortedatum_datePicker.Value),
                SelectedRadioButton = GetSelectedRadioButtonText()
            };

            bool isValid = ValidateForm(data);

            if (isValid)
            {
                SaveDataToCSV(data);
                MessageBox.Show("Succesvol verstuurd!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateForm(dynamic data)
        {
            bool isValid = true;

            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OpendagApp", "OpendagApplicatie", "CSV_FILE");
            string filePath = Path.Combine(folderPath, "form_data.csv");

            if (string.IsNullOrWhiteSpace(data.SelectedRadioButton))
            {
                radioButton1.ForeColor = Color.Red;
                radioButton2.ForeColor = Color.Red;
                radioButton3.ForeColor = Color.Red;
                isValid = false;
            }
            else
            {
                radioButton1.ForeColor = Color.Black;
                radioButton2.ForeColor = Color.Black;
                radioButton3.ForeColor = Color.Black;
            }

            if (string.IsNullOrWhiteSpace(data.Voornaam))
            {
                SetError(voornaam_Input, "Voornaam is niet ingevuld");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(data.Achternaam))
            {
                SetError(achternaam_Input, "Achternaam is niet ingevuld");
                isValid = false;
            }

            if (!Regex.IsMatch(data.Email, @"^[A-Za-z0-9]{2,}@[A-Za-z0-9]{2,}\.[A-Za-z]{1,4}$"))
            {
                SetError(email_Input, "Email adres is ongeldig");
                isValid = false;
            }

            if (!Regex.IsMatch(data.Telefoon, @"^06-\d{8}$"))
            {
                SetError(telefoon_Input, "Telefoonnummer is ongeldig");
                isValid = false;
            }

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var values = line.Split(',');
                    if (values.Length < 4) continue;

                    if (data.Voornaam == values[0] && data.Achternaam == values[1])
                    {
                        SetError(voornaam_Input, "Deze voornaam en achternaam combinatie is al in gebruik!");
                        SetError(achternaam_Input, "Deze voornaam en achternaam combinatie is al in gebruik!");
                        isValid = false;
                    }

                    if (data.Email == values[2])
                    {
                        SetError(email_Input, "Deze email is al in gebruik!");
                        isValid = false;
                    }

                    if (data.Telefoon == values[3])
                    {
                        SetError(telefoon_Input, "Dit telefoonnummer is al in gebruik!");
                        isValid = false;
                    }
                }
            }

            return isValid;
        }


        private void SetError(TextBox textBox, string message)
        {
            textBox.ForeColor = Color.Red;
            textBox.Text = message;
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

        private int BerekenLeeftijd(DateTime geboortedatum)
        {
            DateTime today = DateTime.Today;
            int leeftijd = today.Year - geboortedatum.Year;

            if (today < geboortedatum.AddYears(leeftijd))
                leeftijd--;

            return leeftijd;
        }

        private void SaveDataToCSV(dynamic data)
        {
            // Haal de map op waar de .exe zich bevindt
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Zoek naar een CSV-bestand in dezelfde map
            string[] csvFiles = Directory.GetFiles(exeDirectory, "*.csv");

            string filePath;

            if (csvFiles.Length > 0)
            {
                filePath = csvFiles[0]; // Gebruik het eerste gevonden .csv-bestand
            }
            else
            {
                // Geen CSV-bestand gevonden, dus maak een nieuwe aan met standaardnaam
                filePath = Path.Combine(exeDirectory, "form_data.csv");
            }

            bool fileExists = File.Exists(filePath);

            using (var writer = new StreamWriter(filePath, append: true))
            {
                if (!fileExists)
                {
                    writer.WriteLine("Voornaam,Achternaam,Email,Telefoon,Geboortedatum,RadioButton");
                }

                writer.WriteLine($"{data.Voornaam},{data.Achternaam},{data.Email},{data.Telefoon},{data.Geboortedatum:dd/MM/yyyy},{data.SelectedRadioButton}");
            }
        }
    }
}

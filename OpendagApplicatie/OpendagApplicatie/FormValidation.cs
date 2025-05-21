using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OpendagApplicatie
{
    public static class FormValidation
    {
        public static bool Validate(dynamic data, Form1 form)
        {
            bool isValid = true;

            string filePath = GetCsvPath();

            // Eerst alle foutlabels leegmaken
            form.ShowError(form.VoornaamErrorLabel, "");
            form.ShowError(form.AchternaamErrorLabel, "");
            form.ShowError(form.EmailErrorLabel, "");
            form.ShowError(form.TelefoonErrorLabel, "");
            form.ShowError(form.DatumErrorLabel, "");
            form.ShowError(form.AgeErrorLabel, "");

            // Radio button validatie met foutlabel
            if (string.IsNullOrWhiteSpace(data.SelectedRadioButton))
            {
                form.ShowError(form.DatumErrorLabel, "Kies een datum");
                isValid = false;
            }
            else
            {
                form.ShowError(form.DatumErrorLabel, "");
            }

            if (string.IsNullOrWhiteSpace(data.Voornaam))
            {
                form.ShowError(form.VoornaamErrorLabel, "Voornaam is niet ingevuld");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(data.Achternaam))
            {
                form.ShowError(form.AchternaamErrorLabel, "Achternaam is niet ingevuld");
                isValid = false;
            }

            if (!Regex.IsMatch(data.Email, @"^[A-Za-z0-9]{2,}@[A-Za-z0-9]{2,}\.[A-Za-z]{1,4}$"))
            {
                form.ShowError(form.EmailErrorLabel, "Email adres is ongeldig");
                isValid = false;
            }

            if (!Regex.IsMatch(data.Telefoon, @"^06-\d{8}$"))
            {
                form.ShowError(form.TelefoonErrorLabel, "Telefoonnummer is ongeldig");
                isValid = false;
            }

            if (data.Geboortedatum == DateTime.MinValue)
            {
                form.ShowError(form.AgeErrorLabel, "Selecteer een geldige geboortedatum");
                isValid = false;
            }
            else
            {
                int leeftijd = BerekenLeeftijd(data.Geboortedatum);
                DateTime vijftienPlusEendag = data.Geboortedatum.AddYears(15);
                if (DateTime.Today < vijftienPlusEendag)
                {
                    form.ShowError(form.AgeErrorLabel, "Je moet ouder zijn dan 15 jaar");
                    isValid = false;
                }
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
                        form.ShowError(form.VoornaamErrorLabel, "Deze voornaam & achternaam combinatie is al in gebruik");
                        form.ShowError(form.AchternaamErrorLabel, "Deze voornaam & achternaam combinatie is al in gebruik");
                        isValid = false;
                    }

                    if (data.Email == values[2])
                    {
                        form.ShowError(form.EmailErrorLabel, "Deze email is al in gebruik");
                        isValid = false;
                    }

                    if (data.Telefoon == values[3])
                    {
                        form.ShowError(form.TelefoonErrorLabel, "Dit telefoonnummer is al in gebruik");
                        isValid = false;
                    }
                }
            }

            return isValid;
        }
        public static int BerekenLeeftijd(DateTime geboortedatum)
        {
            DateTime today = DateTime.Today;
            int leeftijd = today.Year - geboortedatum.Year;

            if (today < geboortedatum.AddYears(leeftijd))
                leeftijd--;

            return leeftijd;
        }

        private static string GetCsvPath()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] csvFiles = Directory.GetFiles(exeDirectory, "*.csv");

            if (csvFiles.Length > 0)
                return csvFiles[0];

            return Path.Combine(exeDirectory, "form_data.csv");
        }

        public static bool ValidateLogin(string wachtwoord, Form1 form)
        {
            form.ShowError(form.InloggenErrorLabel, "");

            if (string.IsNullOrWhiteSpace(wachtwoord))
            {
                form.ShowError(form.InloggenErrorLabel, "Wachtwoord is leeg!");
                return false;
            }

            const string correctPassword = "12345";

            if (wachtwoord != correctPassword)
            {
                form.ShowError(form.InloggenErrorLabel, "Wachtwoord is incorrect!");
                return false;
            }

            return true;
        }

    }
}

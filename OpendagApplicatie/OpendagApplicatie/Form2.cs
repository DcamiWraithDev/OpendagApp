using System;
using System.IO;
using System.Windows.Forms;

namespace OpendagApplicatie
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LaadAanmeldingen();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LaadAanmeldingen();
        }

        private void LaadAanmeldingen()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Zoek naar een CSV-bestand in dezelfde map als de .exe
            string[] csvFiles = Directory.GetFiles(exeDirectory, "*.csv");

            if (csvFiles.Length == 0)
            {
                MessageBox.Show("Geen CSV-bestand gevonden in de applicatiemap.");
                return;
            }

            string filePath = csvFiles[0]; // Pak het eerste gevonden bestand

            int countJuni3 = 0;
            int countMei20 = 0;
            int countMei27 = 0;

            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var cleanedLine = line.Replace(",", "").Trim();

                    if (cleanedLine.Contains("3 Juni 2025"))
                        countJuni3++;
                    else if (cleanedLine.Contains("20 Mei 2025"))
                        countMei20++;
                    else if (cleanedLine.Contains("27 Mei 2025"))
                        countMei27++;
                }

                int totaal = countJuni3 + countMei20 + countMei27;

                totaalLabel.Text = $"Totaal aanmeldingen: {totaal}";
                mei20Label.Text = $"Aanmeldingen 20 Mei: {countMei20}";
                mei27Label.Text = $"Aanmeldingen 27 Mei: {countMei27}";
                juni3Label.Text = $"Aanmeldingen 3 Juni: {countJuni3}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij het lezen van het bestand: " + ex.Message);
            }
        }

    }
}

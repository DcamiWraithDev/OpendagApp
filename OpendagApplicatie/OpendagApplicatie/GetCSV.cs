using System;
using System.Collections.Generic;
using System.IO;

namespace OpendagApplicatie
{
    public class AanmeldingTelling
    {
        public int Totaal { get; set; }
        public int Mei20 { get; set; }
        public int Mei27 { get; set; }
        public int Juni3 { get; set; }
    }

    internal static class GetCSV
    {
        public static string GetCsvPath()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] csvFiles = Directory.GetFiles(exeDirectory, "*.csv");

            if (csvFiles.Length > 0)
                return csvFiles[0];

            return Path.Combine(exeDirectory, "form_data.csv");
        }

        public static void SaveToCsv(dynamic data)
        {
            string filePath = GetCsvPath();
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

        public static AanmeldingTelling LeesAanmeldingen()
        {
            string filePath = GetCsvPath();

            int countJuni3 = 0;
            int countMei20 = 0;
            int countMei27 = 0;

            if (!File.Exists(filePath))
                return new AanmeldingTelling();

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

            return new AanmeldingTelling
            {
                Totaal = countJuni3 + countMei20 + countMei27,
                Mei20 = countMei20,
                Mei27 = countMei27,
                Juni3 = countJuni3
            };
        }
    }
}

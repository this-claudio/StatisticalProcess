using StatisticalProcess.Application.Utils.Contracts;
using System.Globalization;

namespace StatisticalProcess.Application.Utils.Dictionaries
{
    public class LimitsCoefficient : ILimitsCoefficient
    {
        public Dictionary<int, decimal> A2 { get; private set; } = new();
        public Dictionary<int, decimal> D3 { get; private set; } = new();
        public Dictionary<int, decimal> D4 { get; private set; } = new();

        public LimitsCoefficient()
        {

            string fileName = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Utils", "Dictionaries", "CoeficientesDeControle.csv");

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"Arquivo '{fileName}' não encontrado.");
                return;
            }


            var linhas = File.ReadAllLines(fileName);

            char separador = linhas[0].Contains(';') ? ';' : ',';


            for (int i = 1; i < linhas.Length; i++)
            {
                string linha = linhas[i];
                if (string.IsNullOrWhiteSpace(linha)) continue;

                string[] partes = linha.Split(separador);

                if (partes.Length < 4)
                {
                    Console.WriteLine($"Linha malformada na linha {i + 1}: {linha}");
                    continue;
                }

                try
                {
                    int samples = int.Parse(partes[0].Trim());
                    decimal a2 = decimal.Parse(partes[1].Trim().Replace(',', '.'), CultureInfo.InvariantCulture);
                    decimal d3 = decimal.Parse(partes[2].Trim().Replace(',', '.'), CultureInfo.InvariantCulture);
                    decimal d4 = decimal.Parse(partes[3].Trim().Replace(',', '.'), CultureInfo.InvariantCulture);

                    A2.Add(samples, a2);
                    D3.Add(samples, d3);
                    D4.Add(samples, d4);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao processar linha {i + 1}: {ex.Message}");
                }
            }

        }


    }
}

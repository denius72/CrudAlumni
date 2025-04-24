using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace CrudAlumni.Models
{
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Matricula { get; set; }  // Gerado automaticamente como ID

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O tipo de endereço é obrigatório")]
        public string TipoEndereco { get; set; }  // Cobrança, Residencial, Correspondência

        [Required(ErrorMessage = "A rua é obrigatória")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "CEP inválido (formato esperado: 00000-000)")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        public string Numero { get; set; }

        public string? Complemento { get; set; } // pode ser null

        [Required(ErrorMessage = "A série é obrigatória")]
        public Serie Serie { get; set; } 

        [Required(ErrorMessage = "O segmento é obrigatório")] // preenchido automaticamente
        public string Segmento { get; set; }

        [Required(ErrorMessage = "O nome do pai é obrigatório")]
        public string NomePai { get; set; }

        [Required(ErrorMessage = "O nome da mãe é obrigatório")]
        public string NomeMae { get; set; }

        // Dicionário de faixa etária
        private static readonly Dictionary<Serie, (int MinIdade, int MaxIdade)> FaixaEtariaPorSerie = new Dictionary<Serie, (int, int)>
        {
            { Serie.G1, (3, 5) },
            { Serie.G2, (3, 5) },
            { Serie.G3, (3, 5) },
            { Serie.PrimeiroAno, (6, 10) },
            { Serie.SegundoAno, (6, 10) },
            { Serie.TerceiroAno, (6, 10) },
            { Serie.QuartoAno, (6, 10) },
            { Serie.QuintoAno, (6, 10) },
            { Serie.SextoAno, (11, 14) },
            { Serie.SetimoAno, (11, 14) },
            { Serie.OitavoAno, (11, 14) },
            { Serie.NonoAno, (11, 14) },
            { Serie.PrimeiroAnoEnsinoMedio, (15, 17) },
            { Serie.SegundoAnoEnsinoMedio, (15, 17) },
            { Serie.TerceiroAnoEnsinoMedio, (15, 17) }
        };

        public bool ValidarIdade()
        {
            var idade = DateTime.Now.Year - DataNascimento.Year;

            if (FaixaEtariaPorSerie.TryGetValue(Serie, out var faixaEtaria))
            {
                return idade >= faixaEtaria.MinIdade && idade <= faixaEtaria.MaxIdade;
            }

            return false;
        }

        public void DefinirSegmento()
        {
            switch (Serie)
            {
                case Serie.G1:
                case Serie.G2:
                case Serie.G3:
                    Segmento = "Infantil";
                    break;
                case Serie.PrimeiroAno:
                case Serie.SegundoAno:
                case Serie.TerceiroAno:
                case Serie.QuartoAno:
                case Serie.QuintoAno:
                    Segmento = "Anos iniciais";
                    break;
                case Serie.SextoAno:
                case Serie.SetimoAno:
                case Serie.OitavoAno:
                case Serie.NonoAno:
                    Segmento = "Anos finais";
                    break;
                case Serie.PrimeiroAnoEnsinoMedio:
                case Serie.SegundoAnoEnsinoMedio:
                case Serie.TerceiroAnoEnsinoMedio:
                    Segmento = "Ensino Médio";
                    break;
            }
        }
    }

    public enum Serie
    {
        G1 = 1,
        G2,
        G3,
        PrimeiroAno,
        SegundoAno,
        TerceiroAno,
        QuartoAno,
        QuintoAno,
        SextoAno,
        SetimoAno,
        OitavoAno,
        NonoAno,
        PrimeiroAnoEnsinoMedio,
        SegundoAnoEnsinoMedio,
        TerceiroAnoEnsinoMedio
    }

    public enum TipoEndereco
    {
        Cobranca,
        Residencial,
        Correspondencia
    }

}

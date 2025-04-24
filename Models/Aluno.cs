using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        public string Complemento { get; set; }

        [Required(ErrorMessage = "A série é obrigatória")]
        public Serie Serie { get; set; }

        [Required(ErrorMessage = "O segmento é obrigatório")]
        public string Segmento { get; set; }

        public string NomePai { get; set; }

        public string NomeMae { get; set; }

        // Dicionário de faixa etária
        private static readonly Dictionary<Serie, (int MinIdade, int MaxIdade)> FaixaEtariaPorSerie = new Dictionary<Serie, (int, int)>
        {
            { Serie.G1, (3, 5) },
            { Serie.G2, (4, 5) },
            { Serie.G3, (5, 5) },
            { Serie.PrimeiroAno, (6, 7) },
            { Serie.SegundoAno, (7, 8) },
            { Serie.TerceiroAno, (8, 9) },
            { Serie.QuartoAno, (9, 10) },
            { Serie.QuintoAno, (10, 11) },
            { Serie.SextoAno, (11, 12) },
            { Serie.SetimoAno, (12, 13) },
            { Serie.OitavoAno, (13, 14) },
            { Serie.NonoAno, (14, 15) },
            { Serie.PrimeiroAnoEnsinoMedio, (15, 16) },
            { Serie.SegundoAnoEnsinoMedio, (16, 17) },
            { Serie.TerceiroAnoEnsinoMedio, (17, 17) }
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

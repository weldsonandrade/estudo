namespace Core.Models
{
    public class Parcela
    {
        public int Numero { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }

        public double ValorPrevisto { get; set; }

        public double ValorRealizado { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models
{
    public class Contrato
    {
        public Contrato()
        {
            Parcelas = new List<Parcela> { };
        }

        public Contrato(int numero, decimal taxaJurosMensal, decimal valor, List<Parcela> parcelas)
        {
            Id = Guid.NewGuid().ToString();
            Numero = numero;
            DataCriacao = DateTime.Now;
            TaxaJurosMensal = taxaJurosMensal;
            Valor = valor;

            if (parcelas.Count <= 0)
                throw new ArgumentException("O contrato deve ter no mínimo uma parcela.");

            Parcelas = parcelas;
        }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public int Numero { get; set; }

        public DateTime DataCriacao { get; set; }

        public decimal TaxaJurosMensal { get; set; }

        public decimal Valor { get; set; }

        public int QuantidadeParcelas => Parcelas.Count;

        public List<Parcela> Parcelas { get; set; }
    }
}

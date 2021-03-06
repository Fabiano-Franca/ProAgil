using System;

namespace ProAgil.Dominio
{
    public class Lote
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }

        // (Lote) n -->  1 (Evento)
        public int EventoId { get; set; }
        public Evento Evento { get; }
    }
}
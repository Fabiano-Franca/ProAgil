namespace ProAgil.Dominio
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }

        // (RedeSocial) n -->  1 (Evento)
        public int? EventoId { get; set; }
        public Evento Evento { get; }


        // (RedeSocial) n -->  1 (Palestrante)
        public int? PalestranteId { get; set; }
        public Palestrante Palestrante { get; }
    }
}
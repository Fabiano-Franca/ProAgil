namespace ProAgil.Dominio
{
    public class PalestranteEvento
    {
        // (PalestranteEvento) n -->  1 (Palestrante)
        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }

        // (PalestranteEvento) n -->  1 (Evento)
        public int EventoId { get; set; }
        public Evento Evento { get; }
    }
}
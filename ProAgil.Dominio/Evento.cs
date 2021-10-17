using System;
using System.Collections.Generic;

namespace ProAgil.Dominio
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // (Evento) 1 -->  n (Lote)
        public List<Lote> Lotes { get; set; }
        
        // (Evento) 1 -->  n (RedeSocial)
        public List<RedeSocial> RedesSociais { get; set; }
        
        // (Evento) 1 -->  n (PalestranteEvento)
        public List<PalestranteEvento> PalestranteEventos { get; set; }


    }
}
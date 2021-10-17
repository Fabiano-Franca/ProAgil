using System.Threading.Tasks;
using ProAgil.Dominio;

namespace ProAgil.Repositorio
{
    public interface IProAgilRepositorio
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Eventos
        Task<Evento[]> GetAllEventoAsync(bool includePAlestrantes);
        Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes);
        Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes);

        //Palestrante
        Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos);
    }
}
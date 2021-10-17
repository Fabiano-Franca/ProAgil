using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Dominio;

namespace ProAgil.Repositorio
{
    public class ProAgilRepositorio : IProAgilRepositorio
    {
        private readonly ProAgilContext _context;

        //ctor
        public ProAgilRepositorio(ProAgilContext context)
        {
            _context = context;
            //NoTRacking Geral
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            //Se for maior que zero o retorno, é porque salvou. Retornando assim, o valor de verdadeiro.
            return (await _context.SaveChangesAsync()) > 0;
        }

        //EVENTO
        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false) //valor padrao false
        {
            //Pega a query de eventos do banco com o Lote e RedesSociais
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            //Se foi passado true no parâmetro é incluido na query, também PalestranteEventos e Palestrante
            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.AsNoTracking()
                        .OrderByDescending(c => c.DataEvento);

            //Retorna o array de Eventos
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes)
        {
            //Pega a query de eventos do banco com o Lote e RedesSociais
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            //Se foi passado true no parâmetro é incluido na query, também PalestranteEventos e Palestrante
            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.AsNoTracking()
                .OrderByDescending(c => c.DataEvento)
                .Where(c => c.Tema.ToLower().Contains(tema.ToLower()));

            //Retorna o array de Eventos
            return await query.ToArrayAsync();
        }


        public async Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes)
        {
            //Pega a query de eventos do banco com o Lote e RedesSociais
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            //Se foi passado true no parâmetro é incluido na query, também PalestranteEventos e Palestrante
            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.AsNoTracking()
                    .OrderByDescending(c => c.DataEvento)
                    .Where(c => c.Id == EventoId);

            //Retorna o array de Eventos
            return await query.FirstOrDefaultAsync();
        }


        //PALESTRANTE
        public async Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestranteEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.AsNoTracking()
                .OrderBy(p => p.Nome)
                .Where(p => p.Id == PalestranteId);

            //Retorna o array de Eventos
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestranteEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.AsNoTracking()
                        .Where(p => p.Nome.ToLower().Contains(name.ToLower()));

            //Retorna o array de Eventos
            return await query.ToArrayAsync();
        }

    }
}
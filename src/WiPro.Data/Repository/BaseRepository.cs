using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WiPro.Data.Context;
using WiPro.Domain.Entities;
using WiPro.Domain.Entities.DTOs;
using WiPro.Domain.Interfaces;

namespace WiPro.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly WiProContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(WiProContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public async Task<Cliente> GetCliente(Guid id)
        {
            IQueryable<Cliente> query = _context.Clientes.Include(c => c.Locacao).Where(c => c.Id == id);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Cliente> GetCliente(string cpf)
        {
            IQueryable<Cliente> query = _context.Clientes.Where(c => c.CPF == cpf);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            IQueryable<Cliente> query = _context.Clientes.Include(c => c.Locacao).ThenInclude(l => l.Filmes);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Filme> GetFilme(Guid id)
        {
            IQueryable<Filme> query = _context.Filmes.Where(f => f.Id == id);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Filme>> GetFilmes()
        {
            IQueryable<Filme> query = _context.Filmes;

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Locacao> GetLocacao(Guid id)
        {
            IQueryable<Locacao> query = _context.Locacoes.Include(l => l.Cliente).Include(l => l.Filmes);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Locacao>> GetLocacao()
        {
            IQueryable<Locacao> query = _context.Locacoes.Include(l => l.Cliente).Include(l => l.Filmes);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Locacao> PostLocacao(LocacaoDTO locacaoDTO)
        {
            var locacao = new Locacao();
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == locacaoDTO.ClienteId);
                if (cliente == null) throw new Exception("Cliente não cadastrado");

                var filmes = new List<Filme>();

                for (int i = 0; i < locacaoDTO.FilmesIds.Count(); i++)
                {
                    var filmesIds = locacaoDTO.FilmesIds.ToList();
                    var filme = await _context.Filmes.FirstOrDefaultAsync(f => f.Id == filmesIds[i]);

                    if (filme == null) throw new Exception("Filme não cadastrado");
                    if (!filme.Disponivel) throw new Exception($"Filme {filme.Nome} não está disponível");

                    filme.Disponivel = false;
                    filmes.Add(filme);
                }

                locacao.Id = Guid.NewGuid();
                locacao.Cliente = cliente;
                locacao.ClienteId = cliente.Id;
                locacao.Filmes = filmes;

                _context.Add(locacao);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return locacao;
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }

                _dataset.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public async Task<Cliente> InsertCliente(Cliente cliente)
        {
            try
            {
                if (!await _context.Clientes.AsNoTracking().AnyAsync(c => c.CPF == cliente.CPF))
                {
                    cliente.Id = Guid.NewGuid();
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Cliente já cadastrado");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return cliente;
        }

        private bool FilmeDisponivel(Filme filme)
        {
            return filme.Disponivel;
        }
    }
}
using API02.Data;
using API02.Models;
using API02.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API02.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaDeVendasDbContext _dbContext;

        public UsuarioRepositorio(SistemaDeVendasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            var usuario = await BuscarPorId(id);
            if (usuario == null) return false;

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            var usuarioDb = await BuscarPorId(id);
            if (usuarioDb == null) return null;

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.DataNascimento = usuario.DataNascimento;

            _dbContext.Usuarios.Update(usuarioDb);
            await _dbContext.SaveChangesAsync();
            return usuarioDb;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
    }
}
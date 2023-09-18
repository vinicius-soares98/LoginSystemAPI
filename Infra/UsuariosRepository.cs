using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TesteAPI.Model;

namespace TesteAPI.Infra
{
	public class UsuariosRepository : IUsuariosRepository
	{
		private readonly ConnectionContext _context = new ConnectionContext();
		public void Cadastrar(Usuarios usuario)
		{
			_context.Usuarios.Add(usuario);
			_context.SaveChanges();
		}
		public bool ExisteUsuarioComNomeOuEmail(string usuario)
		{
			return _context.Usuarios.Any(u => u.usuario == usuario);
		}
		public async Task<Usuarios> BuscarPorNome(string usuario)
		{
			return await _context.Usuarios.FirstOrDefaultAsync(u => u.usuario == usuario);
		}		
		public void Atualizar(Usuarios usuario)
		{
			_context.Usuarios.Update(usuario);
			_context.SaveChanges();
		}
	}
}

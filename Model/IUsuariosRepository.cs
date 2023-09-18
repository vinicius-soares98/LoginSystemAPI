namespace TesteAPI.Model
{
	public interface IUsuariosRepository
	{
		void Cadastrar(Usuarios usuario);
		//void logar(Usuarios usuario);
		public bool ExisteUsuarioComNomeOuEmail(string usuario);
		public Task<Usuarios> BuscarPorNome(string usuario);
		public void Atualizar(Usuarios usuario);
	}
}

using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TesteAPI.Model;
using TesteAPI.ViewModel;
using System.Security.Cryptography;

namespace TesteAPI.Controllers
{
	[ApiController]
	[Route("api/v1/")]
	public class UsuariosController : ControllerBase
	{
		private readonly IUsuariosRepository _usuariosRepository;
		public UsuariosController(IUsuariosRepository usuariosRepository)
		{
			_usuariosRepository = usuariosRepository ?? throw new ArgumentNullException();
		}
		[Route("Cadastro")]
		[HttpPost]
		public IActionResult Cadastrar(UsuariosViewModel usuariosView)
		{
			var usuario = new Usuarios(usuariosView.nome, usuariosView.senha);
			if (_usuariosRepository.ExisteUsuarioComNomeOuEmail(usuariosView.nome))
			{
				return BadRequest("Já existe um usuário cadastrado com o mesmo nome ou email.");
			}
			if (usuario.senha == "123")
			{
				return BadRequest("Senha muito fraca");
			}

			Criptografia c = new Criptografia(SHA512.Create());
			usuario.senha = c.CriptografarSenha(usuariosView.senha);	
			_usuariosRepository.Cadastrar(usuario);
			if(!ModelState.IsValid)
			{
				return BadRequest();
			}
			return Ok("Usuário cadastrado com sucesso!");
		}
		[Route("Login")]
		[HttpPost]
		public async Task <ActionResult<Usuarios>> Logar(UsuariosViewModel usuariosView)
		{
			var senha ="";
			Usuarios usuario = await _usuariosRepository.BuscarPorNome(usuariosView.nome);
			if(usuario == null)
			{
				return BadRequest("Usuário não encontrado");
			}
			Criptografia c = new Criptografia(SHA512.Create());
			senha = c.CriptografarSenha(usuariosView.senha);
			if (usuario.senha == senha && usuario.usuario == usuariosView.nome)
			{
				return Ok("Login efetuado com sucesso!");
			}
			else
			{
				return BadRequest("Usuário ou senha inválido!");
			}
		}
		[Route("TrocarSenha")]
		[HttpPost]
		public async Task<ActionResult<Usuarios>> AtualizarSenha(UsuariosViewModel usuariosView)
		{
			Usuarios usuario = await _usuariosRepository.BuscarPorNome(usuariosView.nome);
			if (usuario == null)
			{
				return BadRequest("Usuário não encontrado");
			}
			Criptografia c = new Criptografia(SHA512.Create());
			usuario.senha = c.CriptografarSenha(usuariosView.senha);
			_usuariosRepository.Atualizar(usuario);
			return Ok(usuario);
		}

	}
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TesteAPI.Model
{
	public class Usuarios
	{
		[Key]
		public int id { get; set; }
		[Required]
		public string usuario { get; set; }
		[Required]
		public string senha { get; set; }

		public Usuarios(string usuario, string senha)
		{
			this.usuario = usuario;
			this.senha = senha;
		}
	}
}

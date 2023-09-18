using System.ComponentModel.DataAnnotations;

namespace TesteAPI.ViewModel
{
	public class UsuariosViewModel
	{
		[Required(ErrorMessage ="O campo usuario é obrigatório")]
		public string nome { get; set; }
		[StringLength(10, MinimumLength = 4, ErrorMessage = "O campo senha deve possuir entre 4 e 10 caracteres")]
		[Required(ErrorMessage = "O campo senha é obrigatório")]
		public string senha { get; set; }
	}
}

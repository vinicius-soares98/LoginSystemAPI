using System.Security.Cryptography;
using System.Text;

namespace TesteAPI.Controllers
{
	public class Criptografia
	{
		private HashAlgorithm _algoritmo;
		public Criptografia(HashAlgorithm algoritmo)
		{
			_algoritmo = algoritmo;
		}
		public string CriptografarSenha(string senha)
		{
			var encodeValue = Encoding.UTF8.GetBytes(senha);
			var encryptedPassword = _algoritmo.ComputeHash(encodeValue);

			var sb = new StringBuilder();
			foreach (var caracter in encryptedPassword)
			{
				sb.Append(caracter.ToString("X2"));
			}
			return sb.ToString();
		}
	}
}

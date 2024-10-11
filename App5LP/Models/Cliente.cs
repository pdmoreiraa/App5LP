using System.ComponentModel.DataAnnotations;

namespace App5LP.Models
{
    public class Cliente
    {
        [Display(Name = "Código")]
        public int? idCli { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]

        public string nomeCli { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string email { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter exatamente 11 dígitos.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "O CPF deve conter apenas números e ter 11 dígitos.")]
        public string CPF { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [StringLength(11, ErrorMessage = "O Telefone deve ter no máximo 11 caracteres.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "O telefone deve conter apenas números e ter 11 dígitos.")]
        public string telefone { get; set; }
    }
}

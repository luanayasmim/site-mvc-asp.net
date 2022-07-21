using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Informe o nome!")] //Utilizando o data annotations
        public string Nome { get; set; }

        [Required(ErrorMessage ="Informe o e-mail!")]
        [EmailAddress(ErrorMessage ="E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Informe o contato!")]
        [Phone(ErrorMessage ="Número inválido")]
        public string Contato { get; set; }
    }
}

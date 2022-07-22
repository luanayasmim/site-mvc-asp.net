using AplicacaoWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Login { get; set; }
        public string EmailUsuario { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        //O sinal de interrogação define que a propriedade pode
        public DateTime? DataAtualizacao { get; set; }
    }
}

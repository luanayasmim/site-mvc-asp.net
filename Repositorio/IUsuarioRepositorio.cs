using AplicacaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel ListarPorID(int id);

        //Read
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        //Atualizar
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
    }
}

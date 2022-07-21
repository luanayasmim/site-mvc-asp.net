using AplicacaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorID(int id);

        //Read
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        //Atualizar
        ContatoModel Atualizar(ContatoModel contato);

    }
}

using AplicacaoWeb.Data;
using AplicacaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorID(id);
            if (usuarioDB == null) throw new SystemException("Houve um erro para apagar o usuário");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorID(usuario.Id);
            if(usuarioDB==null) throw new SystemException("Houve um erro na atualização do usuário");

            usuarioDB.NomeUsuario = usuario.NomeUsuario;
            usuarioDB.EmailUsuario = usuario.EmailUsuario;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.Senha = usuario.Senha;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel ListarPorID(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}

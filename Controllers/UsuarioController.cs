using AplicacaoWeb.Models;
using AplicacaoWeb.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        //Método POST
        [HttpPost]
        public IActionResult Criar(UsuarioModel p_usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(p_usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso ༼ つ ◕_◕ ༽つ";
                    return RedirectToAction("Index");
                }

                return View(p_usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $@"Não foi possivel cadastrar o usuário¯\(°_o)/¯ Detalhe do erro...  {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

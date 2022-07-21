using AplicacaoWeb.Models;
using AplicacaoWeb.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Controllers
{
    public class Contato : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public Contato(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }


        //Chamando Telas
        public IActionResult Index()
        {
            var contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorID(id);
            return View(contato);
        }
        public IActionResult Apagar()
        {
            return View();
        }

        //Método POST
        [HttpPost]
        public IActionResult Criar(ContatoModel p_contato)
        {
            _contatoRepositorio.Adicionar(p_contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel p_contato)
        {
            _contatoRepositorio.Atualizar(p_contato);
            return RedirectToAction("Index");
        }
    }
}

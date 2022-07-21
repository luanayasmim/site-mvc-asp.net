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
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorID(id);
            return View(contato);
        }

        //Método GET
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso ༼ つ ◕_◕ ༽つ";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["MensagemSucesso"] = @"Não foi possivel apagar o contato¯\(°_o)/¯";

                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $@"Não foi possivel apagar o contato¯\(°_o)/¯ Detalhe do erro...  {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //Método POST
        [HttpPost]
        public IActionResult Criar(ContatoModel p_contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(p_contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso ༼ つ ◕_◕ ༽つ";
                    return RedirectToAction("Index");
                }

                return View(p_contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $@"Não foi possivel cadastrar o contato¯\(°_o)/¯ Detalhe do erro...  {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel p_contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(p_contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso ༼ つ ◕_◕ ༽つ ";
                    return RedirectToAction("Index");

                }

                return View("Editar", p_contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $@"Não foi possivel alterar o contato ¯\(°_o)/¯   Detalhe do erro... {erro.Message}";
                return RedirectToAction("Index");
            }

        }

    }
}


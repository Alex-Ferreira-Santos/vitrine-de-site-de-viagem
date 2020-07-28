using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atividade_2_Alex_Ferreira_Santos1.Models;
using Microsoft.AspNetCore.Http;
namespace Atividade_2_Alex_Ferreira_Santos1.Controllers
{
    public class PacotesController : Controller
    {
        public IActionResult Cadastro()
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
                return RedirectToAction("Login","Usuario");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(PacoteDeViagens p)
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
                return RedirectToAction("Login","Usuario");
            PacoteDeViagensRepository pa =new PacoteDeViagensRepository();
            p.usuario=HttpContext.Session.GetString("loginUsuario");
            pa.insert(p);
            ViewBag.mensagem=$"Pacote {p.nome} cadastrado com sucesso";
            return View();
        }
        
        public IActionResult Lista()
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
                return RedirectToAction("Login","Usuario");
            PacoteDeViagensRepository pa =new PacoteDeViagensRepository();
            List<PacoteDeViagens> pacote=pa.Lista();
            return View(pacote);
        }
        public IActionResult Edicao()
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
                return RedirectToAction("Login","Usuario");
            return View();
        }
        [HttpPost]
        public IActionResult Edicao(PacoteDeViagens p)
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
                return RedirectToAction("Login","Usuario");
            PacoteDeViagensRepository pa =new PacoteDeViagensRepository();
            p.usuario=HttpContext.Session.GetString("loginUsuario");
            pa.Update(p);
            ViewBag.mensagem=$"Pacote {p.nome} editado com sucesso";
            return View();
        }
        public IActionResult Excluir()
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
                return RedirectToAction("Login","Usuario");
            return View();
        }
        [HttpPost]
        public IActionResult Excluir(PacoteDeViagens p)
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
                return RedirectToAction("Login","Usuario");
            PacoteDeViagensRepository pa = new PacoteDeViagensRepository();
            pa.Delete(p);
            ViewBag.mensagem=$"Pacote {p.nome} deletado com sucesso";
            return View();
        }
    }
}
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
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
            {
                return RedirectToAction("Login");
            }
            else{
                if(HttpContext.Session.GetInt32("tipoUsuario")==1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
        }
        [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
            {
                return RedirectToAction("Login");
            }
            UsuarioRepository ur=new UsuarioRepository();
            ur.insert(u);
            ViewBag.mensagem=$"Usuário {u.nome} cadastrado com sucesso!";
            return View();
        }
        public IActionResult Listar()
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if(HttpContext.Session.GetInt32("tipoUsuario")==1)
                {
                    UsuarioRepository user=new UsuarioRepository();
                    List<Usuario> usuario=user.Lista();
                    return View(usuario);
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            UsuarioRepository ur=new UsuarioRepository();
            Usuario usuario=ur.login(u);
            if(usuario!=null)
            {
                ViewBag.mensagem="Você está logado";
                HttpContext.Session.SetInt32("idUsuario",usuario.id);
                HttpContext.Session.SetString("loginUsuario",usuario.login);
                HttpContext.Session.SetInt32("tipoUsuario",usuario.tipo);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.mensagem="Falha no login";
                return View();
            }   
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Edicao()
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
            {
                return RedirectToAction("Login");
            }
            else{
                if(HttpContext.Session.GetInt32("tipoUsuario")==1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
        }
        [HttpPost]
        public IActionResult Edicao(Usuario u)
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
            {
                return RedirectToAction("Login");
            }
            UsuarioRepository ur=new UsuarioRepository();
            ur.Update(u);
            ViewBag.mensagem=$"Usuário {u.nome} modificado com sucesso";
            return View();
        }
        public IActionResult Excluir()
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
            {
                return RedirectToAction("Login");
            }
            else{
                if(HttpContext.Session.GetInt32("tipoUsuario")==1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
        }
        [HttpPost]
        public IActionResult Excluir(Usuario u)
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
            {
                return RedirectToAction("Login");
            }
            UsuarioRepository ur=new UsuarioRepository();
            ur.Delete(u);
            ViewBag.mensagem=$"Usuário {u.login} deletado com sucesso";
            return View();
        }
    }
}
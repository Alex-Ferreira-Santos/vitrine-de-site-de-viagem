using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atividade_2_Alex_Ferreira_Santos1.Models;

namespace Atividade_2_Alex_Ferreira_Santos1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            PacoteDeViagensRepository pa =new PacoteDeViagensRepository();
            List<PacoteDeViagens> pacote=pa.Lista();
            return View(pacote);
        }
        public IActionResult FaleConosco()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FaleConosco(Usuario u)
        {
            ViewBag.mensagem="Mensagem Enviada com sucesso!";
            return View();
        }
        public IActionResult QuemSomos()
        {
            return View();
        }
    }
}

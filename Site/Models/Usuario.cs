using System;

namespace Atividade_2_Alex_Ferreira_Santos1.Models
{
    public class Usuario
    {
        public int id{get;set;}
        public string nome{get;set;}
        public DateTime nascimento{get;set;}
        public string login{get;set;}
        public string senha{get;set;}
        public int tipo{get;set;}
    }
}
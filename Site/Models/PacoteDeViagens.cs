using System;

namespace Atividade_2_Alex_Ferreira_Santos1.Models
{
    public class PacoteDeViagens
    {
        public int id{get;set;}
        public string imagem{get;set;}
        public string nome{get;set;}
        public string origem{get;set;}
        public string destino{get;set;}
        public string atrativo{get;set;}
        public DateTime saida{get;set;}
        public DateTime retorno{get;set;}
        public string usuario{get;set;}
    }
}
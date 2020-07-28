using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;

namespace Atividade_2_Alex_Ferreira_Santos1.Models
{
    public class PacoteDeViagensRepository : Repository
    {
        public void insert(PacoteDeViagens p)
        {
            conexao.Open();
            string sql="INSERT INTO Pacote(imagem, nomeDoPacote, origemDoPacote, destinoDoPacote, atrativos, saida, retorno,usuario) VALUES(@imagem, @nome, @origem, @destino, @atrativo, @saida, @retorno, @usuario);";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@imagem",p.imagem);
            comando.Parameters.AddWithValue("@nome",p.nome);
            comando.Parameters.AddWithValue("@origem",p.origem);
            comando.Parameters.AddWithValue("@destino",p.destino);
            comando.Parameters.AddWithValue("@atrativo",p.atrativo);
            comando.Parameters.AddWithValue("@saida",p.saida);
            comando.Parameters.AddWithValue("@retorno",p.retorno);
            comando.Parameters.AddWithValue("@usuario",p.usuario);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<PacoteDeViagens> Lista()
        {
            conexao.Open();
            string sql="SELECT * FROM Pacote";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            MySqlDataReader reader=comando.ExecuteReader();
            List<PacoteDeViagens> lista=new List<PacoteDeViagens>();
            while (reader.Read())
            {
                PacoteDeViagens u=new PacoteDeViagens();
                u.id=reader.GetInt32("id");
                if(!reader.IsDBNull(reader.GetOrdinal("imagem")))
                    u.imagem=reader.GetString("imagem");
                if(!reader.IsDBNull(reader.GetOrdinal("nomeDoPacote")))
                    u.nome=reader.GetString("nomeDoPacote");
                if(!reader.IsDBNull(reader.GetOrdinal("origemDoPacote")))
                    u.origem=reader.GetString("origemDoPacote");
                if(!reader.IsDBNull(reader.GetOrdinal("destinoDoPacote")))
                    u.destino=reader.GetString("destinoDoPacote");
                if(!reader.IsDBNull(reader.GetOrdinal("atrativos")))
                    u.atrativo=reader.GetString("atrativos");
                if(!reader.IsDBNull(reader.GetOrdinal("saida")))
                    u.saida=reader.GetDateTime("saida");
                if(!reader.IsDBNull(reader.GetOrdinal("retorno")))
                    u.retorno=reader.GetDateTime("retorno");
                if(!reader.IsDBNull(reader.GetOrdinal("usuario")))
                    u.usuario=reader.GetString("usuario");
                lista.Add(u);
            }
            conexao.Close();
            return lista;
        }
        public void Update(PacoteDeViagens p)
        {
            conexao.Open();
            string sql="UPDATE Pacote set imagem=@imagem,nomeDoPacote=@nome,origemDoPacote=@origem, destinoDoPacote=@destino,atrativos=@atrativo,saida=@saida,retorno=@retorno,usuario=@usuario where id=@id";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@id",p.id);
            comando.Parameters.AddWithValue("@imagem",p.imagem);
            comando.Parameters.AddWithValue("@nome",p.nome);
            comando.Parameters.AddWithValue("@origem",p.origem);
            comando.Parameters.AddWithValue("@destino",p.destino);
            comando.Parameters.AddWithValue("@atrativo",p.atrativo);
            comando.Parameters.AddWithValue("@saida",p.saida);
            comando.Parameters.AddWithValue("@retorno",p.retorno);
            comando.Parameters.AddWithValue("@usuario",p.usuario);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void Delete(PacoteDeViagens p)
        {
            conexao.Open();
            string sql="DELETE FROM Pacote WHERE id=@id AND nomeDoPacote=@nome";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@id",p.id);
            comando.Parameters.AddWithValue("@nome",p.nome);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}
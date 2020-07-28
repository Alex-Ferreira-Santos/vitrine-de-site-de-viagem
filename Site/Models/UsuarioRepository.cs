using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace Atividade_2_Alex_Ferreira_Santos1.Models
{
    public class UsuarioRepository : Repository
    {
        public void insert(Usuario u)
        {
            conexao.Open();
            string sql="INSERT INTO Usuario(nomeDeUsuario, dataDeNascimento, login, senha, tipo) VALUES(@nome, @nascimento, @login, @senha, @tipo)";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@nome",u.nome);
            comando.Parameters.AddWithValue("@nascimento",u.nascimento);
            comando.Parameters.AddWithValue("@login",u.login);
            comando.Parameters.AddWithValue("@senha",u.senha);
            comando.Parameters.AddWithValue("@tipo",u.tipo);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<Usuario> Lista()
        {
            conexao.Open();
            string sql="SELECT * FROM Usuario";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            MySqlDataReader reader=comando.ExecuteReader();
            List<Usuario> lista=new List<Usuario>();
            while (reader.Read())
            {
                Usuario u=new Usuario();
                u.id=reader.GetInt32("id");
                if (!reader.IsDBNull(reader.GetOrdinal("nomeDeUsuario")))
                    u.nome=reader.GetString("nomeDeUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("dataDeNascimento")))
                    u.nascimento=reader.GetDateTime("DataDeNascimento");
                if(!reader.IsDBNull(reader.GetOrdinal("login")))
                    u.login=reader.GetString("login");
                if(!reader.IsDBNull(reader.GetOrdinal("senha")))
                    u.senha=reader.GetString("senha");
                if(!reader.IsDBNull(reader.GetOrdinal("tipo")))
                    u.tipo=reader.GetInt32("tipo");
                lista.Add(u);
            }
            conexao.Close();
            return lista;
        }
        public Usuario login(Usuario u)
        {
            conexao.Open();
            string sql="SELECT * FROM Usuario WHERE login = @login AND senha = @senha";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@login",u.login);
            comando.Parameters.AddWithValue("@senha",u.senha);
            comando.Parameters.AddWithValue("@tipo",u.tipo);
            MySqlDataReader reader=comando.ExecuteReader();
            Usuario usr=null;
            if(reader.Read())
            {
                usr=new Usuario();
                usr.id=reader.GetInt32("id");
                if(!reader.IsDBNull(reader.GetOrdinal("login")))
                    usr.login=reader.GetString("login");
                if(!reader.IsDBNull(reader.GetOrdinal("senha")))
                    usr.senha=reader.GetString("senha");
                usr.tipo=reader.GetInt32("tipo");
            }
            conexao.Close();
            return usr;
        }
        public void Update(Usuario u)
        {
            conexao.Open();
            string sql="UPDATE usuario set tipo=@tipo,login=@login,senha=@senha where id=@id";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@id",u.id);
            comando.Parameters.AddWithValue("@login",u.login);
            comando.Parameters.AddWithValue("@senha",u.senha);
            comando.Parameters.AddWithValue("@tipo",u.tipo);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void Delete(Usuario u)
        {
            //não está funcionando
            conexao.Open();
            string sql="DELETE FROM Usuario WHERE id=@id AND login=@login";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@id",u.id);
            comando.Parameters.AddWithValue("@login",u.login);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}
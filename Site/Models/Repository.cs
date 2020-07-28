using MySql.Data.MySqlClient;

namespace Atividade_2_Alex_Ferreira_Santos1.Models
{
    public abstract class Repository
    {
        protected const string _strConexao = "Database=viagem;Data Source=localhost;User Id=root;convert zero datetime=True;";
        protected MySqlConnection conexao=new MySqlConnection(_strConexao);
    }
}
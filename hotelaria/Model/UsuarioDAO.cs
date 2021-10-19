using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace hotelariaX.Model
{
    class UsuarioDAO
    {
        readonly MySqlCommand cmd = new MySqlCommand();
        Conexao con = new Conexao();
        readonly MySqlDataReader dr; //armazena dados do banco
        MySqlDataAdapter da = new MySqlDataAdapter();
        readonly DataTable dt = new DataTable();  //using System.Data;

        public  DataTable ListarUsuarios()
        {
            //http://www.macoratti.net/18/09/c_crudcbo1.htm
            cmd.CommandText = "SELECT id,nome,cpf,email,senha, nivel, status FROM users";
            da.SelectCommand = cmd;
            try
            {
                cmd.Connection = con.conectar();
                dt.Clear();
                da.Fill(dt);

                con.desconectar();
            }
            catch (Exception err)
            {
                //Futuramente gerar log de erro e emitir tela de erro
                Console.WriteLine("LoginDaoComandos: listarUsuarios: Erro =" + err.Message);
            }
            return dt;
        }


        public DataTable ListarUsuariosPesquisa( string nome)
        {
            //http://www.macoratti.net/18/09/c_crudcbo1.htm
            //melhorar color parâmetro igual da rotina do  INSERT
            cmd.CommandText = "SELECT id,nome,cpf,email,senha, nivel, status FROM users WHERE nome LIKE '%"+nome+"%'";
            da.SelectCommand = cmd;
            try
            {
                cmd.Connection = con.conectar();
                dt.Clear();
                da.Fill(dt);

                con.desconectar();
            }
            catch (Exception err)
            {
                //Futuramente gerar log de erro e emitir tela de erro
                Console.WriteLine("LoginDaoComandos: listarUsuarios: Erro =" + err.Message);
            }
            return dt;
        }

        internal bool InserirDadosUsuario(Usuario dadosUsuario)
        {
            String query = "INSERT INTO users (nome,cpf,email,senha,nivel,status) " +
                "VALUES (@nome,@cpf,@email,@senha,@nivel,@status)";
            cmd.CommandText = query;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nome", dadosUsuario.Nome);
            cmd.Parameters.AddWithValue("@cpf", dadosUsuario.Cpf);
            cmd.Parameters.AddWithValue("@email", dadosUsuario.Email);
            cmd.Parameters.AddWithValue("@senha", dadosUsuario.Senha);
            cmd.Parameters.AddWithValue("@nivel", dadosUsuario.Nivel);
            cmd.Parameters.AddWithValue("@status", dadosUsuario.Status);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery(); // executa ao cmd SQL
                con.desconectar();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        internal bool AtualizacaoDadosUsuario(Usuario dadosUsuario)
        {
            String query = "UPDATE users SET nome=@nome,cpf=@cpf,email=@email,senha=@senha," +
                "nivel=@nivel, status=@status WHERE id=@id";
            cmd.Parameters.Clear();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", dadosUsuario.Id);
            cmd.Parameters.AddWithValue("@nome", dadosUsuario.Nome);
            cmd.Parameters.AddWithValue("@cpf", dadosUsuario.Cpf);
            cmd.Parameters.AddWithValue("@email", dadosUsuario.Email);
            cmd.Parameters.AddWithValue("@senha", dadosUsuario.Senha);
            cmd.Parameters.AddWithValue("@nivel", dadosUsuario.Nivel);            
            cmd.Parameters.AddWithValue("@status", dadosUsuario.Status);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery(); // executa ao cmd SQL
                con.desconectar();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}

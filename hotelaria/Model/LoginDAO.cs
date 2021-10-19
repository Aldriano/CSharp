using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace hotelariaX.Model
{
    class LoginDAO
    {
        MySqlCommand cmd = new MySqlCommand();
        Conexao con = new Conexao();
        MySqlDataReader dr; //armazena dados do banco
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();  //using System.Data;

        Login dadosUsers = new Login();

        public Login validarLogin(String email, String senha)
        {
            String query = "SELECT id,nome,status, nivel FROM users WHERE email=@pEmail AND senha = @password AND status=@status";
            cmd.Parameters.Clear();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@pEmail", email);
            cmd.Parameters.AddWithValue("@password", senha);
            cmd.Parameters.AddWithValue("@status", "Ativo");

            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)  // achou
                {
                    while (dr.Read())
                    {
                        dadosUsers.Id = dr.GetInt32(0);
                        dadosUsers.Nome = dr.GetString(1);
                        dadosUsers.Status = dr.GetString(2);
                        dadosUsers.Nivel = dr.GetString(3);
                    }
                    //Console.WriteLine("LoginDaoComandos: validarLogin: dr.HasRows = {0}", dr.HasRows);
                    return dadosUsers; //true
                }
                con.desconectar();
                dr.Close();
            }
            catch (Exception err)
            {
                //throw;
                Console.WriteLine("LoginDaoComandos: validarLogin: Erro =" + err.Message);
            }
            return dadosUsers; // false;
        }
    }
}

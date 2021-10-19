using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ApiLogin.Model;
using ApiLogin.Services;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Newtonsoft.Json;

namespace ApiLogin.Model
{
 
    public class LoginDAO
    {
        public static MySqlConnection conn;
        public static Login Get(string username, string password)
        {
            var users = new List<Login>();
            users.Add(new Login { email = "batman", senha = "batman" });
            return users.Where(x => x.email.ToLower() == username.ToLower() && x.senha == password.ToLower()).FirstOrDefault();
        }

        public static String Validar(string email, string senha) {
            conn = new MySqlConnection(Startup.GetStringMySqlConnection());
            string sqlCmd = "SELECT id, nome FROM usuarios Where email='"+email+"' and senha = '"+senha+"'";
            
            System.Diagnostics.Debug.WriteLine(sqlCmd);

            MySqlDataAdapter da = new MySqlDataAdapter(sqlCmd, conn);
            da.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                {
                Login login = new Login();
                login.email = email;
                var token = TokenService.GenerateToken(login);
                //return JsonConvert.SerializeObject(dt);
                return token;
                }
            else
                {
                return "{ status='error', message = 'Usuário ou senha inválidos' }";
            }
            
        }
    }
}

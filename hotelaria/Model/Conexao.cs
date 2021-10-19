using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
//using System.Data.SqlClient;  //usado para o Sql Server

namespace hotelariaX.Model
{
    public class Conexao
    {
        MySqlConnection con = new MySqlConnection();  //usar para Mysql/MariaDB 
        //SqlConnection con = new SqlConnection(); //usar para Sql Server

        public Conexao()  // construtor
        {
            con.ConnectionString = @"server=localhost;uid=root;password=;database=unip33; SslMode = none";  //usar para MariaDB/Mysql
            //Usar para SqlServer
            //con.ConnectionString = @"Data Source=DESKTOP-6LH77KM\SQLEXPRESS; Initial Catalog=Hotel; Integrated Security=True";
        }
        //public SqlConnection conectar(){ ...}   //usar para Sqlserver
        public MySqlConnection conectar()   // usar para Mysql
        {
            //verifica se a conexão com o banco está fechada
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}

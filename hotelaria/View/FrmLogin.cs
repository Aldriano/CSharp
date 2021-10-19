using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using hotelariaX.Controller;
using hotelariaX.Model;
using MaterialSkin.Controls;

namespace hotelariaX
{
    public partial class frmLogin : MaterialForm
    {
        Thread novoThread;
        Util util = new Util();
        Controller.Controller controller = new Controller.Controller();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Favor informar o E-mail!", "ATENÇÃO");
                txtEmail.Focus();
            }
            else if (!util.ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("E-mail Incorreto!", "ATENÇÃO");
                txtEmail.Focus();

            }
            else if (String.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Favor informar a senha!", "ATENÇÃO");
                txtSenha.Focus();
            }
            else
            {
                

                Program.dadosLogin = controller.ValidaLogin(txtEmail.Text, txtSenha.Text);

                if (!String.IsNullOrEmpty(Program.dadosLogin.Nome))
                {                
                    this.Close(); //fecha a janela de login
                    novoThread = new Thread(chamarMenu);
                    novoThread.SetApartmentState(ApartmentState.STA);
                    novoThread.Start();
                }
                else
                {
                    MessageBox.Show("Acesso negado!", "ATENÇÃO");
                }
            }            
            
        }

        private void chamarMenu()
        {
            Application.Run(new FrmMenu());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao con = new Conexao();
            con.conectar();

            /*MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;pwd=;database=unip33;SslMode = none";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MessageBox.Show("Conexão OK");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
            /*Conexao con = new Conexao();
            con.conectar();
            if (con.ValidaConexao())
            {
                MessageBox.Show("OK");
            }
            else
                MessageBox.Show("Houve um erro na conexão com o banco");*/


        }

        private void frmLogin_Enter(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

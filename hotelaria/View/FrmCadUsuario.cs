using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hotelariaX.Controller;
using hotelariaX.Model;
using MaterialSkin;
using MaterialSkin.Controls;

namespace hotelariaX
{
    public partial class FrmCadUsuario : MaterialForm
    {
        Controller.Controller ObjController = new Controller.Controller();
        Usuario dadosUsuario = new Usuario();
        public FrmCadUsuario()
        {
            InitializeComponent();
            //http://www.macoratti.net/17/07/cshp_matlog1.htm
            // Criando um material theme manager e adicionando o formulário
            /*MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            // Definindo um esquema de Cor para formulário com tom Azul
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
             );*/
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            panelCampos.Enabled = true;
            limparCampos();
            dadosUsuario.Id = 0;
        }

        private void limparCampos()
        {
            txtNome.Focus();
            txtNome.Text = "";
            txtCpf.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtSenhaConfirmar.Text = null;
            cbNivel.Text = null;
            cbStatus.Text = null;
            cbNivel.SelectedText = "Usuário";
            cbStatus.SelectedText = "Ativo";
        }

        private void FrmCadUsuario_Load(object sender, EventArgs e)
        {
            GridListarUsuario();
            FormatarDtGridUser();
        }

        void GridListarUsuario()
        {
            dataGridViewUsuario.AutoGenerateColumns = false;
            dataGridViewUsuario.DataSource = ObjController.ListarUsuarios();

            //dataGridViewUsuario.Columns.Add("nome", "Nome"); //inserir coluna em runtime
            dataGridViewUsuario.Columns[0].Visible = false;  //ocultar a coluna do Id
            dataGridViewUsuario.Columns["id"].DataPropertyName     = "id";
            dataGridViewUsuario.Columns["nome"].DataPropertyName   = "nome";
            dataGridViewUsuario.Columns["cpf"].DataPropertyName    = "cpf";
            dataGridViewUsuario.Columns["email"].DataPropertyName  = "email";
            dataGridViewUsuario.Columns["senha"].DataPropertyName  = "senha";
            dataGridViewUsuario.Columns["nivel"].DataPropertyName  = "nivel";
            dataGridViewUsuario.Columns["status"].DataPropertyName = "status";
            dataGridViewUsuario.AutoResizeColumns();
            dataGridViewUsuario.AllowUserToResizeColumns = true;
            dataGridViewUsuario.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            /*dataGridViewUsuario.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridViewUsuario.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dataGridViewUsuario.CellBorderStyle = DataGridViewCellBorderStyle.None;            
            dataGridViewUsuario.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridViewUsuario.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            */




            ////ADD BUTTON COLUMN - 
            ///https://camposha.info/csharp/csharp-datagridview-customization/
            /*DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Buttons";
            btn.Name = "button";
            btn.Text = "Click Me";
            btn.UseColumnTextForButtonValue = true;
            dataGridViewUsuario.Columns.Add(btn);
            */
        }
        private void FormatarDtGridUser()
        {
            //dtGridUser.Columns[0].HeaderText = "Nome";  //Cabeçaho
            //dtGridUser.Columns[0].Width = 50; // Definir Largura



            /*for (int i=0; i< dtGridUser.Rows.Count; i++)
            {
                string status = Convert.ToString(dtGridUser.Rows[i].Cells[2].Value.ToString());
                if ( status == "1")
                    dtGridUser.Rows[i].Cells[0].Style.BackColor = Color.LightSalmon;
                else
                    dtGridUser.Rows[i].Cells[0].Style.BackColor = Color.Aquamarine;
            }*/
        }

        private void dataGridViewUsuario_DoubleClick(object sender, EventArgs e)
        {
            carregarDadosForm();
        }

        private void carregarDadosForm()
        {
            panelCampos.Enabled = true;
            //Pega o id do registro atual, usado para atualizar os dados
            //Se dadosUsuario.Id == null é uma inserção, senão alteração dos dados
            dadosUsuario.Id = (int)dataGridViewUsuario.CurrentRow.Cells[0].Value;
            txtNome.Text  = dataGridViewUsuario.CurrentRow.Cells[1].Value.ToString();
            txtCpf.Text   = dataGridViewUsuario.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataGridViewUsuario.CurrentRow.Cells[3].Value.ToString();
            txtSenha.Text = dataGridViewUsuario.CurrentRow.Cells[4].Value.ToString();
            txtSenhaConfirmar.Text = dataGridViewUsuario.CurrentRow.Cells[4].Value.ToString();
            cbNivel.Text  = dataGridViewUsuario.CurrentRow.Cells[5].Value.ToString();
            cbStatus.Text = dataGridViewUsuario.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Favor informar o Nome!");
                txtNome.Focus();
            }else if (String.IsNullOrEmpty(txtCpf.Text))
            {
                MessageBox.Show("Favor informar o CPF!");
                txtCpf.Focus();
            }
            else if (salvarDadosUsuario()) {
                MessageBox.Show("Salvo com Sucesso!");
                btnCancelar.PerformClick(); //simula um click no botão cancelar
            }
            else
                MessageBox.Show("Ocorreu erro ao Salvar!");
        }

        private bool salvarDadosUsuario()
        {
            if (txtSenha.Text == txtSenhaConfirmar.Text)
            {
                dadosUsuario.Nome = txtNome.Text;
                dadosUsuario.Cpf = txtCpf.Text;
                dadosUsuario.Email = txtEmail.Text;
                dadosUsuario.Senha = txtSenha.Text;
                dadosUsuario.Nivel = cbNivel.Text;
                dadosUsuario.Status = cbStatus.Text;
                //enviar para o Controler para salvar,
                //passando como parâmetro o objeto dadosUsuario
                //Controller envia para o UsuarioDAO
                // Retornará true ou false
                return ObjController.SalvarDadosUsuario(dadosUsuario);
            }
            else
            {
                MessageBox.Show("Senha não conferem, favor verificar!");
                txtSenha.Focus();
                return false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
            panelCampos.Enabled = false;
            GridListarUsuario();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCampos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nomeParaPesquisa = Util.ShowDialog("Informe o nome.", "Pesquisa Usuário");
            if (String.IsNullOrEmpty(nomeParaPesquisa))
                GridListarUsuario();
            else
                GridListarUsuarioPesquisa(nomeParaPesquisa);
        }



        void GridListarUsuarioPesquisa( string nome)
        {
            dataGridViewUsuario.AutoGenerateColumns = false;
            dataGridViewUsuario.DataSource = ObjController.ListarUsuariosPesquisa(nome);

            //dataGridViewUsuario.Columns.Add("nome", "Nome"); //inserir coluna em runtime
            dataGridViewUsuario.Columns[0].Visible = false;  //ocultar a coluna do Id
            dataGridViewUsuario.Columns["id"].DataPropertyName = "id";
            dataGridViewUsuario.Columns["nome"].DataPropertyName = "nome";
            dataGridViewUsuario.Columns["cpf"].DataPropertyName = "cpf";
            dataGridViewUsuario.Columns["email"].DataPropertyName = "email";
            dataGridViewUsuario.Columns["senha"].DataPropertyName = "senha";
            dataGridViewUsuario.Columns["nivel"].DataPropertyName = "nivel";
            dataGridViewUsuario.Columns["status"].DataPropertyName = "status";
            dataGridViewUsuario.AutoResizeColumns();
            dataGridViewUsuario.AllowUserToResizeColumns = true;
            dataGridViewUsuario.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
    }
}

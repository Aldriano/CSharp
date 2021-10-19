using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hotelariaX.View;
using MaterialSkin;
using MaterialSkin.Controls;

namespace hotelariaX
{
    public partial class FrmMenu : MaterialForm
    {
        public FrmMenu()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            // barra de  corverde -> materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan400, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue500, Accent.Green400, TextShade.WHITE);
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange700, Primary.Orange900, Primary.Orange500, Accent.Red700, TextShade.WHITE);
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo700, Primary.Indigo900, Primary.Indigo500, Accent.Pink400, TextShade.WHITE);
            
        }

        private void quartoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadQuarto frm = new FrmCadQuarto();
            frm.ShowDialog(this);
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadUsuario f = new FrmCadUsuario();
            f.ShowDialog(this);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            if(Program.dadosLogin.Nivel != "Administrador")
                usuárioToolStripMenuItem.Visible = false;
            
        }

        private void finalizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Finalizar Sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
                Application.Exit();

        }
    }
}

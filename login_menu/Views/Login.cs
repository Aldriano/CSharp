using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using testemenu.View;

namespace testemenu
{
    public partial class FrmLogin : Form
    {
        Thread newThread;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            this.Close();
            newThread = new Thread(chamarMenu);
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();
        }

        private void chamarMenu()
        {
            Application.Run(new FrmMenu());
        }
    }
}

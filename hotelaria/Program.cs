using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using hotelariaX.Model;

namespace hotelariaX
{
   
    static class Program
    {
        // gera erro tem que declarar com public static  ->>> Login dadosLogin = new Login();
        public static Login dadosLogin = new Login(); //Global
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}

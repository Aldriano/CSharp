using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotelariaX.Model;

namespace hotelariaX.Controller
{
    class Controller
    {
        LoginDAO loginDAO     = new LoginDAO();
        UsuarioDAO usuarioDao = new UsuarioDAO();
        public Login ValidaLogin(String email, String senha)
        {
            Login usuarioLogin = new Login(); //guarda o retorno do LoginDao
            usuarioLogin = loginDAO.validarLogin(email, senha);
            return usuarioLogin;
        }

        public DataTable ListarUsuarios()
        {
            DataTable dt = new DataTable();
            dt = usuarioDao.ListarUsuarios();
            return dt;
        }

        public DataTable ListarUsuariosPesquisa( string nome)
        {
            DataTable dt = new DataTable();
            dt = usuarioDao.ListarUsuariosPesquisa(nome);
            return dt;
        }

        internal bool SalvarDadosUsuario(Usuario dadosUsuario)
        {
            if(dadosUsuario.Id == 0)  
                return usuarioDao.InserirDadosUsuario(dadosUsuario);
            else
               return usuarioDao.AtualizacaoDadosUsuario(dadosUsuario);
        }
    }
}

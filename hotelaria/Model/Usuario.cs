using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotelariaX.Model
{
    class Usuario
    {
        int id;
        string nome;
        string cpf;
        string email;
        string senha;
        string status;
        string nivel;


        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Status { get => status; set => status = value; }
        public string Nivel { get => nivel; set => nivel = value; }
    }
}


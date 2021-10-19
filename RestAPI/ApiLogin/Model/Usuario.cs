using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLogin.Model
{
    public class Usuario
    {
        //Ao invés de declarar o Data Annotations aqui, foi declarada as propriedades
        // na classe AppDBContext
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
    }
}

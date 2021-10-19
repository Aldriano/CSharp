using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiLogin.Model
{
    //Classe contexto -> Mapeamento ORM entre a entidade e tabela
    public class AppDbContext : DbContext
    {
        //Construtor
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        //DBSet mapea a entidade Usuario para a tabela Usuarios (será criada)
        public DbSet<Usuario> Usuarios {get;set; }
        
        //Sobreescreve o método create, ao criar a tabela verifica se tem dados iniciais
        //Se não conter, irá inserir
        //Ao aplicar o MIGRATIONS irá criar a tabela no banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ao invés de declarar Data Annotations na classe Usuario, definimos aqui
            // algumas propriedades de alguns atributos
            //Configurações que o Migrations irá aplicar
            modelBuilder.Entity<Usuario>()
                .Property(p => p.Nome).HasMaxLength(80); // definir varchar(8)
            // new Usuario = cria a entidade com dados iniciais
            modelBuilder.Entity<Usuario>()
                .HasData( new Usuario { Id = 1, Nome = "Admin", Email = "admin@admin.com", Senha = "123456" });
            
        }

    }
}

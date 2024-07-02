using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plataforma_ensino.AcessoBD
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ensinoContexto : DbContext
    {
        public ensinoContexto() : base("server=localhost;database=ENSINO;uid=root;pwd=root") { }

        public DbSet<Professor> Professores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Ministra> Ministram { get; set; }
        public DbSet<Nota> Notas { get; set; }
    }
}

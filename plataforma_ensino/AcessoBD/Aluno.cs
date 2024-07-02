using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plataforma_ensino.AcessoBD
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public int IdAluno { get; set; }


        public string NomeCompleto { get; set; }


        public string Email { get; set; }


        public string Cpf { get; set; }

        public DateTime? DataNasc { get; set; }

        public string Genero { get; set; }


        public string NumContato { get; set; }

        public string Nacionalidade { get; set; }

        public string Logradouro { get; set; }

        public int? Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}

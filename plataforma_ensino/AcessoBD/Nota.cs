using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plataforma_ensino.AcessoBD
{
    [Table("Nota")]
    public class Nota
    {
        [Key, Column(Order = 0)]
        public int IdDisciplina_Fk { get; set; }

        [Key, Column(Order = 1)]
        public int IdAluno_Fk { get; set; }

        public bool Aprovado { get; set; }


        [ForeignKey("IdDisciplina_Fk")]
        public Disciplina Disciplina { get; set; }

        [ForeignKey("IdAluno_Fk")]
        public Aluno Aluno { get; set; }
    }
}

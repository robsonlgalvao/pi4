using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plataforma_ensino.AcessoBD
{
    [Table("Ministra")]
    public class Ministra
    {
        [Column(Order = 0)]
        public int IdProfessorFk { get; set; }

        [Key, Column(Order = 1)]
        public int IdDisciplinaFk { get; set; }


        [ForeignKey("IdProfessorFk")]
        public Professor Professor { get; set; }

        [ForeignKey("IdDisciplinaFk")]
        public Disciplina Disciplina { get; set; }
    }
}

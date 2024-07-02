using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plataforma_ensino.AcessoBD
{
    [Table("Disciplina")]
    public class Disciplina
    {
        [Key]
        public int IdDisciplina { get; set; }
        public string NomeDisciplina { get; set; }
    }
}

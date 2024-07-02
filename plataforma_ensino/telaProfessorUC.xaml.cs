using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace plataforma_ensino
{
    /// <summary>
    /// Interação lógica para telaProfessorUC.xam
    /// </summary>
    public partial class telaProfessorUC : UserControl
    {
        public telaProfessorUC()
        {
            InitializeComponent();

            var clientes = new[]{
              new {Aluno = "José Maria", AV1 = "3", AV2 = "5",AV3 ="10", situacao = "Reprovado"},
              new {Aluno = "José Maria", AV1 = "3", AV2 = "5",AV3 ="10", situacao = "Reprovado"},

             };

            dataGridClientes.ItemsSource = clientes;
        }
    }
}

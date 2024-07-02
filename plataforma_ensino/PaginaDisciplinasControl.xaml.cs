using plataforma_ensino.AcessoBD;
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
    public partial class PaginaDisciplinasControl : UserControl
    {
        private ensinoContexto contexto = new ensinoContexto();

        public PaginaDisciplinasControl()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CarregarDisciplinas();
        }


        private void CarregarDisciplinas()
        {
            if (Navegador.AlunoAtual != 0)
            {
                try
                {
                    var disciplinas = contexto.Notas.Where(n => n.IdAluno_Fk == Navegador.AlunoAtual)
                                      .Select(n => n.Disciplina.NomeDisciplina)
                                      .ToList();
                    lstDisciplinas.ItemsSource = disciplinas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
        }

        private void Retornar_Click(object sender, RoutedEventArgs e)
        {
            Navegador.MostrarJanela<PaginaMatriculaUC>();
        }
    }
}

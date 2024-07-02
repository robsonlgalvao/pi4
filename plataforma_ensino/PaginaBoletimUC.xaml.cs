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
    /// <summary>
    /// Interação lógica para BoletimUC.xam
    /// </summary>
    public partial class PaginaBoletimUC : UserControl
    {
        private ensinoContexto contexto = new ensinoContexto();
        public PaginaBoletimUC()
        {
            InitializeComponent();
        }
        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CarregarBoletim();
        }
        private void CarregarBoletim()
        {
            if (Navegador.AlunoAtual != 0)
            {
                try
                {
                    // Consulta as notas do aluno atual
                    var notas = contexto.Notas
                                       .Where(n => n.IdAluno_Fk == Navegador.AlunoAtual)
                                       .Select(n => new
                                       {
                                           NomeDisciplina = n.Disciplina.NomeDisciplina,
                                           Aprovado = n.Aprovado
                                       })
                                       .ToList();

                    dgNotas.ItemsSource = null;
                    dgNotas.Items.Clear();
                    

                    dgNotas.ItemsSource = notas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aluno atual não encontrado.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Retornar_Click(object sender, RoutedEventArgs e)
        {
            Navegador.MostrarJanela<PaginaMatriculaUC>();
        }
    }
}

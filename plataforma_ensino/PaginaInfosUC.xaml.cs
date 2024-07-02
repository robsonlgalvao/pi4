using plataforma_ensino.AcessoBD;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public partial class PaginaInfosUC : UserControl
    {
        private ensinoContexto contexto = new ensinoContexto();
        public PaginaInfosUC()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CarregarInfos();
        }

        private void CarregarInfos()
        {
            if (Navegador.AlunoAtual != 0)
            {
                try
                {
                    var Alunos = contexto.Alunos.ToList();
                    var aluno = Alunos.Where(a => a.IdAluno == Navegador.AlunoAtual).First();
                    if (aluno != null)
                    {
                        NomeLabel.Content = aluno.NomeCompleto;
                        EmailLabel.Content = aluno.Email;
                        DataNascLabel.Content = aluno.DataNasc.Value.ToString("dd/MM/yyyy");
                        CpfLabel.Content = aluno.Cpf;
                        GeneroLabel.Content = aluno.Genero;
                        NacionalidadeLabel.Content = aluno.Nacionalidade;
                        EnderecoLabel.Content = aluno.Logradouro;
                        ContatoLabel.Content = aluno.NumContato;
                    }
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

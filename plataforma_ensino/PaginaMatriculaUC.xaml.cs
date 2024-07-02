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
    /// Interação lógica para PaginaMatriculaUC.xam
    /// </summary>
    public partial class PaginaMatriculaUC : UserControl
    {
        private ensinoContexto contexto = new ensinoContexto();
        public PaginaMatriculaUC()
        {
            InitializeComponent();
        }

        private void DisciplinasClick(object sender, RoutedEventArgs e)
        {
            Navegador.MostrarJanela<PaginaDisciplinasControl>();
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            //TENTANDO ENCONTRAR UM ALUNO PELA MATRÍCULA
            try
            {
                ValidarDados();
                Navegador.AlunoAtual = Convert.ToInt32(matriculaTxt.Text);

                var Alunos = contexto.Alunos.ToList();
                var aluno = Alunos.Where(a => a.IdAluno == Navegador.AlunoAtual).First();

                if (Navegador.AlunoAtual == aluno.IdAluno)
                {
                    MessageBox.Show("Aluno encontrado!","Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, digite um ID de aluno válido!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aluno não encontrado! ", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ValidarDados()
        {
            if (matriculaTxt.Text.Trim().Length == 0)
            {
                throw new Exception("Digite a sua matrícula");
            }

            if (!int.TryParse(matriculaTxt.Text.Trim(), out _))
            {
                throw new Exception("Matrícula inválida: digite apenas números");
            }

        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            Navegador.MostrarJanela<PaginaCadastroUC>();
        }

        private void Boletim_Click(object sender, RoutedEventArgs e)
        {
            Navegador.MostrarJanela<PaginaBoletimUC>();
        }

        private void Infos_Click(object sender, RoutedEventArgs e)
        {
            Navegador.MostrarJanela<PaginaInfosUC>();
        }
    }
}

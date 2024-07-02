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
    public partial class PaginaCadastroUC : UserControl
    {
        private class DisciplinaMatricular
        {
            public bool Marcada { get; set; }
            public string NomeDisciplina { get; set; }
        }


        private ensinoContexto contexto = new ensinoContexto();
        public PaginaCadastroUC()
        {
            InitializeComponent();
            DataNascDtp.Text = DateTime.Now.ToString();
            CarregarDisciplinas();
        }

        private void CarregarDisciplinas()
        {
            List<Disciplina> disciplinas = contexto.Disciplinas.ToList();
            List<DisciplinaMatricular> disciplinaMatriculars = new();
            foreach (var Disciplina in disciplinas)
            {
                var d = new DisciplinaMatricular();
                d.Marcada = false;
                d.NomeDisciplina = Disciplina.NomeDisciplina;
                disciplinaMatriculars.Add(d);
            }
            lstDisciplinas.ItemsSource = disciplinaMatriculars;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EnviarClick(object sender, RoutedEventArgs e)
        {

            try
            {
                ValidarDados();

                Aluno aluno = new Aluno();
                aluno.NomeCompleto = NomeTxt.Text.Trim();
                aluno.Email = EmailTxt.Text.Trim();
                aluno.DataNasc = DataNascDtp.SelectedDate;
                aluno.Cpf = CpfTxt.Text.Trim();
                aluno.Genero = (GeneroTxt.SelectedItem as ComboBoxItem)?.Content.ToString();
                aluno.Nacionalidade = NacionalidadeTxt.Text.Trim();
                aluno.NumContato = ContatoTxt.Text.Trim();
                aluno.Logradouro = EnderecoTxt.Text.Trim();

                contexto.Alunos.Add(aluno);
                contexto.SaveChanges();

                List<Disciplina> disciplinas = contexto.Disciplinas.ToList();
                foreach (DisciplinaMatricular disciplinaMatricula in lstDisciplinas.ItemsSource)
                {
                    if (disciplinaMatricula.Marcada)
                    {
                        var disciplina = disciplinas.Where(d => d.NomeDisciplina == disciplinaMatricula.NomeDisciplina).First();
                        Nota nota = new Nota();
                        nota.Aluno = aluno;
                        nota.Disciplina = disciplina;
                        contexto.Notas.Add(nota);
                        contexto.SaveChanges();
                    }
                }

                Navegador.AlunoAtual = aluno.IdAluno;

                MessageBox.Show($"Matrícula realizada com sucesso! Seu número de matrícula é: {aluno.IdAluno}");
                LimparCampos();

                Navegador.MostrarJanela<PaginaMatriculaUC>();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void ValidarDados()
        {
            if (NomeTxt.Text.Trim().Length == 0)
            {
                // Erro porque não foi informado o nome
                throw new Exception("Nome inválido");
            }

            if (EmailTxt.Text.Trim().Length == 0)
            {
                // Erro porque não foi indicada uma categoria
                throw new Exception("E-mail inválido");
            }

            DateTime? nascimento = DataNascDtp.SelectedDate;
            if (!(nascimento.HasValue && nascimento <= DateTime.Now))
            {
                throw new Exception("Data de nascimento inválida");
            }

            if (CpfTxt.Text.Trim().Length < 14)
            {
                throw new Exception("CPF inválido, utilize os sinais entre os digitos: . - ");
            }

            if (GeneroTxt.Text.Trim().Length == 0)
            {
                throw new Exception("Gênero inválido");
            }

            if (NacionalidadeTxt.Text.Trim().Length == 0)
            {
                throw new Exception("Nacionalidade inválida");
            }

            if (EnderecoTxt.Text.Trim().Length == 0)
            {
                throw new Exception("Endereço inválido");
            }

            if (ContatoTxt.Text.Trim().Length == 0)
            {
                throw new Exception("Número de contato inválido\n Utilize o formato: (DDD) 9xxxx-xxxx");
            }

        }

        private void Pular_Click(object sender, RoutedEventArgs e)
        {
            Navegador.MostrarJanela<PaginaMatriculaUC>();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void LimparCampos()
        {
            NomeTxt.Text = "";
            EmailTxt.Text = "";
            DataNascDtp.SelectedDate = DateTime.Now;
            CpfTxt.Text = "";
            GeneroTxt.SelectedIndex = -1; 
            NacionalidadeTxt.Text = "";
            ContatoTxt.Text = "";
            EnderecoTxt.Text = "";

            if (lstDisciplinas.ItemsSource != null)
            {
                List<DisciplinaMatricular> disciplinas = lstDisciplinas.ItemsSource as List<DisciplinaMatricular>;
                foreach (var disciplina in disciplinas)
                {
                    disciplina.Marcada = false;
                }
            }
        }
    }
}

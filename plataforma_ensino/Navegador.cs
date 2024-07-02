using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using plataforma_ensino.AcessoBD;

namespace plataforma_ensino
{
    public class Navegador
    {
        public static Panel PainelBase { get; set; } = null;
        public static int AlunoAtual { get; set; } = 0;

        //private ensinoContexto contexto = new ensinoContexto();
        //public void SetAlunoAtual(int idAluno)
        //{
        //    try
        //    {
        //        var aluno = contexto.Alunos.FirstOrDefault(a => a.IdAluno == idAluno);
        //        if (aluno != null)
        //        {
        //            Navegador.AlunoAtual = aluno.IdAluno;
        //            // Faça o que for necessário com o aluno recuperado
        //        }
        //        else
        //        {
        //            // Caso o aluno não seja encontrado
        //            MessageBox.Show("Aluno não encontrado", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
        public static void MostrarJanela<T>() where T : UserControl, new()
        {
            if (PainelBase == null)
            {
                return;
            } 

            var filhos = PainelBase.Children.OfType<T>();
            // "filhos" é uma coleção de janelas do tipo T já inseridas
            // no painel

            T janela;
            if (filhos.Count() == 0)
            {
                //Não existe controle do tipo T
                janela = new T(); //UserControl criado
                PainelBase.Children.Add(janela);
            }
            else
            {
                // Pegar a primeira janela do tipo T
                janela = filhos.First();
            }

            // Torna a janela criada ou escolhida como visivel e as demais invisiveis
            foreach (var filho in PainelBase.Children)
            {
                var filhoControle = (UserControl)filho;
                if (filhoControle == janela)
                    filhoControle.Visibility = Visibility.Visible;
                else
                    filhoControle.Visibility = Visibility.Collapsed;
            }
        }

        private Navegador() { }
    }
}


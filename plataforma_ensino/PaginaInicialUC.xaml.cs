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
    /// Interação lógica para PaginaInicialUC.xam
    /// </summary>
    public partial class PaginaInicialUC : UserControl
    {
        public PaginaInicialUC()
        {
            InitializeComponent();
        }

        private void Button_Aluno(object sender, RoutedEventArgs e)
        {
            Navegador.MostrarJanela<PaginaCadastroUC>();
        }

        private void Button_Professor(object sender, RoutedEventArgs e)
        {
           Navegador.MostrarJanela<telaProfessorUC>();
        }
    }
}

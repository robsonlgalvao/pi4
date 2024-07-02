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
using System.Windows.Shapes;

namespace plataforma_ensino
{
    /// <summary>
    /// Lógica interna para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Indicar para a classe Navegador (que controla a pagina/usercontrol que está visivel no PainelBase
            // que eu estou inicializando como o PainelPrincipal da MainWindow
            Navegador.PainelBase = PainelPrincipal;

            // Começar com a Pagina1
            Navegador.MostrarJanela<PaginaInicialUC>();
        }
    }
}

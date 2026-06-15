using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MegaMaster_Domain.Business;

namespace MegaMaster_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
  
        private Controller _controller;

        private List<string> _colors;

        public MainWindow()
        {
            InitializeComponent();

            _controller = new Controller();
            _colors = _controller.AvailableColors;
           
            cmb1.ItemsSource = _colors;
            cmb2.ItemsSource = _colors;
            cmb3.ItemsSource = _colors;
            cmb4.ItemsSource = _colors;
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            List<string> guess =new List<string>();
            guess.Add(cmb1.SelectedItem?.ToString());
            guess.Add(cmb2.SelectedItem?.ToString());
            guess.Add(cmb3.SelectedItem?.ToString());
            guess.Add(cmb4.SelectedItem?.ToString());
            if (guess.Contains(null))
            {
                MessageBox.Show("Kies vier kleuren.");
                return;
            }

            GuessResult result = _controller.CheckGuess(guess);

            lstResults.Items.Add($"{_controller.Attempts}. {result}");

            if (_controller.IsWinner(result))
            {
                MessageBox.Show(
                    $"Proficiat {txtPlayer.Text}! Je won in {_controller.Attempts} beurten.");

                SaveScore();
            }
        }

        private void SaveScore()
        {
            // 1. Haal de naam op uit het tekstvak
            string spelerNaam = txtPlayer.Text;

            // 2. Controleer of de speler wel een naam heeft ingevuld
            if (string.IsNullOrWhiteSpace(spelerNaam))
            {
                spelerNaam = "Anoniem";
            }

            // 3. Roep de opslagmethode van je controller aan
            _controller.SlaScoreOp(spelerNaam);
        }

    }
}
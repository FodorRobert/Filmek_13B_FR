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

namespace Filmek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Film> filmek = new List<Film>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            filmek = new List<Film>
            {
                new Film { Cim = "Csillagok háborúja", Mufaj = "sci-fi", Hossz = 121, Ertekeles = 8.6 },
                new Film { Cim = "Titanic", Mufaj = "dráma", Hossz = 195, Ertekeles = 7.8 },
                new Film { Cim = "A Gyűrűk Ura", Mufaj = "fantasy", Hossz = 201, Ertekeles = 8.8 },
                new Film { Cim = "Mátrix", Mufaj = "sci-fi", Hossz = 136, Ertekeles = 8.7 },
                new Film { Cim = "Shrek", Mufaj = "animáció", Hossz = 90, Ertekeles = 7.9 }
            };
            DataGrid.ItemsSource = filmek;
            ProgressBar.Value = 20;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedItem is Film kivalasztott)
            {
                MessageBox.Show($"Kiválasztott film: {kivalasztott.Cim}\nÉrtékelés: {kivalasztott.Ertekeles}");
            }
        }

        private void BtnDarab_Click(object sender, RoutedEventArgs e) => MessageBox.Show($"Összesen {filmek.Count} film van.");

        private void BtnLeghosszabb_Click(object sender, RoutedEventArgs e)
        {
            var max = filmek.OrderByDescending(f => f.Hossz).FirstOrDefault();
            if (max != null) MessageBox.Show($"Leghosszabb film: {max.Cim} ({max.Hossz} perc)");
        }

        private void BtnAtlag_Click(object sender, RoutedEventArgs e)
        {
            if (filmek.Any()) MessageBox.Show($"Átlag értékelés: {filmek.Average(f => f.Ertekeles):F2}");
        }

        private void BtnScifi_Click(object sender, RoutedEventArgs e) => DataGrid.ItemsSource = filmek.Where(f => f.Mufaj == "sci-fi").ToList();

        private void BtnCimek_Click(object sender, RoutedEventArgs e) => MessageBox.Show(string.Join("\n", filmek.Select(f => f.Cim)));

        private void BtnRendezes_Click(object sender, RoutedEventArgs e) => DataGrid.ItemsSource = filmek.OrderBy(f => f.Cim).ToList();
    }
}
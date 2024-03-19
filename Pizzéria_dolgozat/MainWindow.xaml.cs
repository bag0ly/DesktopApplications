using System.IO;
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

namespace Pizzéria_dolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Pizzak
    {
        public string nev;
        public string checkbox1;
        public string checkbox2;

        public Pizzak(string line)
        {
            string[] lines = line.Split(';');

            this.nev = lines[0];
            this.checkbox1 = lines[1];
            this.checkbox2 = lines[2];
        }



    }
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Pizzak> pizzak = new List<Pizzak>();

            foreach (var line in File.ReadAllLines("pizzak.txt"))
            {
                pizzak.Add(new Pizzak(line));
            }
            PizzaKero pizzaKero = new PizzaKero(pizzak);
            MainWindow mainWindow = new MainWindow();

            pizzaKero.Show();
            mainWindow.Close();
        }
    }
}
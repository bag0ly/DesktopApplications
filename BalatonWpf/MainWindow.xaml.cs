using System.IO;
using System.Security.Cryptography.X509Certificates;
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
using Balaton;

namespace BalatonWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Haz> hazak = new List<Haz>();
        public MainWindow()
        {
            InitializeComponent(); 
            foreach (var item in File.ReadAllLines("utca.txt").Skip(1))
            {
                Haz h = new Haz(item);
                hazak.Add(h);
            }
            datagrid_adatok.ItemsSource = hazak;
            combobox_adosav.Items.Add('A');
            combobox_adosav.Items.Add('B');
            combobox_adosav.Items.Add('C');
        }

        private void btn_modosit_Click(object sender, RoutedEventArgs e)
        {
            var adosav = combobox_adosav.Text;
            if (adosav.Count()!=1)
            {
                MessageBox.Show("Nincs kivalaszott Adosav");
                return;
            }

            if (datagrid_adatok.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nincs kivalasztott fajl");
                return;
            }

            foreach (var selectedItem in datagrid_adatok.SelectedItems)
            {
                if (selectedItem is Haz h)
                {
                    h.setAdosav(Convert.ToChar(adosav));
                }
            }

            datagrid_adatok.Items.Refresh();
        }

        private void btn_mentes_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("modositott.txt"))
            {
                foreach (var item in hazak)
                {
                    sw.WriteLine($"{item.Adoszam} {item.Utca_neve} {item.Hazszam} {item.Adosav} {item.Alapterulet}");
                }
            }
        }
    }
}
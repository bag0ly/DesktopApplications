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
using haromszogekCLI_gyakorlas;


namespace haromszogekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Haromszogek> haromszogeks = new List<Haromszogek>();
        public MainWindow()
        {
            InitializeComponent(); 
            foreach (var item in File.ReadAllLines("haromszogek2.csv"))
            {
                Haromszogek haromszogek = new Haromszogek(item);
                haromszogeks.Add(haromszogek);
            }
            datagrid_haromszogek.ItemsSource = haromszogeks;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int a;
            int b;
            int c;
            if (int.TryParse(textbox_a.Text, out a) && int.TryParse(textbox_b.Text, out b) && int.TryParse(textbox_c.Text, out c) )
            {
                if (a < b && b < c)
                {
                    haromszogeks.Add(new Haromszogek($"{a} {b} {c}"));
                    datagrid_haromszogek.Items.Refresh();
                }
                else MessageBox.Show("Nem novekvo sorrend!");
            }
            else
            {
                MessageBox.Show("Ures minden");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("haromszogek3.csv")) 
            {
                foreach (var item in haromszogeks)
                {
                    sw.WriteLine($"{item.A} {item.B} {item.C}");
                }
            }
            MessageBox.Show("Mentes megtortent");
        }
    }
}
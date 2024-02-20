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

namespace wpf_alapok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bt_Kilep_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Bt_Felvitel_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(Tb_Felvitel.Text))
                {
                    throw new Exception("Nem adott meg adatot");
                }

                lb_adatok.Items.Add(Tb_Felvitel.Text);

                Tb_Felvitel.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bt_Torles_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                if (string.IsNullOrWhiteSpace(Tb_TorlesHely.Text))
                {
                    throw new Exception("Nem adott meg adatot");
                }

                int index = int.Parse(Tb_TorlesHely.Text);

                if (index < 0 || index >= lb_adatok.Items.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
                }

                lb_adatok.Items.RemoveAt(index);

                Tb_TorlesHely.Clear();
            }
            catch (FormatException)
            { 
                MessageBox.Show("Invalid input format. Please enter a valid integer.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Bt_Beszur_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Tb_BeszurasHely.Text))
                {
                    throw new Exception("Nem adott meg adatot");
                }

                int index = int.Parse(Tb_BeszurasHely.Text);

                if (index < 0 || index >= lb_adatok.Items.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
                }

                lb_adatok.Items.Insert(index, Tb_Felvitel.Text);
                Tb_BeszurasHely.Clear();
                Tb_Felvitel.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format. Please enter a valid integer.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
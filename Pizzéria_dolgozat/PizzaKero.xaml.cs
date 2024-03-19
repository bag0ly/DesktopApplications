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

namespace Pizzéria_dolgozat
{
    /// <summary>
    /// Interaction logic for PizzaKero.xaml
    /// </summary>
    /// 
    
    public partial class PizzaKero : Window
    {
        public PizzaKero(List<Pizzak> pizzak)
        {
            InitializeComponent();
            Veg.Content = pizzak[0].nev;
            Rd_Veg1.Content = pizzak[0].checkbox1 + "Ft";
            Rd_Veg2.Content = pizzak[0].checkbox2 + "Ft";
            Magy.Content = pizzak[1].nev;
            Rd_Magy1.Content = pizzak[1].checkbox1 + "Ft";
            Rd_Magy2.Content = pizzak[1].checkbox2 + "Ft";
            Som.Content = pizzak[2].nev;
            Rd_Som1.Content = pizzak[2].checkbox1 + "Ft";
            Rd_Som2.Content = pizzak[2].checkbox2 + "Ft";
            Med.Content = pizzak[3].nev;
            Rd_Med1.Content= pizzak[3].checkbox1 + "Ft";
            Rd_Med2.Content= pizzak[3].checkbox2 + "Ft";
            Ton.Content = pizzak[4].nev;
            Rd_Ton1.Content = pizzak[4].checkbox1 + "Ft";
            Rd_Ton2.Content = pizzak[4].checkbox2 + "Ft";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Veg.IsChecked = false;
            Magy.IsChecked = false;
            Som.IsChecked = false;
            Med.IsChecked = false;
            Ton.IsChecked = false;

            Rd_Veg1.IsChecked= false;
            Rd_Veg2.IsChecked = false;

            Rd_Magy1.IsChecked=false;
            Rd_Magy2.IsChecked=false;

            Rd_Som1.IsChecked=false;
            Rd_Som2.IsChecked=false;

            //Rd_Med1

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

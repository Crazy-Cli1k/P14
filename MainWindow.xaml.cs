using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using P14.ModelView;

namespace P14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CarViewModel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ((CarViewModel)DataContext).AddCar();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ((CarViewModel)DataContext).DeleteCar();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Double.TryParse(DescountBox.Text, out double desc))
            {
                if (CategoryBox.SelectedItem.ToString() == "Пассажирский транспорт")
                {
                    ((CarViewModel)DataContext).SelectedGroup(Model.categoryes.Passenger, desc);
                }
                else
                {
                    ((CarViewModel)DataContext).SelectedGroup(Model.categoryes.Truck, desc);
                }
            }
            else MessageBox.Show("Ошибка!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((CarViewModel)DataContext).Save();
        }
    }
}

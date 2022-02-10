using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using P14.Model;
using System.IO;
using System.Windows;

namespace P14.ModelView
{
    class CarViewModel
    {
        private Car _selectedCar;
        public ObservableCollection<Car> Cars { get; set; }
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                _selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }
        public CarViewModel()
        {
            Cars = new ObservableCollection<Car>
            {
               new Car { Model="ВАЗ-2105", MaxSpeed=150, Price=56000, Discount=0, Category=categoryes.Passenger},
               new Car { Model="LADA Priora", MaxSpeed=170, Price=560000, Discount=0.25, Category=categoryes.Passenger},
               new Car { Model="КамАЗ", MaxSpeed=100, Price=5600000, Discount=0.5, Category=categoryes.Truck}
            };
        }
        public void AddCar()
        {
            Car car = new Car();
            Cars.Insert(0, car);
            SelectedCar = car;
        }
        public void DeleteCar()
        {
            if (_selectedCar != null)
            {
                Cars.Remove(SelectedCar);
            }
        }
        public void SelectedGroup(categoryes category, double discount)
        {
            Cars.Where(c => c.Category == category).ToList().ForEach(x => x.Discount = discount);
        }
        public void Save()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            string FileName = "List.json";
            if (File.Exists(FileName))
            {
                File.WriteAllText(FileName, JsonSerializer.Serialize(Cars));
                MessageBox.Show("Успешно!");
            }
            else { MessageBox.Show("Такого файла нет!"); }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

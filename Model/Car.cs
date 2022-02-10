using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace P14.Model
{
    public enum categoryes
    {
        Passenger,
        Truck,
    }
    class Car : INotifyPropertyChanged
    {
        private string _model;
        private int _maxSpeed;
        private decimal _price;
        private double _discount;
        private  categoryes _category;
        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }
        [JsonPropertyName("MaxSpeed")]
        public int MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            set
            {
                _maxSpeed = value;
                OnPropertyChanged("MaxSpeed");
            }
        }
        [JsonPropertyName("Price")]
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        [JsonPropertyName("Discount")]
        public double Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                OnPropertyChanged("Discount");
            }
        }
        public bool HasDiscount
        {
            get
            {
                return _discount > 0;
            }
        }
        public decimal DiscountPrice
        {
            get
            {
                return _price * (decimal)(1 - _discount);
            }
        }
        [JsonPropertyName("Category")]
        public categoryes Category
        {
            get { return _category; }
            set
            {
                OnPropertyChanged("Category");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

}

using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private City[] _cities;
        private City _selectedCity;
        private Weather _weather;

        public MainViewModel()
        {
            _weather = new Weather()
            {
                Temperature = new Temperature()
                {
                    Metric = new Metric()
                    {
                        Value = 20,
                    }
                }
            };

            SelectedCity = new City() { LocalizedName = "Warszawa" };
        }


        public Weather Weather
        {
            get { return _weather; }
            set { 
                _weather = value;
                //OnPropertyChanged("Weather");
                OnPropertyChanged();
            }
        }

        public City SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
            }
        }

        public City[] Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                OnPropertyChanged();
            }
        }

      

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

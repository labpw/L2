using P04WeatherForecastAPI.Client.Commands;
using P04WeatherForecastAPI.Client.DataSeeders;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private City[] _cities;
        private City _selectedCity;
        private Weather _weather;
        private readonly IAccuWeatherService _accuWeatherService;

        public ICommand LoadCitiesCommand { get;  }

        public MainViewModel(IAccuWeatherService accuWeatherService)
        {
            LoadCitiesCommand = new RelayCommand(x => LoadCities(x as string));
            _accuWeatherService = accuWeatherService;

            //_weather = MainViewDataseeder.GenerateWeather;
            //_selectedCity = MainViewDataseeder.GenerateSelectedCity;
            //_cities = MainViewDataseeder.GenerateCities;
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
                LoadWeather();
            }
        }

        private async void LoadWeather()
        {
            if(SelectedCity != null)
            {
                Weather= await _accuWeatherService.GetCurrentConditions(SelectedCity.Key);
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

        public async void LoadCities(string locationName)
        {
           Cities= await _accuWeatherService.GetLocations(locationName);
        }
    }
}

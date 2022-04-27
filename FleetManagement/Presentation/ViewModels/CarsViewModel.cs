using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class CarsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<CarViewModel> _cars;

        public IEnumerable<CarViewModel> Cars => _cars;

        public  CarsViewModel()
        {
            var carService = App.Current.Services.GetService<IHttpCarService>();

            _cars = new ObservableCollection<CarViewModel>(carService.GetAllAsync().Result.Select(car=> new CarViewModel(car)));
        }


    }
}

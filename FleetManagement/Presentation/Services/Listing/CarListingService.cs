#nullable disable warnings
using Presentation.DTO;
using Presentation.Exceptions;
using Presentation.Interfaces;
using Presentation.Interfaces.ApiHttp;
using Presentation.Interfaces.Listing;
using Presentation.ViewModels;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Presentation.Services.Listing
{
    public class CarListingService : ICarListingService
    {
        public ObservableCollection<ViewModelBase> _items = new();
        public ObservableCollection<ViewModelBase> Items => _items;


        private ICollectionView _view;
        public ICollectionView View { get => _view; set => _view = value; }

        private readonly IHttpCarService _httpService;

        private readonly IMessageService _messageService;

        public CarListingService(IHttpCarService httpService, IMessageService messageService)
        {
            _httpService = httpService;
            _messageService = messageService;
        }



        public async Task Create(ViewModelBase item)
        {
            try
            {
                CarDto car = item as CarViewModel;

                var newItem = await _httpService.CreateAsync(car);
                _items.Add((CarViewModel)newItem);
            }
            catch(ApiException ex)
            {
                await _messageService.DisplayErrorAsync(ex.Message);
            }
        }

        public async Task Delete(ViewModelBase item)
        {
            try
            {
                CarDto car = item as CarViewModel;
                await _httpService.DeleteAsync(car.Id);
                _items.Remove(item);
            }
            catch(ApiException ex)
            {
                await _messageService.DisplayErrorAsync(ex.Message);
            }
        }

        public async Task LoadItems()
        {
            try
            {
                await foreach(var item in _httpService.GetAllStream())
                {
                    _items.Add((CarViewModel)item);
                }
            }
            catch(ApiException ex)
            {
                await _messageService.DisplayErrorAsync(ex.Message);
            }
            _view = CollectionViewSource.GetDefaultView(_items);
          
        }

        public async Task Update(ViewModelBase item)
        {
            try
            {
                CarDto car = item as CarViewModel;
                await _httpService.UpdateAsync(car);
                var ucar = await Find(c => c.Id == car.Id);
                ucar = car;
            }
            catch(ApiException ex)
            {
                await _messageService.DisplayErrorAsync(ex.Message);
            }
        }

        public bool Contains(ViewModelBase item)
        {
            return _items.Contains(item);
        }

        public Task<CarViewModel> Find(Func<CarViewModel, bool> predicate)
        {
            return Task.Run(() =>
            {
                return _items.Cast<CarViewModel>().First(predicate);
            });
        }
    }
}

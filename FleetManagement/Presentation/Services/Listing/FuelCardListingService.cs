#nullable disable warnings
using Presentation.DTO;
using Presentation.Exceptions;
using Presentation.Interfaces;
using Presentation.Interfaces.ApiHttp;
using Presentation.Interfaces.Listing;
using Presentation.ViewModels;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Presentation.Services.Listing
{
    public class FuelCardListingService : IFuelCardListingService
    {
        public ObservableCollection<ViewModelBase> _items = new();
        public ObservableCollection<ViewModelBase> Items => _items;

        private ICollectionView _view;
        public ICollectionView View { get => _view; set => _view = value; }

        private readonly IHttpFuelCardService _httpService;

        private readonly IMessageService _messageService;

        public FuelCardListingService(IHttpFuelCardService httpService, IMessageService messageService)
        {
            _httpService = httpService;
            _messageService = messageService;
        }

        public async Task Create(ViewModelBase item)
        {
            try
            {
                FuelCardDto fuelCard = item as FuelCardViewModel;

                var newItem = await _httpService.CreateAsync(fuelCard);
                _items.Add((FuelCardViewModel)newItem);
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
                FuelCardDto fuelCard = item as FuelCardViewModel;
                await _httpService.DeleteAsync(fuelCard.Id);
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
                    _items.Add((FuelCardViewModel)item);
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
                FuelCardDto fuelCard = item as FuelCardViewModel;
                await _httpService.UpdateAsync(fuelCard);
                var ucar = await Find(c => c.Id == fuelCard.Id);
                ucar = fuelCard;
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

        public Task<FuelCardViewModel> Find(Func<FuelCardViewModel, bool> predicate)
        {
            return Task.Run(() =>
            {
                return _items.Cast<FuelCardViewModel>().First(predicate);
            });
        }
    }
}

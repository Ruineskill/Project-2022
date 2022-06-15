#nullable disable warnings
using Presentation.DTO;
using Presentation.Enums;
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
    public class PersonListingService : IPersonListingService
    {
        private ObservableCollection<ViewModelBase> _items = new();
        public ObservableCollection<ViewModelBase> Items => _items;

        private ICollectionView _view;
        public ICollectionView View { get => _view; set => _view = value; }

        private readonly IHttpPersonService _httpService;

        private readonly IMessageService _messageService;

        public PersonListingService(IHttpPersonService httpService, IMessageService messageService)
        {
            _httpService = httpService;
            _messageService = messageService;
        }

        public async Task Create(ViewModelBase item)
        {
            try
            {
                PersonDto person = item as PersonViewModel;

                var newItem = await _httpService.CreateAsync(person);
                _items.Add((PersonViewModel)newItem);
            }
            catch(ApiException ex)
            {
                await _messageService.DisplayErrorAsync(ex.Message, DialogHosting.FleetHost);
            }
        }

        public async Task Delete(ViewModelBase item)
        {
            try
            {
                PersonDto person = item as PersonViewModel;
                await _httpService.DeleteAsync(person.Id);
                _items.Remove(item);
            }
            catch(ApiException ex)
            {
                await _messageService.DisplayErrorAsync(ex.Message, DialogHosting.FleetHost);
            }
        }

        public async Task LoadItems()
        {
            try
            {
                await foreach(var item in _httpService.GetAllStream())
                {
                    _items.Add((PersonViewModel)item);
                }
            }
            catch(ApiException ex)
            {
                await _messageService.DisplayErrorAsync(ex.Message, DialogHosting.FleetHost);
            }
            _view = CollectionViewSource.GetDefaultView(_items);

        }

        public async Task Update(ViewModelBase item)
        {
            try
            {
                PersonDto person = item as PersonViewModel;
                await _httpService.UpdateAsync(person);
                var ucar = await Find(c => c.Id == person.Id);
                ucar = person;
            }
            catch(ApiException ex)
            {
                await _messageService.DisplayErrorAsync(ex.Message, DialogHosting.FleetHost);
            }
        }

        public Task<PersonViewModel?> Find(Func<PersonViewModel, bool> predicate)
        {
            return Task.Run(() =>
            {
                return _items.Cast<PersonViewModel>().FirstOrDefault(predicate);
            });
        }

        public bool Contains(ViewModelBase item)
        {
            return _items.Contains(item);
        }
 

        public bool ContainsNationalId(string id)
        {
            return Find(p=>p.NationalID == id).Result != null;
        }
    }
}

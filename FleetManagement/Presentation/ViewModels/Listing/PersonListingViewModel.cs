using Presentation.DTO;
using Presentation.Interfaces.Listing;
using Presentation.Mediators;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewModels.Listing
{
    public class PersonListingViewModel : TabViewModelBase
    {
        public override string Name { get; set; } = "People";

        private readonly IPersonListingService _personListingService;
        private readonly PersonMediator _personMediator;

        public ObservableCollection<ViewModelBase> People => _personListingService.Items;

        private ViewModelBase? _selectedItem;
        public override ViewModelBase? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }


        public PersonListingViewModel(IPersonListingService personListingService, PersonMediator personMediator)
        {
            _personListingService = personListingService;
            _personMediator = personMediator;


            _ = _personListingService.LoadItems();

            _personMediator.OnCreated += OnPersonCreated;
            _personMediator.OnDeleted += OnPersonDeleted;
            _personMediator.OnUpdated += OnPersonUpdated;
        }


        private async void OnPersonCreated(PersonViewModel obj)
        {
            await _personListingService.Create(obj);
        }

        private async void OnPersonDeleted(PersonViewModel obj)
        {
            await _personListingService.Delete(obj);
        }

        private async void OnPersonUpdated(PersonViewModel obj)
        {
            await _personListingService.Update(obj);
        }

    }
}

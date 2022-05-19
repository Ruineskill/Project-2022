using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using Presentation.Mediators;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Presentation.ViewModels
{
    public class PersonListingViewModel : TabViewModelBase
    {
        public override string Name { get; set; } = "People";

        private readonly IHttpPersonService _personService;

        private readonly PersonMediator _personMediator;


        private readonly IDetailDialogService _detailDialogService;

        private ObservableCollection<PersonViewModel> _people;

        public ObservableCollection<PersonViewModel> People { get => _people; set => _people = value; }

        private PersonViewModel? _selectedPerson;
        public PersonViewModel? SelectedPerson
        {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }


        public PersonListingViewModel(IHttpPersonService personService, PersonMediator personMediator, IDetailDialogService detailDialogService)
        {
            _people = new();
            _personService = personService;
            _personMediator = personMediator;
            _detailDialogService = detailDialogService;
            _ = LoadPeople();

            _personMediator.Created += OnPersonCreated;
        }

        private async Task LoadPeople()
        {
           
            await foreach(var person in _personService.GetAllStream())
            {
                _people.Add(new PersonViewModel(person));
            }
 
        }

        private async void OnPersonCreated(Person obj)
        {
           if( await _personService.CreateAsync(obj))
            {
                _people.Add(new PersonViewModel(obj));
            }
        }

        public override void ReadItemHandler()
        {
            if(_selectedPerson != null)
            {
                _detailDialogService.SetContent(_selectedPerson);
                _detailDialogService.Show();
            }
        }

        public override void EditItemHandler()
        {
            if (_selectedPerson != null)
            {
                _detailDialogService.SetContent(_selectedPerson);
                _detailDialogService.Show();
            }
        }

        public override async void DeleteItemHandler()
        {
            if (_selectedPerson != null)
            {
                await _personService.DeleteAsync(_selectedPerson.Person);
            }
        }

        public override void AddItemHandler()
        {
            throw new NotImplementedException();
        }
    }
}

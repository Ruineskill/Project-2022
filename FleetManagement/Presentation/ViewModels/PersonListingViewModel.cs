using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
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

        private ObservableCollection<PersonViewModel> _people;

        public ObservableCollection<PersonViewModel> People { get => _people; set => _people = value; }

        private PersonViewModel? _selectedPerson;
        public PersonViewModel? SelectedPerson
        {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }


        public PersonListingViewModel(IHttpPersonService personService)
        {
            _people = new();
            _personService = personService;
            LoadPeople();
        }

        private async void LoadPeople()
        {
            try
            {
                var people = await _personService.GetAllAsync();
                foreach(var p in people) _people.Add(new PersonViewModel(p));
            }
            catch(Exception e)
            {

                MessageBox.Show(e.Message);
            }

        }
    }
}

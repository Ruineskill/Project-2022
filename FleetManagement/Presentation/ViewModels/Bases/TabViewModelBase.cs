using Microsoft.Toolkit.Mvvm.Input;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels.Bases
{
    public abstract class TabViewModelBase : ViewModelBase, IListingContextMenuCommands
    {
        public abstract string Name { get; set; }

        public ICommand ReadItemCommand { get; }

        public ICommand EditItemCommand { get; }

        public ICommand DeleteItemCommand { get; }
        public ICommand AddItemCommand { get; }

        public TabViewModelBase()
        {
            ReadItemCommand = new RelayCommand(ReadItemHandler);
            EditItemCommand = new RelayCommand(EditItemHandler);
            DeleteItemCommand = new RelayCommand(DeleteItemHandler);
            AddItemCommand = new RelayCommand(AddItemHandler);
        }


        public abstract void ReadItemHandler();
        public abstract void EditItemHandler();
        public abstract void DeleteItemHandler();
        public abstract void AddItemHandler();

    }
}

using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.Interfaces.Listing
{
    public interface IListingContextMenuCommands
    {
        ICommand ReadItemCommand { get; }
        ICommand EditItemCommand { get; }
        ICommand DeleteItemCommand { get; }
    }
}
